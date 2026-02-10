using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLocalDriverLicenseInfo : Form
    {
        private int _ApplicationID = -1;
        public frmLocalDriverLicenseInfo(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmLocalDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_ApplicationID);
        }
    }
}
