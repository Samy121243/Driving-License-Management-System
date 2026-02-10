using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD.Properties;
using DVLD_Buisness;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.ConstrainedExecution;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        // تعريف حدث من نوع delegate السابق
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0 , Update = 1 };

        public enum enGendor { Male = 0 , Female = 1 };

        private enMode _Mode;

        private int _PersonId = -1;

        clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;  
            

        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonId = PersonID;
        }

        private void _ResetDefultValues()
        {
            _FillCountriesInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if(rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
            }

            llRemoveImage.Visible = (pbPersonImage.Image != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Egypt");

            txtFirstName.Text = "";

            txtSecondName.Text = "";

            txtLastName.Text = "";

            txtThirdName.Text = "";

            txtNationalNo.Text = "";

            rbMale.Checked = true;

            txtPhone.Text = "";

            txtEmail.Text = "";

            txtAddress.Text = "";
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonId); // جلب بيانات الشخص

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonId, "Person Not Found");
                this.Close();
                return;
            }

            // تعبئة البيانات في الحقول
            lblPersonID.Text = _PersonId.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gendor == 0) rbMale.Checked = true; else rbFemale.Checked = true;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath; // عرض الصورة
            }
            llRemoveImage.Visible = (_Person.ImagePath != ""); // عرض زر إزالة الصورة حسب الحاجة
        }



        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath); // حذف الصورة القديمة
                    }
                    catch (IOException)
                    {
                        // تجاهل الخطأ حالياً
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile; // تعيين الصورة الجديدة
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!");
                return;
            }

            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            // تعبئة بيانات الشخص من الفورم
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gendor = (short)(rbMale.Checked ? enGendor.Male : enGendor.Female);
            _Person.NationalityCountryID = NationalityCountryID;
            _Person.ImagePath = pbPersonImage.ImageLocation ?? "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.");
                DataBack?.Invoke(this, _Person.PersonID); // إطلاق الحدث بعد الحفظ
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;
            llRemoveImage.Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }
        // تغيير الصورة الافتراضية إذا تم اختيار Male
        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

    }

}
