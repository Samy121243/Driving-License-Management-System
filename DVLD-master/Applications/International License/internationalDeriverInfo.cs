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

namespace DVLD.Applications.International_License
{
    public partial class internationalDeriverInfo : Form
    {
        private int _InternationalLicenseID;
        public internationalDeriverInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = internationalLicenseID;
        }

        private void internationalDeriverInfo_Load(object sender, EventArgs e)
        {
            ctrDriverInternationalLicense1.LoadInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
