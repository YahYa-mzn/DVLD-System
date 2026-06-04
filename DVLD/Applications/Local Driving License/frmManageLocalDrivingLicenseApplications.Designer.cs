namespace DVLD.Applications.Local_Driving_License
{
    partial class frmManageLocalDrivingLicenseApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLocalDrivingLicenseApplications));
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.pnlRecordsNumber = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.CmbBoxReadMode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.CmbBoxLicenseClass = new System.Windows.Forms.ComboBox();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.DGVLocalDrivingLicenseApps = new System.Windows.Forms.DataGridView();
            this.colLDAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassedTests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.CMSLocalDrivingLicenseApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMICancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMISchedualeTests = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIScheduleTests_VisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIScheduleTests_WrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIScheduleTests_PracticalTest = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClosefrm = new System.Windows.Forms.PictureBox();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalDrivingLicenseApp = new System.Windows.Forms.Button();
            this.lblShowtxt = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.TSMIReactivateApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRecordsNumber.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicenseApps)).BeginInit();
            this.CMSLocalDrivingLicenseApp.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClosefrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(330, 72);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 19;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // pnlRecordsNumber
            // 
            this.pnlRecordsNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRecordsNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecordsNumber.Controls.Add(this.lblRecords);
            this.pnlRecordsNumber.Controls.Add(this.lblSystemRecords);
            this.pnlRecordsNumber.Controls.Add(this.lblSystemRecordstxt);
            this.pnlRecordsNumber.Controls.Add(this.lblRecordstxt);
            this.pnlRecordsNumber.Location = new System.Drawing.Point(13, 374);
            this.pnlRecordsNumber.Name = "pnlRecordsNumber";
            this.pnlRecordsNumber.Size = new System.Drawing.Size(172, 40);
            this.pnlRecordsNumber.TabIndex = 22;
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
            this.lblSystemRecordstxt.Location = new System.Drawing.Point(-6, 3);
            this.lblSystemRecordstxt.Name = "lblSystemRecordstxt";
            this.lblSystemRecordstxt.Size = new System.Drawing.Size(116, 15);
            this.lblSystemRecordstxt.TabIndex = 0;
            this.lblSystemRecordstxt.Text = "   # System Records: ";
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
            // CmbBoxReadMode
            // 
            this.CmbBoxReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxReadMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxReadMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxReadMode.FormattingEnabled = true;
            this.CmbBoxReadMode.Items.AddRange(new object[] {
            "None",
            "New",
            "Canceled",
            "Completed"});
            this.CmbBoxReadMode.Location = new System.Drawing.Point(47, 5);
            this.CmbBoxReadMode.Name = "CmbBoxReadMode";
            this.CmbBoxReadMode.Size = new System.Drawing.Size(243, 25);
            this.CmbBoxReadMode.TabIndex = 16;
            this.CmbBoxReadMode.Tag = "";
            this.CmbBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.CmbBoxReadMode_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxFilter);
            this.panel1.Controls.Add(this.CmbBoxFilterBy);
            this.panel1.Controls.Add(this.CmbBoxLicenseClass);
            this.panel1.Controls.Add(this.PicBoxRefresh);
            this.panel1.Controls.Add(this.CmbBoxReadMode);
            this.panel1.Location = new System.Drawing.Point(11, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 38);
            this.panel1.TabIndex = 20;
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Enabled = false;
            this.txtBoxFilter.Location = new System.Drawing.Point(622, 5);
            this.txtBoxFilter.Multiline = true;
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(301, 25);
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
            "L.D.L AppID ",
            "NationalNo",
            "LicenseClass"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(379, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(235, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // CmbBoxLicenseClass
            // 
            this.CmbBoxLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxLicenseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxLicenseClass.FormattingEnabled = true;
            this.CmbBoxLicenseClass.Location = new System.Drawing.Point(622, 5);
            this.CmbBoxLicenseClass.Name = "CmbBoxLicenseClass";
            this.CmbBoxLicenseClass.Size = new System.Drawing.Size(298, 25);
            this.CmbBoxLicenseClass.TabIndex = 3;
            this.CmbBoxLicenseClass.Visible = false;
            this.CmbBoxLicenseClass.SelectedIndexChanged += new System.EventHandler(this.CmbBoxLicenseClass_SelectedIndexChanged);
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(929, 4);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 57;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // DGVLocalDrivingLicenseApps
            // 
            this.DGVLocalDrivingLicenseApps.AllowUserToAddRows = false;
            this.DGVLocalDrivingLicenseApps.AllowUserToDeleteRows = false;
            this.DGVLocalDrivingLicenseApps.AllowUserToOrderColumns = true;
            this.DGVLocalDrivingLicenseApps.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVLocalDrivingLicenseApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLDAppID,
            this.colLicenseClass,
            this.colSep1,
            this.colNationalNo,
            this.colFullName,
            this.colSep2,
            this.colApplicationDate,
            this.colPassedTests,
            this.colStatus});
            this.DGVLocalDrivingLicenseApps.Location = new System.Drawing.Point(2, 112);
            this.DGVLocalDrivingLicenseApps.Name = "DGVLocalDrivingLicenseApps";
            this.DGVLocalDrivingLicenseApps.ReadOnly = true;
            this.DGVLocalDrivingLicenseApps.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVLocalDrivingLicenseApps.RowHeadersVisible = false;
            this.DGVLocalDrivingLicenseApps.Size = new System.Drawing.Size(1101, 256);
            this.DGVLocalDrivingLicenseApps.TabIndex = 15;
            this.DGVLocalDrivingLicenseApps.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVLocalDrivingLicenseApps_CellDoubleClick);
            this.DGVLocalDrivingLicenseApps.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVLocalDrivingLicenseApps_CellMouseDown);
            // 
            // colLDAppID
            // 
            this.colLDAppID.HeaderText = "L.D.L. AppID";
            this.colLDAppID.Name = "colLDAppID";
            this.colLDAppID.ReadOnly = true;
            this.colLDAppID.Width = 120;
            // 
            // colLicenseClass
            // 
            this.colLicenseClass.HeaderText = "License Class";
            this.colLicenseClass.Name = "colLicenseClass";
            this.colLicenseClass.ReadOnly = true;
            this.colLicenseClass.Width = 200;
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
            this.colNationalNo.Width = 140;
            // 
            // colFullName
            // 
            this.colFullName.HeaderText = "FullName";
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
            // colApplicationDate
            // 
            this.colApplicationDate.HeaderText = "Application Date";
            this.colApplicationDate.Name = "colApplicationDate";
            this.colApplicationDate.ReadOnly = true;
            this.colApplicationDate.Width = 150;
            // 
            // colPassedTests
            // 
            this.colPassedTests.HeaderText = "Passed Tests";
            this.colPassedTests.Name = "colPassedTests";
            this.colPassedTests.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.Width = 130;
            // 
            // CMSLocalDrivingLicenseApp
            // 
            this.CMSLocalDrivingLicenseApp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSLocalDrivingLicenseApp.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSLocalDrivingLicenseApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowDetails,
            this.toolStripMenuItem1,
            this.TSMIReactivateApplication,
            this.TSMICancelApplication,
            this.TSMIDeleteApplication,
            this.toolStripMenuItem2,
            this.TSMISchedualeTests,
            this.TSMIIssueDrivingLicense,
            this.toolStripMenuItem3,
            this.TSMIShowLicense,
            this.TSMIShowPersonLicenseHistory});
            this.CMSLocalDrivingLicenseApp.Name = "CMSInternationalLicenseApp";
            this.CMSLocalDrivingLicenseApp.Size = new System.Drawing.Size(283, 310);
            this.CMSLocalDrivingLicenseApp.Opening += new System.ComponentModel.CancelEventHandler(this.CMSLocalDrivingLicenseApp_Opening);
            // 
            // TSMIShowDetails
            // 
            this.TSMIShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowDetails.Image")));
            this.TSMIShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowDetails.Name = "TSMIShowDetails";
            this.TSMIShowDetails.Size = new System.Drawing.Size(282, 36);
            this.TSMIShowDetails.Tag = "1";
            this.TSMIShowDetails.Text = "Show Details";
            this.TSMIShowDetails.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(279, 6);
            // 
            // TSMICancelApplication
            // 
            this.TSMICancelApplication.Image = ((System.Drawing.Image)(resources.GetObject("TSMICancelApplication.Image")));
            this.TSMICancelApplication.Name = "TSMICancelApplication";
            this.TSMICancelApplication.Size = new System.Drawing.Size(282, 36);
            this.TSMICancelApplication.Tag = "3";
            this.TSMICancelApplication.Text = "Cancel Application";
            this.TSMICancelApplication.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMIDeleteApplication
            // 
            this.TSMIDeleteApplication.Image = ((System.Drawing.Image)(resources.GetObject("TSMIDeleteApplication.Image")));
            this.TSMIDeleteApplication.Name = "TSMIDeleteApplication";
            this.TSMIDeleteApplication.Size = new System.Drawing.Size(282, 36);
            this.TSMIDeleteApplication.Tag = "4";
            this.TSMIDeleteApplication.Text = "Delete Application";
            this.TSMIDeleteApplication.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(279, 6);
            // 
            // TSMISchedualeTests
            // 
            this.TSMISchedualeTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIScheduleTests_VisionTest,
            this.TSMIScheduleTests_WrittenTest,
            this.TSMIScheduleTests_PracticalTest});
            this.TSMISchedualeTests.Image = ((System.Drawing.Image)(resources.GetObject("TSMISchedualeTests.Image")));
            this.TSMISchedualeTests.Name = "TSMISchedualeTests";
            this.TSMISchedualeTests.Size = new System.Drawing.Size(282, 36);
            this.TSMISchedualeTests.Text = "Schedule/Take Tests";
            // 
            // TSMIScheduleTests_VisionTest
            // 
            this.TSMIScheduleTests_VisionTest.Image = ((System.Drawing.Image)(resources.GetObject("TSMIScheduleTests_VisionTest.Image")));
            this.TSMIScheduleTests_VisionTest.Name = "TSMIScheduleTests_VisionTest";
            this.TSMIScheduleTests_VisionTest.Size = new System.Drawing.Size(168, 36);
            this.TSMIScheduleTests_VisionTest.Tag = "1";
            this.TSMIScheduleTests_VisionTest.Text = "Vision Test";
            this.TSMIScheduleTests_VisionTest.Click += new System.EventHandler(this.TSMISchedule_TakeTest_Click);
            // 
            // TSMIScheduleTests_WrittenTest
            // 
            this.TSMIScheduleTests_WrittenTest.Image = ((System.Drawing.Image)(resources.GetObject("TSMIScheduleTests_WrittenTest.Image")));
            this.TSMIScheduleTests_WrittenTest.Name = "TSMIScheduleTests_WrittenTest";
            this.TSMIScheduleTests_WrittenTest.Size = new System.Drawing.Size(168, 36);
            this.TSMIScheduleTests_WrittenTest.Tag = "2";
            this.TSMIScheduleTests_WrittenTest.Text = "Written Test";
            this.TSMIScheduleTests_WrittenTest.Click += new System.EventHandler(this.TSMISchedule_TakeTest_Click);
            // 
            // TSMIScheduleTests_PracticalTest
            // 
            this.TSMIScheduleTests_PracticalTest.Image = ((System.Drawing.Image)(resources.GetObject("TSMIScheduleTests_PracticalTest.Image")));
            this.TSMIScheduleTests_PracticalTest.Name = "TSMIScheduleTests_PracticalTest";
            this.TSMIScheduleTests_PracticalTest.Size = new System.Drawing.Size(168, 36);
            this.TSMIScheduleTests_PracticalTest.Tag = "3";
            this.TSMIScheduleTests_PracticalTest.Text = "Practical Test";
            this.TSMIScheduleTests_PracticalTest.Click += new System.EventHandler(this.TSMISchedule_TakeTest_Click);
            // 
            // TSMIIssueDrivingLicense
            // 
            this.TSMIIssueDrivingLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIIssueDrivingLicense.Image")));
            this.TSMIIssueDrivingLicense.Name = "TSMIIssueDrivingLicense";
            this.TSMIIssueDrivingLicense.Size = new System.Drawing.Size(282, 36);
            this.TSMIIssueDrivingLicense.Tag = "5";
            this.TSMIIssueDrivingLicense.Text = "Issue Driving License (FirstTime)";
            this.TSMIIssueDrivingLicense.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(279, 6);
            // 
            // TSMIShowLicense
            // 
            this.TSMIShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowLicense.Image")));
            this.TSMIShowLicense.Name = "TSMIShowLicense";
            this.TSMIShowLicense.Size = new System.Drawing.Size(282, 36);
            this.TSMIShowLicense.Tag = "6";
            this.TSMIShowLicense.Text = "Show License";
            this.TSMIShowLicense.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMIShowPersonLicenseHistory
            // 
            this.TSMIShowPersonLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowPersonLicenseHistory.Image")));
            this.TSMIShowPersonLicenseHistory.Name = "TSMIShowPersonLicenseHistory";
            this.TSMIShowPersonLicenseHistory.Size = new System.Drawing.Size(282, 36);
            this.TSMIShowPersonLicenseHistory.Tag = "7";
            this.TSMIShowPersonLicenseHistory.Text = "Show License History";
            this.TSMIShowPersonLicenseHistory.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PicBoxClosefrm);
            this.panel2.Controls.Add(this.PicBoxClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PicBoxTitleImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1105, 42);
            this.panel2.TabIndex = 50;
            // 
            // PicBoxClosefrm
            // 
            this.PicBoxClosefrm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClosefrm.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClosefrm.Image")));
            this.PicBoxClosefrm.Location = new System.Drawing.Point(1076, 7);
            this.PicBoxClosefrm.Name = "PicBoxClosefrm";
            this.PicBoxClosefrm.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClosefrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClosefrm.TabIndex = 47;
            this.PicBoxClosefrm.TabStop = false;
            this.PicBoxClosefrm.Tag = "2";
            this.PicBoxClosefrm.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(1156, 7);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 46;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 21);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Manage Local Driving License Applications";
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
            // btnAddNewLocalDrivingLicenseApp
            // 
            this.btnAddNewLocalDrivingLicenseApp.AutoSize = true;
            this.btnAddNewLocalDrivingLicenseApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnAddNewLocalDrivingLicenseApp.FlatAppearance.BorderSize = 2;
            this.btnAddNewLocalDrivingLicenseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalDrivingLicenseApp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLocalDrivingLicenseApp.ForeColor = System.Drawing.Color.White;
            this.btnAddNewLocalDrivingLicenseApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewLocalDrivingLicenseApp.Image")));
            this.btnAddNewLocalDrivingLicenseApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewLocalDrivingLicenseApp.Location = new System.Drawing.Point(981, 60);
            this.btnAddNewLocalDrivingLicenseApp.Name = "btnAddNewLocalDrivingLicenseApp";
            this.btnAddNewLocalDrivingLicenseApp.Size = new System.Drawing.Size(114, 42);
            this.btnAddNewLocalDrivingLicenseApp.TabIndex = 51;
            this.btnAddNewLocalDrivingLicenseApp.Tag = "1";
            this.btnAddNewLocalDrivingLicenseApp.Text = "         Add New";
            this.btnAddNewLocalDrivingLicenseApp.UseVisualStyleBackColor = false;
            this.btnAddNewLocalDrivingLicenseApp.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApp_Click);
            // 
            // lblShowtxt
            // 
            this.lblShowtxt.AutoSize = true;
            this.lblShowtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblShowtxt.Location = new System.Drawing.Point(15, 72);
            this.lblShowtxt.Name = "lblShowtxt";
            this.lblShowtxt.Size = new System.Drawing.Size(41, 17);
            this.lblShowtxt.TabIndex = 52;
            this.lblShowtxt.Text = "Show";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1002, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Tag = "2";
            this.btnCancel.Text = "   Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TSMIReactivateApplication
            // 
            this.TSMIReactivateApplication.Image = ((System.Drawing.Image)(resources.GetObject("TSMIReactivateApplication.Image")));
            this.TSMIReactivateApplication.Name = "TSMIReactivateApplication";
            this.TSMIReactivateApplication.Size = new System.Drawing.Size(282, 36);
            this.TSMIReactivateApplication.Tag = "2";
            this.TSMIReactivateApplication.Text = "Reactivate Application";
            this.TSMIReactivateApplication.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // frmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 419);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblShowtxt);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblFilterBytxt);
            this.Controls.Add(this.pnlRecordsNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVLocalDrivingLicenseApps);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            this.pnlRecordsNumber.ResumeLayout(false);
            this.pnlRecordsNumber.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicenseApps)).EndInit();
            this.CMSLocalDrivingLicenseApp.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClosefrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.Panel pnlRecordsNumber;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.ComboBox CmbBoxReadMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.DataGridView DGVLocalDrivingLicenseApps;
        private System.Windows.Forms.ContextMenuStrip CMSLocalDrivingLicenseApp;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMICancelApplication;
        private System.Windows.Forms.ToolStripMenuItem TSMIDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TSMISchedualeTests;
        private System.Windows.Forms.ToolStripMenuItem TSMIIssueDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowLicense;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem TSMIScheduleTests_VisionTest;
        private System.Windows.Forms.ToolStripMenuItem TSMIScheduleTests_WrittenTest;
        private System.Windows.Forms.ToolStripMenuItem TSMIScheduleTests_PracticalTest;
        private System.Windows.Forms.ComboBox CmbBoxLicenseClass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApp;
        private System.Windows.Forms.Label lblShowtxt;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox PicBoxClosefrm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLDAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassedTests;
        private System.Windows.Forms.DataGridViewImageColumn colStatus;
        private System.Windows.Forms.ToolStripMenuItem TSMIReactivateApplication;
    }
}