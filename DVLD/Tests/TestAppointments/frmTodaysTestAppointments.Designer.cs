namespace DVLD.Tests.TestAppointments
{
    partial class frmTodaysTestAppointments
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTodaysTestAppointments));
            this.DGVTodaysTestAppointments = new System.Windows.Forms.DataGridView();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblAppointmentstxt = new System.Windows.Forms.Label();
            this.CmbBoxReadMode = new System.Windows.Forms.ComboBox();
            this.CMSTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMITakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.pnlRecordsCount = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.colTestAppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsLocked = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSep3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExaminer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTodaysTestAppointments)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.pnlAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.CMSTestAppointment.SuspendLayout();
            this.pnlRecordsCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVTodaysTestAppointments
            // 
            this.DGVTodaysTestAppointments.AllowUserToAddRows = false;
            this.DGVTodaysTestAppointments.AllowUserToDeleteRows = false;
            this.DGVTodaysTestAppointments.AllowUserToOrderColumns = true;
            this.DGVTodaysTestAppointments.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVTodaysTestAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTestAppointmentID,
            this.colSep1,
            this.colNationalNo,
            this.colFullName,
            this.colSep2,
            this.colPaidFees,
            this.colIsLocked,
            this.colSep3,
            this.colExaminer,
            this.colResult});
            this.DGVTodaysTestAppointments.Location = new System.Drawing.Point(2, 110);
            this.DGVTodaysTestAppointments.Name = "DGVTodaysTestAppointments";
            this.DGVTodaysTestAppointments.ReadOnly = true;
            this.DGVTodaysTestAppointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVTodaysTestAppointments.Size = new System.Drawing.Size(1005, 215);
            this.DGVTodaysTestAppointments.TabIndex = 48;
            this.DGVTodaysTestAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTodaysTestAppointments_CellMouseDown);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Controls.Add(this.lblTitletxt);
            this.pnlTitle.Controls.Add(this.PicBoxTitleImage);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1009, 40);
            this.pnlTitle.TabIndex = 47;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(980, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(34, 8);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(214, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Today\'s Test Appointments";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(7, 6);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(24, 24);
            this.PicBoxTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitleImage.TabIndex = 45;
            this.PicBoxTitleImage.TabStop = false;
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAppointments.Controls.Add(this.pictureBox2);
            this.pnlAppointments.Controls.Add(this.lblAppointmentstxt);
            this.pnlAppointments.Controls.Add(this.CmbBoxReadMode);
            this.pnlAppointments.Location = new System.Drawing.Point(17, 63);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(969, 37);
            this.pnlAppointments.TabIndex = 49;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(930, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.picBoxRefresh_Click);
            // 
            // lblAppointmentstxt
            // 
            this.lblAppointmentstxt.AutoSize = true;
            this.lblAppointmentstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblAppointmentstxt.Location = new System.Drawing.Point(8, 9);
            this.lblAppointmentstxt.Name = "lblAppointmentstxt";
            this.lblAppointmentstxt.Size = new System.Drawing.Size(99, 17);
            this.lblAppointmentstxt.TabIndex = 47;
            this.lblAppointmentstxt.Text = "Filter by Status";
            // 
            // CmbBoxReadMode
            // 
            this.CmbBoxReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxReadMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxReadMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.CmbBoxReadMode.FormattingEnabled = true;
            this.CmbBoxReadMode.Items.AddRange(new object[] {
            "All Appointments",
            "Completed",
            "Pending"});
            this.CmbBoxReadMode.Location = new System.Drawing.Point(112, 5);
            this.CmbBoxReadMode.Name = "CmbBoxReadMode";
            this.CmbBoxReadMode.Size = new System.Drawing.Size(809, 25);
            this.CmbBoxReadMode.TabIndex = 53;
            this.CmbBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.CmbBoxReadMode_SelectedIndexChanged);
            // 
            // CMSTestAppointment
            // 
            this.CMSTestAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSTestAppointment.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIEdit,
            this.TSMITakeTest});
            this.CMSTestAppointment.Name = "CMSInternationalLicenseApp";
            this.CMSTestAppointment.Size = new System.Drawing.Size(146, 76);
            this.CMSTestAppointment.Opening += new System.ComponentModel.CancelEventHandler(this.CMSTestAppointment_Opening);
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit.Image")));
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.Size = new System.Drawing.Size(145, 36);
            this.TSMIEdit.Tag = "1";
            this.TSMIEdit.Text = "Edit";
            this.TSMIEdit.Click += new System.EventHandler(this.TSMIEdit_Click);
            // 
            // TSMITakeTest
            // 
            this.TSMITakeTest.Image = ((System.Drawing.Image)(resources.GetObject("TSMITakeTest.Image")));
            this.TSMITakeTest.Name = "TSMITakeTest";
            this.TSMITakeTest.Size = new System.Drawing.Size(145, 36);
            this.TSMITakeTest.Tag = "2";
            this.TSMITakeTest.Text = "Take Test";
            this.TSMITakeTest.Click += new System.EventHandler(this.TSMITakeTest_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(97, 4);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(13, 13);
            this.lblRecords.TabIndex = 7;
            this.lblRecords.Text = "0";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(4, 4);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(98, 13);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // pnlRecordsCount
            // 
            this.pnlRecordsCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecordsCount.Controls.Add(this.lblRecords);
            this.pnlRecordsCount.Controls.Add(this.lblRecordstxt);
            this.pnlRecordsCount.Location = new System.Drawing.Point(29, 333);
            this.pnlRecordsCount.Name = "pnlRecordsCount";
            this.pnlRecordsCount.Size = new System.Drawing.Size(131, 23);
            this.pnlRecordsCount.TabIndex = 54;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(893, 331);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 56;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colTestAppointmentID
            // 
            this.colTestAppointmentID.HeaderText = "Test AppointmentID";
            this.colTestAppointmentID.Name = "colTestAppointmentID";
            this.colTestAppointmentID.ReadOnly = true;
            this.colTestAppointmentID.Width = 155;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 20;
            // 
            // colNationalNo
            // 
            this.colNationalNo.HeaderText = "NationalNo";
            this.colNationalNo.Name = "colNationalNo";
            this.colNationalNo.ReadOnly = true;
            this.colNationalNo.Width = 90;
            // 
            // colFullName
            // 
            this.colFullName.HeaderText = "Full Name";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 200;
            // 
            // colSep2
            // 
            this.colSep2.HeaderText = "";
            this.colSep2.Name = "colSep2";
            this.colSep2.ReadOnly = true;
            this.colSep2.Width = 20;
            // 
            // colPaidFees
            // 
            this.colPaidFees.HeaderText = "Paid Fees";
            this.colPaidFees.Name = "colPaidFees";
            this.colPaidFees.ReadOnly = true;
            this.colPaidFees.Width = 90;
            // 
            // colIsLocked
            // 
            this.colIsLocked.HeaderText = "Is Locked";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.ReadOnly = true;
            this.colIsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsLocked.Width = 90;
            // 
            // colSep3
            // 
            this.colSep3.HeaderText = "";
            this.colSep3.Name = "colSep3";
            this.colSep3.ReadOnly = true;
            this.colSep3.Width = 20;
            // 
            // colExaminer
            // 
            this.colExaminer.HeaderText = "Examiner";
            this.colExaminer.Name = "colExaminer";
            this.colExaminer.ReadOnly = true;
            this.colExaminer.Width = 130;
            // 
            // colResult
            // 
            this.colResult.HeaderText = "Result";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colResult.Width = 130;
            // 
            // frmTodaysTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 366);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlRecordsCount);
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.DGVTodaysTestAppointments);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTodaysTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Test Appointments";
            this.Load += new System.EventHandler(this.frmTodaysTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTodaysTestAppointments)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.CMSTestAppointment.ResumeLayout(false);
            this.pnlRecordsCount.ResumeLayout(false);
            this.pnlRecordsCount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVTodaysTestAppointments;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Panel pnlAppointments;
        private System.Windows.Forms.Label lblAppointmentstxt;
        private System.Windows.Forms.ContextMenuStrip CMSTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem TSMITakeTest;
        private System.Windows.Forms.ComboBox CmbBoxReadMode;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Panel pnlRecordsCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestAppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidFees;
        private System.Windows.Forms.DataGridViewImageColumn colIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExaminer;
        private System.Windows.Forms.DataGridViewImageColumn colResult;
    }
}