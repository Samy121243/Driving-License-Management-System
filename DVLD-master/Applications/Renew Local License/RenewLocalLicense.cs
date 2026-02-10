using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Renew_Local_License
{
    public partial class RenewLocalLicense : Form
    {
        private int _NewLicenseID = -1;
        public RenewLocalLicense()
        {
            InitializeComponent();
        }

        private void RenewLocalLicense_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseinfoWithFiltercs1.txtLicenseIDFocus();


            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm =
              new frmLicenseHistory(ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense =
                ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenewLicense.Enabled = false;
            ctrDriverLicenseinfoWithFiltercs1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;


        }

        private void ctrDriverLicenseinfoWithFiltercs1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            int DefaultValidityLength = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.Notes;


            //check the license is not Expired.
            if (!ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }



            btnRenewLicense.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm =
          new frmLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}
