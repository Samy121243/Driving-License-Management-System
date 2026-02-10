using DVLD.Properties;
using DVLD_Buisness;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlUserCard : UserControl
    {
       private clsUser _User;

        private int _UserId = -1;

        public int UserId
        {
            get { return _UserId; }
        }


        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserId)
        {
            _User = clsUser.FindByPersonID(UserId);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }


        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }

        private void _ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }


    }
}
