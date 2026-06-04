namespace DVLD.Users
{
    partial class frmManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.CmbBoxReadMode = new System.Windows.Forms.ComboBox();
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.DGVUsers = new System.Windows.Forms.DataGridView();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedByUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMSUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIEdit_EditAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIEdit_Activate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIEdit_Deactivate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMoveToTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIRecover = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIChangePassowrd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMISendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).BeginInit();
            this.CMSUser.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PicBoxRefresh);
            this.panel1.Controls.Add(this.txtBoxFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbBoxFilterBy);
            this.panel1.Controls.Add(this.CmbBoxReadMode);
            this.panel1.Controls.Add(this.lblFilterBytxt);
            this.panel1.Location = new System.Drawing.Point(8, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 38);
            this.panel1.TabIndex = 16;
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(654, 5);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 55;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtBoxFilter.Location = new System.Drawing.Point(395, 7);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(253, 22);
            this.txtBoxFilter.TabIndex = 2;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.txtBoxFilter_TextChanged);
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Show";
            // 
            // CmbBoxFilterBy
            // 
            this.CmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilterBy.FormattingEnabled = true;
            this.CmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "UserID ",
            "PersonID",
            "UserName",
            "UserID (Who created)"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(247, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(142, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // CmbBoxReadMode
            // 
            this.CmbBoxReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxReadMode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxReadMode.FormattingEnabled = true;
            this.CmbBoxReadMode.Items.AddRange(new object[] {
            "All Users ",
            "Active Users ",
            "Inactive Users",
            "Deleted Users"});
            this.CmbBoxReadMode.Location = new System.Drawing.Point(48, 5);
            this.CmbBoxReadMode.Name = "CmbBoxReadMode";
            this.CmbBoxReadMode.Size = new System.Drawing.Size(118, 25);
            this.CmbBoxReadMode.TabIndex = 6;
            this.CmbBoxReadMode.Tag = "";
            this.CmbBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.CmbBoxReadMode_SelectedIndexChanged);
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(187, 9);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 15;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRecords);
            this.panel3.Controls.Add(this.lblSystemRecords);
            this.panel3.Controls.Add(this.lblSystemRecordstxt);
            this.panel3.Controls.Add(this.lblRecordstxt);
            this.panel3.Location = new System.Drawing.Point(18, 331);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 38);
            this.panel3.TabIndex = 17;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(117, 19);
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
            this.lblRecordstxt.Location = new System.Drawing.Point(9, 18);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(99, 15);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // DGVUsers
            // 
            this.DGVUsers.AllowUserToAddRows = false;
            this.DGVUsers.AllowUserToDeleteRows = false;
            this.DGVUsers.AllowUserToOrderColumns = true;
            this.DGVUsers.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserID,
            this.colUsername,
            this.colSep1,
            this.colPersonID,
            this.colFullName,
            this.colSep2,
            this.colStatus,
            this.colCreatedByUserID});
            this.DGVUsers.Location = new System.Drawing.Point(1, 111);
            this.DGVUsers.Name = "DGVUsers";
            this.DGVUsers.ReadOnly = true;
            this.DGVUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVUsers.Size = new System.Drawing.Size(830, 213);
            this.DGVUsers.TabIndex = 18;
            this.DGVUsers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVUsers_CellMouseDown);
            // 
            // colUserID
            // 
            this.colUserID.HeaderText = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.Width = 90;
            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 125;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 20;
            // 
            // colPersonID
            // 
            this.colPersonID.HeaderText = "PersonID";
            this.colPersonID.Name = "colPersonID";
            this.colPersonID.ReadOnly = true;
            this.colPersonID.Width = 90;
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
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 90;
            // 
            // colCreatedByUserID
            // 
            this.colCreatedByUserID.HeaderText = "Created By UserID";
            this.colCreatedByUserID.Name = "colCreatedByUserID";
            this.colCreatedByUserID.ReadOnly = true;
            this.colCreatedByUserID.Width = 135;
            // 
            // CMSUser
            // 
            this.CMSUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSUser.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowDetails,
            this.toolStripMenuItem1,
            this.TSMIEdit,
            this.TSMIMoveToTrash,
            this.TSMIRecover,
            this.toolStripMenuItem3,
            this.TSMIChangePassowrd,
            this.toolStripMenuItem2,
            this.TSMISendEmail,
            this.TSMIPhoneCall});
            this.CMSUser.Name = "CMSInternationalLicenseApp";
            this.CMSUser.Size = new System.Drawing.Size(199, 274);
            // 
            // TSMIShowDetails
            // 
            this.TSMIShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowDetails.Image")));
            this.TSMIShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowDetails.Name = "TSMIShowDetails";
            this.TSMIShowDetails.Size = new System.Drawing.Size(198, 36);
            this.TSMIShowDetails.Tag = "1";
            this.TSMIShowDetails.Text = "Show Details";
            this.TSMIShowDetails.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIEdit_EditAll,
            this.TSMIEdit_Activate,
            this.TSMIEdit_Deactivate});
            this.TSMIEdit.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit.Image")));
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.Size = new System.Drawing.Size(198, 36);
            this.TSMIEdit.Tag = "";
            this.TSMIEdit.Text = "Edit";
            // 
            // TSMIEdit_EditAll
            // 
            this.TSMIEdit_EditAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TSMIEdit_EditAll.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit_EditAll.Image")));
            this.TSMIEdit_EditAll.Name = "TSMIEdit_EditAll";
            this.TSMIEdit_EditAll.Size = new System.Drawing.Size(148, 36);
            this.TSMIEdit_EditAll.Tag = "2";
            this.TSMIEdit_EditAll.Text = "Edit All";
            this.TSMIEdit_EditAll.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // TSMIEdit_Activate
            // 
            this.TSMIEdit_Activate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TSMIEdit_Activate.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit_Activate.Image")));
            this.TSMIEdit_Activate.Name = "TSMIEdit_Activate";
            this.TSMIEdit_Activate.Size = new System.Drawing.Size(148, 36);
            this.TSMIEdit_Activate.Tag = "3";
            this.TSMIEdit_Activate.Text = "Activate";
            this.TSMIEdit_Activate.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // TSMIEdit_Deactivate
            // 
            this.TSMIEdit_Deactivate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TSMIEdit_Deactivate.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit_Deactivate.Image")));
            this.TSMIEdit_Deactivate.Name = "TSMIEdit_Deactivate";
            this.TSMIEdit_Deactivate.Size = new System.Drawing.Size(148, 36);
            this.TSMIEdit_Deactivate.Tag = "4";
            this.TSMIEdit_Deactivate.Text = "Deactivate ";
            this.TSMIEdit_Deactivate.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // TSMIMoveToTrash
            // 
            this.TSMIMoveToTrash.Image = ((System.Drawing.Image)(resources.GetObject("TSMIMoveToTrash.Image")));
            this.TSMIMoveToTrash.Name = "TSMIMoveToTrash";
            this.TSMIMoveToTrash.Size = new System.Drawing.Size(198, 36);
            this.TSMIMoveToTrash.Tag = "5";
            this.TSMIMoveToTrash.Text = "Move to Trash";
            this.TSMIMoveToTrash.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // TSMIRecover
            // 
            this.TSMIRecover.Image = ((System.Drawing.Image)(resources.GetObject("TSMIRecover.Image")));
            this.TSMIRecover.Name = "TSMIRecover";
            this.TSMIRecover.Size = new System.Drawing.Size(198, 36);
            this.TSMIRecover.Tag = "6";
            this.TSMIRecover.Text = "Recover";
            this.TSMIRecover.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(195, 6);
            // 
            // TSMIChangePassowrd
            // 
            this.TSMIChangePassowrd.Image = ((System.Drawing.Image)(resources.GetObject("TSMIChangePassowrd.Image")));
            this.TSMIChangePassowrd.Name = "TSMIChangePassowrd";
            this.TSMIChangePassowrd.Size = new System.Drawing.Size(198, 36);
            this.TSMIChangePassowrd.Tag = "7";
            this.TSMIChangePassowrd.Text = "Change Password";
            this.TSMIChangePassowrd.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // TSMISendEmail
            // 
            this.TSMISendEmail.Image = ((System.Drawing.Image)(resources.GetObject("TSMISendEmail.Image")));
            this.TSMISendEmail.Name = "TSMISendEmail";
            this.TSMISendEmail.Size = new System.Drawing.Size(198, 36);
            this.TSMISendEmail.Tag = "8";
            this.TSMISendEmail.Text = "Send Email";
            this.TSMISendEmail.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // TSMIPhoneCall
            // 
            this.TSMIPhoneCall.Image = ((System.Drawing.Image)(resources.GetObject("TSMIPhoneCall.Image")));
            this.TSMIPhoneCall.Name = "TSMIPhoneCall";
            this.TSMIPhoneCall.Size = new System.Drawing.Size(198, 36);
            this.TSMIPhoneCall.Tag = "9";
            this.TSMIPhoneCall.Text = "Phone Call";
            this.TSMIPhoneCall.Click += new System.EventHandler(this.TSMIItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PicBoxClose);
            this.panel2.Controls.Add(this.lblTitletxt);
            this.panel2.Controls.Add(this.PicBoxTitleImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 39);
            this.panel2.TabIndex = 48;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(804, 6);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 46;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            this.PicBoxClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(33, 7);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(117, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Manage Users";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(5, 6);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(24, 24);
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
            this.btnClose.Location = new System.Drawing.Point(727, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 53;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.AutoSize = true;
            this.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnAddNewUser.FlatAppearance.BorderSize = 2;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewUser.Image")));
            this.btnAddNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewUser.Location = new System.Drawing.Point(708, 62);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(114, 42);
            this.btnAddNewUser.TabIndex = 57;
            this.btnAddNewUser.Tag = "1";
            this.btnAddNewUser.Text = "         Add New";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.Btn_Click);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 380);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVUsers);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).EndInit();
            this.CMSUser.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.ComboBox CmbBoxReadMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.DataGridView DGVUsers;
        private System.Windows.Forms.ContextMenuStrip CMSUser;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem TSMIMoveToTrash;
        private System.Windows.Forms.ToolStripMenuItem TSMIRecover;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TSMISendEmail;
        private System.Windows.Forms.ToolStripMenuItem TSMIPhoneCall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem TSMIChangePassowrd;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit_EditAll;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit_Activate;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit_Deactivate;
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedByUserID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewUser;
    }
}