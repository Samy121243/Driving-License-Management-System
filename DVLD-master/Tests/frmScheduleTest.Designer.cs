namespace DVLD.Tests
{
    partial class frmScheduleTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrSchedualeTest1 = new DVLD.Tests.Controls.ctrSchedualeTest();
            this.SuspendLayout();
            // 
            // ctrSchedualeTest1
            // 
            this.ctrSchedualeTest1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctrSchedualeTest1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.861538F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrSchedualeTest1.Location = new System.Drawing.Point(1, -1);
            this.ctrSchedualeTest1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrSchedualeTest1.Name = "ctrSchedualeTest1";
            this.ctrSchedualeTest1.Size = new System.Drawing.Size(714, 725);
            this.ctrSchedualeTest1.TabIndex = 0;
            this.ctrSchedualeTest1.TestTypeID = DVLD_Buisness.clsTestType.enTestType.VisionTest;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(716, 736);
            this.Controls.Add(this.ctrSchedualeTest1);
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrSchedualeTest ctrSchedualeTest1;
    }
}