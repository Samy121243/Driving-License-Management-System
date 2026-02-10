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

namespace DVLD
{
    public partial class Manage_Application_Type : Form
    {
        private DataTable _dtAllApplicationTypes;

        public Manage_Application_Type()
        {
            InitializeComponent();
        }

        private void Manage_Application_Type_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.DefaultCellStyle.Font = new Font("Arial", 14);
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);

            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 110;

            dgvApplicationTypes.Columns[1].HeaderText = "Title";
            dgvApplicationTypes.Columns[1].Width = 400;

            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 100;


        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Application_Type frm = new Edit_Application_Type((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            Manage_Application_Type_Load(null, null);
        }
    }
}
