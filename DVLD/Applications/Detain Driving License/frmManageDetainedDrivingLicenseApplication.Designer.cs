namespace DVLD.Applications.Detain_Driving_License
{
    partial class frmManageDetainedDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDetainedDrivingLicenseApplication));
            this.btnNewDetainedLicense = new System.Windows.Forms.Button();
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.DGVDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.pnlRecords = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.lblShowtxt = new System.Windows.Forms.Label();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.CmbBoxReadMode = new System.Windows.Forms.ComboBox();
            this.CMSDetainedLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIShowLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISep = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.colDetainedLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFineFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsReleased = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReleaseApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicenses)).BeginInit();
            this.pnlRecords.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.CMSDetainedLicense.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewDetainedLicense
            // 
            this.btnNewDetainedLicense.AutoSize = true;
            this.btnNewDetainedLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnNewDetainedLicense.FlatAppearance.BorderSize = 2;
            this.btnNewDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDetainedLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDetainedLicense.ForeColor = System.Drawing.Color.White;
            this.btnNewDetainedLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDetainedLicense.Image")));
            this.btnNewDetainedLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDetainedLicense.Location = new System.Drawing.Point(1211, 69);
            this.btnNewDetainedLicense.Name = "btnNewDetainedLicense";
            this.btnNewDetainedLicense.Size = new System.Drawing.Size(114, 42);
            this.btnNewDetainedLicense.TabIndex = 37;
            this.btnNewDetainedLicense.Tag = "1";
            this.btnNewDetainedLicense.Text = "         Add New";
            this.btnNewDetainedLicense.UseVisualStyleBackColor = false;
            this.btnNewDetainedLicense.Click += new System.EventHandler(this.btnNewDetainedLicense_Click);
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(408, 9);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 36;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // DGVDetainedLicenses
            // 
            this.DGVDetainedLicenses.AllowUserToAddRows = false;
            this.DGVDetainedLicenses.AllowUserToDeleteRows = false;
            this.DGVDetainedLicenses.AllowUserToOrderColumns = true;
            this.DGVDetainedLicenses.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVDetainedLicenses.CausesValidation = false;
            this.DGVDetainedLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetainedLicenseID,
            this.colLicenseID,
            this.colSerialNumber,
            this.colNationalNo,
            this.colFullName,
            this.colDetainDate,
            this.colFineFees,
            this.colSep1,
            this.colIsReleased,
            this.colSep2,
            this.colReleaseApplicationID,
            this.colReleaseDate});
            this.DGVDetainedLicenses.Location = new System.Drawing.Point(2, 124);
            this.DGVDetainedLicenses.Name = "DGVDetainedLicenses";
            this.DGVDetainedLicenses.ReadOnly = true;
            this.DGVDetainedLicenses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVDetainedLicenses.RowHeadersVisible = false;
            this.DGVDetainedLicenses.Size = new System.Drawing.Size(1341, 299);
            this.DGVDetainedLicenses.TabIndex = 35;
            this.DGVDetainedLicenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetainedLicenses_CellContentClick);
            this.DGVDetainedLicenses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetainedLicenses_CellDoubleClick);
            this.DGVDetainedLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVDetainedLicenses_CellMouseDown);
            // 
            // pnlRecords
            // 
            this.pnlRecords.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecords.Controls.Add(this.lblRecords);
            this.pnlRecords.Controls.Add(this.lblSystemRecords);
            this.pnlRecords.Controls.Add(this.lblSystemRecordstxt);
            this.pnlRecords.Controls.Add(this.lblRecordstxt);
            this.pnlRecords.Location = new System.Drawing.Point(16, 429);
            this.pnlRecords.Name = "pnlRecords";
            this.pnlRecords.Size = new System.Drawing.Size(183, 39);
            this.pnlRecords.TabIndex = 34;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(129, 20);
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
            this.lblSystemRecords.Location = new System.Drawing.Point(129, 3);
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
            this.lblSystemRecordstxt.Location = new System.Drawing.Point(5, 3);
            this.lblSystemRecordstxt.Name = "lblSystemRecordstxt";
            this.lblSystemRecordstxt.Size = new System.Drawing.Size(113, 15);
            this.lblSystemRecordstxt.TabIndex = 0;
            this.lblSystemRecordstxt.Text = "   # System Records:";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(21, 19);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(99, 15);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.PicBoxRefresh);
            this.pnlFilter.Controls.Add(this.lblShowtxt);
            this.pnlFilter.Controls.Add(this.txtBoxFilter);
            this.pnlFilter.Controls.Add(this.CmbBoxFilterBy);
            this.pnlFilter.Controls.Add(this.CmbBoxReadMode);
            this.pnlFilter.Controls.Add(this.lblFilterBytxt);
            this.pnlFilter.Location = new System.Drawing.Point(13, 71);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1192, 38);
            this.pnlFilter.TabIndex = 33;
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(1158, 5);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 57;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // lblShowtxt
            // 
            this.lblShowtxt.AutoSize = true;
            this.lblShowtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblShowtxt.Location = new System.Drawing.Point(3, 9);
            this.lblShowtxt.Name = "lblShowtxt";
            this.lblShowtxt.Size = new System.Drawing.Size(41, 17);
            this.lblShowtxt.TabIndex = 58;
            this.lblShowtxt.Text = "Show";
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtBoxFilter.Location = new System.Drawing.Point(804, 7);
            this.txtBoxFilter.Multiline = true;
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(348, 23);
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
            "DetainedLicenseID",
            "LicenseID",
            "InternationalSerialNumber",
            "NationalNo"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(468, 6);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(330, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // CmbBoxReadMode
            // 
            this.CmbBoxReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxReadMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxReadMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxReadMode.FormattingEnabled = true;
            this.CmbBoxReadMode.Items.AddRange(new object[] {
            "None",
            "Detained",
            "Released"});
            this.CmbBoxReadMode.Location = new System.Drawing.Point(47, 6);
            this.CmbBoxReadMode.Name = "CmbBoxReadMode";
            this.CmbBoxReadMode.Size = new System.Drawing.Size(315, 25);
            this.CmbBoxReadMode.TabIndex = 38;
            this.CmbBoxReadMode.Tag = "";
            this.CmbBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.CmbBoxReadMode_SelectedIndexChanged);
            // 
            // CMSDetainedLicense
            // 
            this.CMSDetainedLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSDetainedLicense.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSDetainedLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowLicense,
            this.TSMIShowLicenseHistory,
            this.TSMISep,
            this.TSMIReleaseDetainedLicense});
            this.CMSDetainedLicense.Name = "CMSInternationalLicenseApp";
            this.CMSDetainedLicense.Size = new System.Drawing.Size(241, 118);
            this.CMSDetainedLicense.Opening += new System.ComponentModel.CancelEventHandler(this.CMSDetainedLicense_Opening);
            // 
            // TSMIShowLicense
            // 
            this.TSMIShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowLicense.Image")));
            this.TSMIShowLicense.Name = "TSMIShowLicense";
            this.TSMIShowLicense.Size = new System.Drawing.Size(240, 36);
            this.TSMIShowLicense.Tag = "1";
            this.TSMIShowLicense.Text = "Show License";
            this.TSMIShowLicense.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMIShowLicenseHistory
            // 
            this.TSMIShowLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowLicenseHistory.Image")));
            this.TSMIShowLicenseHistory.Name = "TSMIShowLicenseHistory";
            this.TSMIShowLicenseHistory.Size = new System.Drawing.Size(240, 36);
            this.TSMIShowLicenseHistory.Tag = "2";
            this.TSMIShowLicenseHistory.Text = "Show License History";
            this.TSMIShowLicenseHistory.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // TSMISep
            // 
            this.TSMISep.Name = "TSMISep";
            this.TSMISep.Size = new System.Drawing.Size(237, 6);
            // 
            // TSMIReleaseDetainedLicense
            // 
            this.TSMIReleaseDetainedLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIReleaseDetainedLicense.Image")));
            this.TSMIReleaseDetainedLicense.Name = "TSMIReleaseDetainedLicense";
            this.TSMIReleaseDetainedLicense.Size = new System.Drawing.Size(240, 36);
            this.TSMIReleaseDetainedLicense.Tag = "3";
            this.TSMIReleaseDetainedLicense.Text = "Release Detained License";
            this.TSMIReleaseDetainedLicense.Click += new System.EventHandler(this.TSMI_Click);
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
            this.panel2.Size = new System.Drawing.Size(1345, 42);
            this.panel2.TabIndex = 50;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(1316, 7);
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
            this.label1.Size = new System.Drawing.Size(367, 21);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Manage Detained Driving License Applications";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(5, 3);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(33, 32);
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
            this.btnClose.Location = new System.Drawing.Point(1235, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 55;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colDetainedLicenseID
            // 
            this.colDetainedLicenseID.HeaderText = "Detained LicenseID";
            this.colDetainedLicenseID.Name = "colDetainedLicenseID";
            this.colDetainedLicenseID.ReadOnly = true;
            this.colDetainedLicenseID.Width = 150;
            // 
            // colLicenseID
            // 
            this.colLicenseID.HeaderText = "LicenseID";
            this.colLicenseID.Name = "colLicenseID";
            this.colLicenseID.ReadOnly = true;
            this.colLicenseID.Width = 80;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.HeaderText = "Serial Number";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 125;
            // 
            // colNationalNo
            // 
            this.colNationalNo.HeaderText = "NationalNo";
            this.colNationalNo.Name = "colNationalNo";
            this.colNationalNo.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.HeaderText = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 200;
            // 
            // colDetainDate
            // 
            this.colDetainDate.HeaderText = "Detain Date";
            this.colDetainDate.Name = "colDetainDate";
            this.colDetainDate.ReadOnly = true;
            this.colDetainDate.Width = 120;
            // 
            // colFineFees
            // 
            this.colFineFees.HeaderText = "Fine Fees";
            this.colFineFees.Name = "colFineFees";
            this.colFineFees.ReadOnly = true;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 30;
            // 
            // colIsReleased
            // 
            this.colIsReleased.HeaderText = "Is Released";
            this.colIsReleased.Name = "colIsReleased";
            this.colIsReleased.ReadOnly = true;
            this.colIsReleased.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsReleased.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colSep2
            // 
            this.colSep2.HeaderText = "";
            this.colSep2.Name = "colSep2";
            this.colSep2.ReadOnly = true;
            this.colSep2.Width = 30;
            // 
            // colReleaseApplicationID
            // 
            this.colReleaseApplicationID.HeaderText = "Release ApplicationID";
            this.colReleaseApplicationID.Name = "colReleaseApplicationID";
            this.colReleaseApplicationID.ReadOnly = true;
            this.colReleaseApplicationID.Width = 170;
            // 
            // colReleaseDate
            // 
            this.colReleaseDate.HeaderText = "Release Date";
            this.colReleaseDate.Name = "colReleaseDate";
            this.colReleaseDate.ReadOnly = true;
            this.colReleaseDate.Width = 115;
            // 
            // frmManageDetainedDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 474);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewDetainedLicense);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGVDetainedLicenses);
            this.Controls.Add(this.pnlRecords);
            this.Controls.Add(this.pnlFilter);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageDetainedDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detained Driving License Application";
            this.Load += new System.EventHandler(this.frmManageDetainedDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicenses)).EndInit();
            this.pnlRecords.ResumeLayout(false);
            this.pnlRecords.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.CMSDetainedLicense.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewDetainedLicense;
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.DataGridView DGVDetainedLicenses;
        private System.Windows.Forms.Panel pnlRecords;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.ComboBox CmbBoxReadMode;
        private System.Windows.Forms.ContextMenuStrip CMSDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowLicense;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator TSMISep;
        private System.Windows.Forms.ToolStripMenuItem TSMIReleaseDetainedLicense;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.Label lblShowtxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetainedLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFineFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewImageColumn colIsReleased;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReleaseApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReleaseDate;
    }
}