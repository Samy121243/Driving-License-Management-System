using DVLD_Buisness;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.Tests.Test_Types;

namespace DVLD.Tests
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.CurrentRow == null)
                return;

            var selectedTestTypeID = (clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value;

            Edit_Test_Type frm = new Edit_Test_Type(selectedTestTypeID);
            frm.ShowDialog();

            frmListTestTypes_Load_1(null, null); // Refresh
        }

        private void frmListTestTypes_Load_1(object sender, EventArgs e)
        {
            dgvTestTypes.DefaultCellStyle.Font = new Font("Arial", 14);
            dgvTestTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Bold);

            dgvTestTypes.ReadOnly = true;
            dgvTestTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTestTypes.AllowUserToAddRows = false;
            dgvTestTypes.RowHeadersVisible = false;

            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = dgvTestTypes.RowCount.ToString();

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 120;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 200;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
        }
    }
}
