namespace DVLD.Applications.International_Driving_License
{
    partial class frmManageInternationalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInternationalDrivingLicenseApplication));
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.DGVInternationalLicenseApplications = new System.Windows.Forms.DataGridView();
            this.pnlRecords = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.CMSInternationalLicenseApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewInternationalDrivingLicenseApp = new System.Windows.Forms.Button();
            this.colInternationalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicenseApplications)).BeginInit();
            this.pnlRecords.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.CMSInternationalLicenseApp.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(6, 10);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 30;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // DGVInternationalLicenseApplications
            // 
            this.DGVInternationalLicenseApplications.AllowUserToAddRows = false;
            this.DGVInternationalLicenseApplications.AllowUserToDeleteRows = false;
            this.DGVInternationalLicenseApplications.AllowUserToOrderColumns = true;
            this.DGVInternationalLicenseApplications.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVInternationalLicenseApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInternationalLicenseID,
            this.colSerialNumber,
            this.colApplicationID,
            this.colSep1,
            this.colDriverID,
            this.colNationalNo,
            this.colFullName,
            this.colLicenseID,
            this.colSep2,
            this.colIssueDate,
            this.colExpirationDate,
            this.colIsActive});
            this.DGVInternationalLicenseApplications.Location = new System.Drawing.Point(3, 115);
            this.DGVInternationalLicenseApplications.Name = "DGVInternationalLicenseApplications";
            this.DGVInternationalLicenseApplications.ReadOnly = true;
            this.DGVInternationalLicenseApplications.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVInternationalLicenseApplications.RowHeadersVisible = false;
            this.DGVInternationalLicenseApplications.Size = new System.Drawing.Size(1262, 213);
            this.DGVInternationalLicenseApplications.TabIndex = 29;
            this.DGVInternationalLicenseApplications.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInternationalDrivingLicenseApps_CellDoubleClick);
            this.DGVInternationalLicenseApplications.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVInternationalDrivingLicenseApps_CellMouseDown);
            // 
            // pnlRecords
            // 
            this.pnlRecords.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecords.Controls.Add(this.lblRecords);
            this.pnlRecords.Controls.Add(this.lblSystemRecords);
            this.pnlRecords.Controls.Add(this.lblSystemRecordstxt);
            this.pnlRecords.Controls.Add(this.lblRecordstxt);
            this.pnlRecords.Location = new System.Drawing.Point(23, 335);
            this.pnlRecords.Name = "pnlRecords";
            this.pnlRecords.Size = new System.Drawing.Size(172, 40);
            this.pnlRecords.TabIndex = 28;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(117, 21);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(14, 15);
            this.lblRecords.TabIndex = 7;
            this.lblRecords.Text = "0";
            // 
            // lblSystemRecords
            // 
            this.lblSystemRecords.AutoSize = true;
            this.lblSystemRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblSystemRecords.Location = new System.Drawing.Point(117, 3);
            this.lblSystemRecords.Name = "lblSystemRecords";
            this.lblSystemRecords.Size = new System.Drawing.Size(14, 15);
            this.lblSystemRecords.TabIndex = 0;
            this.lblSystemRecords.Text = "0";
            // 
            // lblSystemRecordstxt
            // 
            this.lblSystemRecordstxt.AutoSize = true;
            this.lblSystemRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblSystemRecordstxt.Location = new System.Drawing.Point(0, 3);
            this.lblSystemRecordstxt.Name = "lblSystemRecordstxt";
            this.lblSystemRecordstxt.Size = new System.Drawing.Size(109, 15);
            this.lblSystemRecordstxt.TabIndex = 0;
            this.lblSystemRecordstxt.Text = "         # All Records: ";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(9, 20);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(99, 15);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.PicBoxRefresh);
            this.pnlFilter.Controls.Add(this.txtBoxFilter);
            this.pnlFilter.Controls.Add(this.CmbBoxFilterBy);
            this.pnlFilter.Controls.Add(this.lblFilterBytxt);
            this.pnlFilter.Location = new System.Drawing.Point(13, 67);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1122, 38);
            this.pnlFilter.TabIndex = 27;
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(1087, 5);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 56;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFilter.Location = new System.Drawing.Point(582, 6);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(499, 23);
            this.txtBoxFilter.TabIndex = 2;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.txtBoxFilter_TextChanged);
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilter_KeyPress);
            // 
            // CmbBoxFilterBy
            // 
            this.CmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxFilterBy.FormattingEnabled = true;
            this.CmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "International LicenseID",
            "Serial Number",
            "DriverID",
            "LicenseID",
            "NationalNo"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(67, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(509, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // CMSInternationalLicenseApp
            // 
            this.CMSInternationalLicenseApp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSInternationalLicenseApp.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSInternationalLicenseApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowDetails,
            this.showLicenseHistoryToolStripMenuItem});
            this.CMSInternationalLicenseApp.Name = "CMSInternationalLicenseApp";
            this.CMSInternationalLicenseApp.Size = new System.Drawing.Size(220, 76);
            // 
            // TSMIShowDetails
            // 
            this.TSMIShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowDetails.Image")));
            this.TSMIShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowDetails.Name = "TSMIShowDetails";
            this.TSMIShowDetails.Size = new System.Drawing.Size(219, 36);
            this.TSMIShowDetails.Tag = "1";
            this.TSMIShowDetails.Text = "Show License";
            this.TSMIShowDetails.Click += new System.EventHandler(this.TSMIShowDetails_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseHistoryToolStripMenuItem.Image")));
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PicBoxClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PicBoxTitleImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1267, 41);
            this.panel2.TabIndex = 49;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(1238, 6);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 46;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            this.PicBoxClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 21);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Manage International Driving License Applications";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(4, 3);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(32, 32);
            this.PicBoxTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitleImage.TabIndex = 45;
            this.PicBoxTitleImage.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(1161, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 54;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewInternationalDrivingLicenseApp
            // 
            this.btnAddNewInternationalDrivingLicenseApp.AutoSize = true;
            this.btnAddNewInternationalDrivingLicenseApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnAddNewInternationalDrivingLicenseApp.FlatAppearance.BorderSize = 2;
            this.btnAddNewInternationalDrivingLicenseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewInternationalDrivingLicenseApp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewInternationalDrivingLicenseApp.ForeColor = System.Drawing.Color.White;
            this.btnAddNewInternationalDrivingLicenseApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewInternationalDrivingLicenseApp.Image")));
            this.btnAddNewInternationalDrivingLicenseApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewInternationalDrivingLicenseApp.Location = new System.Drawing.Point(1141, 65);
            this.btnAddNewInternationalDrivingLicenseApp.Name = "btnAddNewInternationalDrivingLicenseApp";
            this.btnAddNewInternationalDrivingLicenseApp.Size = new System.Drawing.Size(114, 42);
            this.btnAddNewInternationalDrivingLicenseApp.TabIndex = 55;
            this.btnAddNewInternationalDrivingLicenseApp.Tag = "1";
            this.btnAddNewInternationalDrivingLicenseApp.Text = "         Add New";
            this.btnAddNewInternationalDrivingLicenseApp.UseVisualStyleBackColor = false;
            this.btnAddNewInternationalDrivingLicenseApp.Click += new System.EventHandler(this.btnAddNewInternationalDrivingLicenseApp_Click);
            // 
            // colInternationalLicenseID
            // 
            this.colInternationalLicenseID.HeaderText = "International LicenseID";
            this.colInternationalLicenseID.Name = "colInternationalLicenseID";
            this.colInternationalLicenseID.ReadOnly = true;
            this.colInternationalLicenseID.Width = 170;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.HeaderText = "Serial Number";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 130;
            // 
            // colApplicationID
            // 
            this.colApplicationID.HeaderText = "ApplicationID";
            this.colApplicationID.Name = "colApplicationID";
            this.colApplicationID.ReadOnly = true;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 20;
            // 
            // colDriverID
            // 
            this.colDriverID.HeaderText = "DriverID";
            this.colDriverID.Name = "colDriverID";
            this.colDriverID.ReadOnly = true;
            this.colDriverID.Width = 80;
            // 
            // colNationalNo
            // 
            this.colNationalNo.HeaderText = "NationalNo";
            this.colNationalNo.Name = "colNationalNo";
            this.colNationalNo.ReadOnly = true;
            this.colNationalNo.Width = 110;
            // 
            // colFullName
            // 
            this.colFullName.HeaderText = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 200;
            // 
            // colLicenseID
            // 
            this.colLicenseID.HeaderText = "LicenseID";
            this.colLicenseID.Name = "colLicenseID";
            this.colLicenseID.ReadOnly = true;
            this.colLicenseID.Width = 90;
            // 
            // colSep2
            // 
            this.colSep2.HeaderText = "";
            this.colSep2.Name = "colSep2";
            this.colSep2.ReadOnly = true;
            this.colSep2.Width = 20;
            // 
            // colIssueDate
            // 
            this.colIssueDate.HeaderText = "Issue Date";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            this.colIssueDate.Width = 120;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.HeaderText = "Expiration Date";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            this.colExpirationDate.Width = 120;
            // 
            // colIsActive
            // 
            this.colIsActive.HeaderText = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            this.colIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsActive.Width = 80;
            // 
            // frmManageInternationalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 382);
            this.Controls.Add(this.btnAddNewInternationalDrivingLicenseApp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGVInternationalLicenseApplications);
            this.Controls.Add(this.pnlRecords);
            this.Controls.Add(this.pnlFilter);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageInternationalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International Driving License Application";
            this.Load += new System.EventHandler(this.frmManageInternationalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicenseApplications)).EndInit();
            this.pnlRecords.ResumeLayout(false);
            this.pnlRecords.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.CMSInternationalLicenseApp.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.DataGridView DGVInternationalLicenseApplications;
        private System.Windows.Forms.Panel pnlRecords;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.ContextMenuStrip CMSInternationalLicenseApp;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowDetails;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.Button btnAddNewInternationalDrivingLicenseApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternationalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewImageColumn colIsActive;
    }
}