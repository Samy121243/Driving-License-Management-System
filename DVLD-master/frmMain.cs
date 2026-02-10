using DVLD.Applications.Controls;
using DVLD.Applications.International_License;
using DVLD.Applications.Renew_Local_License;
using DVLD.Applications.Rlease_Detained_License;
using DVLD.Classes;
using DVLD.Drivers;
using DVLD.Licenses.LocalLicense;
using DVLD.Login;
using DVLD.People;
using DVLD.Tests;
using DVLD.User;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace DVLD
{

    public partial class frmMain : Form
    {
        login _frmLogin;

        public frmMain(login frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListPeople();
            form.ShowDialog();
            this.Hide();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListUsers();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frmListDrivers = new frmListDrivers();
            frmListDrivers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChange = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frmChange.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Application_Type frm = new Manage_Application_Type();    
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateApplication frmAdd_Update = new frmAdd_UpdateApplication();    
            frmAdd_Update.ShowDialog();
        }

        private void tsMManageApplications_Click(object sender, EventArgs e)
        {
           
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplications frm = new LocalDrivingLicenseApplications();

            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           LocalDrivingLicenseApplications localDrivingLicenseApplications = new LocalDrivingLicenseApplications();
           localDrivingLicenseApplications.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelaseDetaindLicenseApplication frm = new frmRelaseDetaindLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLocalLicense renewLocalLicense = new RenewLocalLicense();
            renewLocalLicense.ShowDialog();
        }

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseList frm = new frmInternationalLicenseList();    
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListDetinedLicense frm = new frmListDetinedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetinLicense frm = new DetinLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelaseDetaindLicenseApplication frm = new frmRelaseDetaindLicenseApplication();
            frm.ShowDialog();
        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }
    }
}
