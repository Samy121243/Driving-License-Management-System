using DVLD.Classes;
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

namespace DVLD.Login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if(!User.IsActive)
            {
                txtUserName.Focus();
                MessageBox.Show("The User Is Not Active ,please call the Admin ");
                return;
            }


            if (User != null)
            {
                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
               
            }
           
        }
    }
}
