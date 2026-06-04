namespace DVLD
{
    partial class frmManagePeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePeople));
            this.DGVPeople = new System.Windows.Forms.DataGridView();
            this.ColPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.CmbBoxReadMode = new System.Windows.Forms.ComboBox();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CMSPerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDelete_MoveToTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDelete_DeletePermanently = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIRecover = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMISendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.lblShowtxt = new System.Windows.Forms.Label();
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeople)).BeginInit();
            this.CMSPerson.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPeople
            // 
            this.DGVPeople.AllowUserToAddRows = false;
            this.DGVPeople.AllowUserToDeleteRows = false;
            this.DGVPeople.AllowUserToOrderColumns = true;
            this.DGVPeople.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPersonID,
            this.ColNationalNo,
            this.ColFirstName,
            this.ColSecondName,
            this.ColThirdName,
            this.ColLastName,
            this.ColGender,
            this.ColBirthDate,
            this.ColPhone,
            this.ColEmail,
            this.ColNationality,
            this.ColAddress});
            this.DGVPeople.Location = new System.Drawing.Point(1, 113);
            this.DGVPeople.Name = "DGVPeople";
            this.DGVPeople.ReadOnly = true;
            this.DGVPeople.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVPeople.RowHeadersVisible = false;
            this.DGVPeople.Size = new System.Drawing.Size(1182, 233);
            this.DGVPeople.TabIndex = 0;
            this.DGVPeople.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVPeople_CellMouseDown);
            // 
            // ColPersonID
            // 
            this.ColPersonID.HeaderText = "PersonID";
            this.ColPersonID.Name = "ColPersonID";
            this.ColPersonID.ReadOnly = true;
            this.ColPersonID.Width = 70;
            // 
            // ColNationalNo
            // 
            this.ColNationalNo.HeaderText = "NationalNo";
            this.ColNationalNo.Name = "ColNationalNo";
            this.ColNationalNo.ReadOnly = true;
            this.ColNationalNo.Width = 90;
            // 
            // ColFirstName
            // 
            this.ColFirstName.HeaderText = "FirstName";
            this.ColFirstName.Name = "ColFirstName";
            this.ColFirstName.ReadOnly = true;
            this.ColFirstName.Width = 85;
            // 
            // ColSecondName
            // 
            this.ColSecondName.HeaderText = "SecondName";
            this.ColSecondName.Name = "ColSecondName";
            this.ColSecondName.ReadOnly = true;
            this.ColSecondName.Width = 95;
            // 
            // ColThirdName
            // 
            this.ColThirdName.HeaderText = "ThirdName";
            this.ColThirdName.Name = "ColThirdName";
            this.ColThirdName.ReadOnly = true;
            this.ColThirdName.Width = 85;
            // 
            // ColLastName
            // 
            this.ColLastName.HeaderText = "LastName";
            this.ColLastName.Name = "ColLastName";
            this.ColLastName.ReadOnly = true;
            this.ColLastName.Width = 85;
            // 
            // ColGender
            // 
            this.ColGender.HeaderText = "Gender";
            this.ColGender.Name = "ColGender";
            this.ColGender.ReadOnly = true;
            this.ColGender.Width = 60;
            // 
            // ColBirthDate
            // 
            this.ColBirthDate.HeaderText = "BirthDate";
            this.ColBirthDate.Name = "ColBirthDate";
            this.ColBirthDate.ReadOnly = true;
            this.ColBirthDate.Width = 80;
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "Phone";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColEmail
            // 
            this.ColEmail.HeaderText = "Email";
            this.ColEmail.Name = "ColEmail";
            this.ColEmail.ReadOnly = true;
            this.ColEmail.Width = 150;
            // 
            // ColNationality
            // 
            this.ColNationality.HeaderText = "Nationality";
            this.ColNationality.Name = "ColNationality";
            this.ColNationality.ReadOnly = true;
            this.ColNationality.Width = 120;
            // 
            // ColAddress
            // 
            this.ColAddress.HeaderText = "Address";
            this.ColAddress.Name = "ColAddress";
            this.ColAddress.ReadOnly = true;
            this.ColAddress.Width = 140;
            // 
            // CmbBoxFilterBy
            // 
            this.CmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxFilterBy.FormattingEnabled = true;
            this.CmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "Phone",
            "Email"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(433, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(278, 25);
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
            "Active People",
            "All People",
            "Deleted People"});
            this.CmbBoxReadMode.Location = new System.Drawing.Point(49, 5);
            this.CmbBoxReadMode.Name = "CmbBoxReadMode";
            this.CmbBoxReadMode.Size = new System.Drawing.Size(282, 25);
            this.CmbBoxReadMode.TabIndex = 3;
            this.CmbBoxReadMode.Tag = "";
            this.CmbBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.CmbBoxReadMode_SelectedIndexChanged);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtBoxFilter.Location = new System.Drawing.Point(717, 6);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(287, 23);
            this.txtBoxFilter.TabIndex = 2;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.TxtBox_TextChanged);
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            // 
            // CMSPerson
            // 
            this.CMSPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSPerson.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowDetails,
            this.toolStripMenuItem1,
            this.TSMIEdit,
            this.TSMIDelete,
            this.TSMIRecover,
            this.toolStripMenuItem2,
            this.TSMISendEmail,
            this.TSMIPhoneCall});
            this.CMSPerson.Name = "CMSInternationalLicenseApp";
            this.CMSPerson.Size = new System.Drawing.Size(168, 232);
            // 
            // TSMIShowDetails
            // 
            this.TSMIShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowDetails.Image")));
            this.TSMIShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowDetails.Name = "TSMIShowDetails";
            this.TSMIShowDetails.Size = new System.Drawing.Size(167, 36);
            this.TSMIShowDetails.Tag = "1";
            this.TSMIShowDetails.Text = "Show Details";
            this.TSMIShowDetails.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit.Image")));
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.Size = new System.Drawing.Size(167, 36);
            this.TSMIEdit.Tag = "2";
            this.TSMIEdit.Text = "Edit";
            this.TSMIEdit.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // TSMIDelete
            // 
            this.TSMIDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIDelete_MoveToTrash,
            this.TSMIDelete_DeletePermanently});
            this.TSMIDelete.Image = ((System.Drawing.Image)(resources.GetObject("TSMIDelete.Image")));
            this.TSMIDelete.Name = "TSMIDelete";
            this.TSMIDelete.Size = new System.Drawing.Size(167, 36);
            this.TSMIDelete.Tag = "3";
            this.TSMIDelete.Text = "Delete";
            this.TSMIDelete.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // TSMIDelete_MoveToTrash
            // 
            this.TSMIDelete_MoveToTrash.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMIDelete_MoveToTrash.Image = ((System.Drawing.Image)(resources.GetObject("TSMIDelete_MoveToTrash.Image")));
            this.TSMIDelete_MoveToTrash.Name = "TSMIDelete_MoveToTrash";
            this.TSMIDelete_MoveToTrash.Size = new System.Drawing.Size(193, 36);
            this.TSMIDelete_MoveToTrash.Tag = "1";
            this.TSMIDelete_MoveToTrash.Text = "Move to Trash";
            this.TSMIDelete_MoveToTrash.Click += new System.EventHandler(this.CMSPersonDelete_Click);
            // 
            // TSMIDelete_DeletePermanently
            // 
            this.TSMIDelete_DeletePermanently.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMIDelete_DeletePermanently.Image = ((System.Drawing.Image)(resources.GetObject("TSMIDelete_DeletePermanently.Image")));
            this.TSMIDelete_DeletePermanently.Name = "TSMIDelete_DeletePermanently";
            this.TSMIDelete_DeletePermanently.Size = new System.Drawing.Size(193, 36);
            this.TSMIDelete_DeletePermanently.Tag = "2";
            this.TSMIDelete_DeletePermanently.Text = "Delete Permanently";
            this.TSMIDelete_DeletePermanently.Click += new System.EventHandler(this.CMSPersonDelete_Click);
            // 
            // TSMIRecover
            // 
            this.TSMIRecover.Image = ((System.Drawing.Image)(resources.GetObject("TSMIRecover.Image")));
            this.TSMIRecover.Name = "TSMIRecover";
            this.TSMIRecover.Size = new System.Drawing.Size(167, 36);
            this.TSMIRecover.Tag = "4";
            this.TSMIRecover.Text = "Recover";
            this.TSMIRecover.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // TSMISendEmail
            // 
            this.TSMISendEmail.Image = ((System.Drawing.Image)(resources.GetObject("TSMISendEmail.Image")));
            this.TSMISendEmail.Name = "TSMISendEmail";
            this.TSMISendEmail.Size = new System.Drawing.Size(167, 36);
            this.TSMISendEmail.Tag = "5";
            this.TSMISendEmail.Text = "Send Email";
            this.TSMISendEmail.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // TSMIPhoneCall
            // 
            this.TSMIPhoneCall.Image = ((System.Drawing.Image)(resources.GetObject("TSMIPhoneCall.Image")));
            this.TSMIPhoneCall.Name = "TSMIPhoneCall";
            this.TSMIPhoneCall.Size = new System.Drawing.Size(167, 36);
            this.TSMIPhoneCall.Tag = "6";
            this.TSMIPhoneCall.Text = "Phone Call";
            this.TSMIPhoneCall.Click += new System.EventHandler(this.CMSPerson_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PicBoxRefresh);
            this.panel1.Controls.Add(this.lblShowtxt);
            this.panel1.Controls.Add(this.txtBoxFilter);
            this.panel1.Controls.Add(this.lblFilterBytxt);
            this.panel1.Controls.Add(this.CmbBoxFilterBy);
            this.panel1.Controls.Add(this.CmbBoxReadMode);
            this.panel1.Location = new System.Drawing.Point(8, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 38);
            this.panel1.TabIndex = 12;
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(1010, 5);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 56;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // lblShowtxt
            // 
            this.lblShowtxt.AutoSize = true;
            this.lblShowtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblShowtxt.Location = new System.Drawing.Point(5, 9);
            this.lblShowtxt.Name = "lblShowtxt";
            this.lblShowtxt.Size = new System.Drawing.Size(41, 17);
            this.lblShowtxt.TabIndex = 11;
            this.lblShowtxt.Text = "Show";
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(373, 9);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 10;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(9, 19);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(99, 15);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // lblSystemRecordstxt
            // 
            this.lblSystemRecordstxt.AutoSize = true;
            this.lblSystemRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblSystemRecordstxt.Location = new System.Drawing.Point(0, 4);
            this.lblSystemRecordstxt.Name = "lblSystemRecordstxt";
            this.lblSystemRecordstxt.Size = new System.Drawing.Size(110, 15);
            this.lblSystemRecordstxt.TabIndex = 0;
            this.lblSystemRecordstxt.Text = "   # Active Records: ";
            // 
            // lblSystemRecords
            // 
            this.lblSystemRecords.AutoSize = true;
            this.lblSystemRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblSystemRecords.Location = new System.Drawing.Point(117, 4);
            this.lblSystemRecords.Name = "lblSystemRecords";
            this.lblSystemRecords.Size = new System.Drawing.Size(14, 15);
            this.lblSystemRecords.TabIndex = 0;
            this.lblSystemRecords.Text = "0";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(117, 20);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(14, 15);
            this.lblRecords.TabIndex = 7;
            this.lblRecords.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRecords);
            this.panel3.Controls.Add(this.lblSystemRecords);
            this.panel3.Controls.Add(this.lblSystemRecordstxt);
            this.panel3.Controls.Add(this.lblRecordstxt);
            this.panel3.Location = new System.Drawing.Point(22, 353);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 38);
            this.panel3.TabIndex = 14;
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
            this.panel2.Size = new System.Drawing.Size(1185, 42);
            this.panel2.TabIndex = 49;
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
            this.PicBoxClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(44, 10);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(129, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Manage People";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(8, 4);
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
            this.btnClose.Location = new System.Drawing.Point(1066, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 54;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.AutoSize = true;
            this.btnAddNewPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(30)))));
            this.btnAddNewPerson.FlatAppearance.BorderSize = 2;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1062, 62);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(114, 42);
            this.btnAddNewPerson.TabIndex = 56;
            this.btnAddNewPerson.Tag = "1";
            this.btnAddNewPerson.Text = "         Add New";
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.Btn_Click);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 405);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVPeople);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeople)).EndInit();
            this.CMSPerson.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVPeople;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.ComboBox CmbBoxReadMode;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ContextMenuStrip CMSPerson;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem TSMIDelete;
        private System.Windows.Forms.ToolStripMenuItem TSMIDelete_MoveToTrash;
        private System.Windows.Forms.ToolStripMenuItem TSMIDelete_DeletePermanently;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TSMISendEmail;
        private System.Windows.Forms.ToolStripMenuItem TSMIPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem TSMIRecover;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Label lblShowtxt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddress;
        private System.Windows.Forms.Button btnAddNewPerson;
    }
}