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
    public partial class frmLicenseInfo : Form
    {
        private int _LicenseID;
        public frmLicenseInfo(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfo1.LoadInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
