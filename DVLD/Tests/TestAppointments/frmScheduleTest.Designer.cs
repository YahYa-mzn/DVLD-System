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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleTest));
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVAppointments = new System.Windows.Forms.DataGridView();
            this.colTestAppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestAppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsLocked = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Examiner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewImageColumn();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CMSTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMICancel = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMITakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CtrlLocalDrivingLicenseApplicationCard = new DVLD.Applications.Controls.ctrlLocalDrivingLicenseApplicationCard();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.CMSTestAppointment.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnAddNewAppointment.FlatAppearance.BorderSize = 2;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddNewAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewAppointment.Image")));
            this.btnAddNewAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(642, 355);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(133, 40);
            this.btnAddNewAppointment.TabIndex = 49;
            this.btnAddNewAppointment.Tag = "1";
            this.btnAddNewAppointment.Text = "        Appointment";
            this.btnAddNewAppointment.UseVisualStyleBackColor = false;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Appointments";
            // 
            // DGVAppointments
            // 
            this.DGVAppointments.AllowUserToAddRows = false;
            this.DGVAppointments.AllowUserToDeleteRows = false;
            this.DGVAppointments.AllowUserToOrderColumns = true;
            this.DGVAppointments.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTestAppointmentID,
            this.colTestAppointmentDate,
            this.colPaidFees,
            this.colIsLocked,
            this.colSep1,
            this.Examiner,
            this.colResult});
            this.DGVAppointments.Location = new System.Drawing.Point(3, 397);
            this.DGVAppointments.Name = "DGVAppointments";
            this.DGVAppointments.ReadOnly = true;
            this.DGVAppointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVAppointments.RowHeadersVisible = false;
            this.DGVAppointments.Size = new System.Drawing.Size(782, 178);
            this.DGVAppointments.TabIndex = 46;
            this.DGVAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVAppointments_CellMouseDown);
            // 
            // colTestAppointmentID
            // 
            this.colTestAppointmentID.HeaderText = "TestAppointmentID";
            this.colTestAppointmentID.Name = "colTestAppointmentID";
            this.colTestAppointmentID.ReadOnly = true;
            this.colTestAppointmentID.Width = 140;
            // 
            // colTestAppointmentDate
            // 
            this.colTestAppointmentDate.HeaderText = "Date";
            this.colTestAppointmentDate.Name = "colTestAppointmentDate";
            this.colTestAppointmentDate.ReadOnly = true;
            this.colTestAppointmentDate.Width = 120;
            // 
            // colPaidFees
            // 
            this.colPaidFees.HeaderText = "Paid Fees";
            this.colPaidFees.Name = "colPaidFees";
            this.colPaidFees.ReadOnly = true;
            this.colPaidFees.Width = 115;
            // 
            // colIsLocked
            // 
            this.colIsLocked.HeaderText = "Is Locked";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.ReadOnly = true;
            this.colIsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsLocked.Width = 120;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 20;
            // 
            // Examiner
            // 
            this.Examiner.HeaderText = "Examiner";
            this.Examiner.Name = "Examiner";
            this.Examiner.ReadOnly = true;
            this.Examiner.Width = 136;
            // 
            // colResult
            // 
            this.colResult.HeaderText = "Result";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colResult.Width = 110;
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(4, 3);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(32, 32);
            this.PicBoxTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitleImage.TabIndex = 44;
            this.PicBoxTitleImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 27);
            this.panel1.TabIndex = 48;
            // 
            // CMSTestAppointment
            // 
            this.CMSTestAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSTestAppointment.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIEdit,
            this.TSMICancel,
            this.TSMITakeTest});
            this.CMSTestAppointment.Name = "CMSInternationalLicenseApp";
            this.CMSTestAppointment.Size = new System.Drawing.Size(146, 112);
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit.Image")));
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.Size = new System.Drawing.Size(145, 36);
            this.TSMIEdit.Tag = "1";
            this.TSMIEdit.Text = "Edit";
            this.TSMIEdit.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMICancel
            // 
            this.TSMICancel.Image = ((System.Drawing.Image)(resources.GetObject("TSMICancel.Image")));
            this.TSMICancel.Name = "TSMICancel";
            this.TSMICancel.Size = new System.Drawing.Size(145, 36);
            this.TSMICancel.Tag = "2";
            this.TSMICancel.Text = "Cancel";
            this.TSMICancel.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMITakeTest
            // 
            this.TSMITakeTest.Image = ((System.Drawing.Image)(resources.GetObject("TSMITakeTest.Image")));
            this.TSMITakeTest.Name = "TSMITakeTest";
            this.TSMITakeTest.Size = new System.Drawing.Size(145, 36);
            this.TSMITakeTest.Tag = "3";
            this.TSMITakeTest.Text = "Take Test";
            this.TSMITakeTest.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTitle.Controls.Add(this.PicBoxClose);
            this.pnlTitle.Controls.Add(this.lblTitletxt);
            this.pnlTitle.Controls.Add(this.PicBoxTitleImage);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(789, 41);
            this.pnlTitle.TabIndex = 108;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(759, 6);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 58;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            this.PicBoxClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(39, 8);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(190, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "[????] Test Appointment";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // CtrlLocalDrivingLicenseApplicationCard
            // 
            this.CtrlLocalDrivingLicenseApplicationCard.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlLocalDrivingLicenseApplicationCard.Location = new System.Drawing.Point(145, 55);
            this.CtrlLocalDrivingLicenseApplicationCard.Name = "CtrlLocalDrivingLicenseApplicationCard";
            this.CtrlLocalDrivingLicenseApplicationCard.Size = new System.Drawing.Size(634, 289);
            this.CtrlLocalDrivingLicenseApplicationCard.TabIndex = 45;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 587);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.DGVAppointments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CtrlLocalDrivingLicenseApplicationCard);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CMSTestAppointment.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVAppointments;
        private Applications.Controls.ctrlLocalDrivingLicenseApplicationCard CtrlLocalDrivingLicenseApplicationCard;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip CMSTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem TSMITakeTest;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestAppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestAppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidFees;
        private System.Windows.Forms.DataGridViewImageColumn colIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Examiner;
        private System.Windows.Forms.DataGridViewImageColumn colResult;
        private System.Windows.Forms.ToolStripMenuItem TSMICancel;
    }
}