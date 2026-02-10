using DVLD.Classes;
using DVLD.People;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationId = -1;

        private clsApplication _Application;

        public int ApplicationId
        {
            get { return _ApplicationId; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
            
        }


        public void LoadAppliationInfo(int applicationId)
        {
            _Application = clsApplication.FindBaseApplication(applicationId);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _FillApplicationInfo();
        }
        public void ResetApplicationInfo()
        {
            _ApplicationId = -1;
            lblApplicant.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblDate.Text = "[????]";
            lblFees.Text = "[????]";
            lblStatus.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblType.Text = "[????]";
        }

        private void _FillApplicationInfo()
        {
            _ApplicationId = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frmPerson =  new frmShowPersonInfo(_Application.ApplicantPersonID);
            frmPerson.ShowDialog();

            LoadAppliationInfo(_ApplicationId);
        }
    }
}
