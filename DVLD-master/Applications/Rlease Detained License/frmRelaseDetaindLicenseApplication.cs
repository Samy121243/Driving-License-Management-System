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

namespace DVLD.Applications.Rlease_Detained_License
{
    public partial class frmRelaseDetaindLicenseApplication : Form
    {
        private int _SelectedLicenseID = -1;
        public frmRelaseDetaindLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRelaseDetaindLicenseApplication_Load(object sender, EventArgs e)
        {

        }
        public frmRelaseDetaindLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrDriverLicenseinfoWithFiltercs1.LoadLicenseInfo(_SelectedLicenseID);
            ctrDriverLicenseinfoWithFiltercs1.FilterEnabled = false;
        }

        private void ctrDriverLicenseinfoWithFiltercs1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (!ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            lblDetainID.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.LicenseID.ToString();

            lblCreatedByUser.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm =
          new frmLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm =
             new frmLicenseHistory(ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrDriverLicenseinfoWithFiltercs1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrDriverLicenseinfoWithFiltercs1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void frmRelaseDetaindLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseinfoWithFiltercs1.txtLicenseIDFocus();
        }
    }
}
