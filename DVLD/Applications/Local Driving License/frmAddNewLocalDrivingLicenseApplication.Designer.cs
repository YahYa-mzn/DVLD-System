namespace DVLD.Applications.Local_Driving_License
{
    partial class frmAddNewLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewLocalDrivingLicenseApplication));
            this.tabCtrlInfoContainer = new System.Windows.Forms.TabControl();
            this.TabPagePerson = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter = new DVLD.People.CtrlPersonCardWithFilter();
            this.TabPageUser = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.CmbBoxLicenseClass = new System.Windows.Forms.ComboBox();
            this.PicBoxCreatedBy = new System.Windows.Forms.PictureBox();
            this.lblCreatedBytxt = new System.Windows.Forms.Label();
            this.lblLDLAppID = new System.Windows.Forms.Label();
            this.PicBoxApplicationFees = new System.Windows.Forms.PictureBox();
            this.PicBoxLDLAppID = new System.Windows.Forms.PictureBox();
            this.lblLDLAppIDtxt = new System.Windows.Forms.Label();
            this.PicBoxApplicationID = new System.Windows.Forms.PictureBox();
            this.PicBoxLicenseClass = new System.Windows.Forms.PictureBox();
            this.lblApplicationIDtxt = new System.Windows.Forms.Label();
            this.PicBoxApplicationDate = new System.Windows.Forms.PictureBox();
            this.lblApplicationDatetxt = new System.Windows.Forms.Label();
            this.lblLicenseClasstxt = new System.Windows.Forms.Label();
            this.lblApplicationFeestxt = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.tabCtrlInfoContainer.SuspendLayout();
            this.TabPagePerson.SuspendLayout();
            this.TabPageUser.SuspendLayout();
            this.grpBoxUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLDLAppID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLicenseClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationDate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlInfoContainer
            // 
            this.tabCtrlInfoContainer.Controls.Add(this.TabPagePerson);
            this.tabCtrlInfoContainer.Controls.Add(this.TabPageUser);
            this.tabCtrlInfoContainer.Location = new System.Drawing.Point(6, 46);
            this.tabCtrlInfoContainer.Name = "tabCtrlInfoContainer";
            this.tabCtrlInfoContainer.SelectedIndex = 0;
            this.tabCtrlInfoContainer.Size = new System.Drawing.Size(646, 338);
            this.tabCtrlInfoContainer.TabIndex = 36;
            this.tabCtrlInfoContainer.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCtrlInfoContainer_Selecting);
            // 
            // TabPagePerson
            // 
            this.TabPagePerson.BackColor = System.Drawing.SystemColors.Control;
            this.TabPagePerson.Controls.Add(this.btnNext);
            this.TabPagePerson.Controls.Add(this.ctrlPersonCardWithFilter);
            this.TabPagePerson.Location = new System.Drawing.Point(4, 22);
            this.TabPagePerson.Name = "TabPagePerson";
            this.TabPagePerson.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePerson.Size = new System.Drawing.Size(638, 312);
            this.TabPagePerson.TabIndex = 0;
            this.TabPagePerson.Text = "Person Info";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(476, 274);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 32);
            this.btnNext.TabIndex = 98;
            this.btnNext.Tag = "3";
            this.btnNext.Text = "  Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.Btn_Click);
            // 
            // ctrlPersonCardWithFilter
            // 
            this.ctrlPersonCardWithFilter.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlPersonCardWithFilter.IsFound = false;
            this.ctrlPersonCardWithFilter.Location = new System.Drawing.Point(1, 1);
            this.ctrlPersonCardWithFilter.Name = "ctrlPersonCardWithFilter";
            this.ctrlPersonCardWithFilter.Size = new System.Drawing.Size(636, 274);
            this.ctrlPersonCardWithFilter.TabIndex = 0;
            // 
            // TabPageUser
            // 
            this.TabPageUser.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageUser.Controls.Add(this.btnBack);
            this.TabPageUser.Controls.Add(this.grpBoxUserInfo);
            this.TabPageUser.Location = new System.Drawing.Point(4, 22);
            this.TabPageUser.Name = "TabPageUser";
            this.TabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageUser.Size = new System.Drawing.Size(638, 312);
            this.TabPageUser.TabIndex = 1;
            this.TabPageUser.Text = "Local Driving License Application Info";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(476, 274);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.TabIndex = 78;
            this.btnBack.Tag = "4";
            this.btnBack.Text = "       Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.Btn_Click);
            // 
            // grpBoxUserInfo
            // 
            this.grpBoxUserInfo.Controls.Add(this.lblCreatedBy);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationFees);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationDate);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationID);
            this.grpBoxUserInfo.Controls.Add(this.CmbBoxLicenseClass);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxCreatedBy);
            this.grpBoxUserInfo.Controls.Add(this.lblCreatedBytxt);
            this.grpBoxUserInfo.Controls.Add(this.lblLDLAppID);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxApplicationFees);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxLDLAppID);
            this.grpBoxUserInfo.Controls.Add(this.lblLDLAppIDtxt);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxApplicationID);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxLicenseClass);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationIDtxt);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxApplicationDate);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationDatetxt);
            this.grpBoxUserInfo.Controls.Add(this.lblLicenseClasstxt);
            this.grpBoxUserInfo.Controls.Add(this.lblApplicationFeestxt);
            this.grpBoxUserInfo.Location = new System.Drawing.Point(6, 4);
            this.grpBoxUserInfo.Name = "grpBoxUserInfo";
            this.grpBoxUserInfo.Size = new System.Drawing.Size(627, 266);
            this.grpBoxUserInfo.TabIndex = 77;
            this.grpBoxUserInfo.TabStop = false;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblCreatedBy.Location = new System.Drawing.Point(136, 230);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 15);
            this.lblCreatedBy.TabIndex = 71;
            this.lblCreatedBy.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblApplicationFees.Location = new System.Drawing.Point(136, 187);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(35, 15);
            this.lblApplicationFees.TabIndex = 70;
            this.lblApplicationFees.Text = "[????]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblApplicationDate.Location = new System.Drawing.Point(136, 101);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(35, 15);
            this.lblApplicationDate.TabIndex = 69;
            this.lblApplicationDate.Text = "[????]";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.BackColor = System.Drawing.SystemColors.Control;
            this.lblApplicationID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.ForeColor = System.Drawing.Color.Firebrick;
            this.lblApplicationID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationID.Location = new System.Drawing.Point(136, 56);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(32, 17);
            this.lblApplicationID.TabIndex = 58;
            this.lblApplicationID.Text = "N/A";
            // 
            // CmbBoxLicenseClass
            // 
            this.CmbBoxLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxLicenseClass.FormattingEnabled = true;
            this.CmbBoxLicenseClass.Location = new System.Drawing.Point(140, 139);
            this.CmbBoxLicenseClass.Name = "CmbBoxLicenseClass";
            this.CmbBoxLicenseClass.Size = new System.Drawing.Size(481, 25);
            this.CmbBoxLicenseClass.TabIndex = 57;
            // 
            // PicBoxCreatedBy
            // 
            this.PicBoxCreatedBy.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxCreatedBy.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxCreatedBy.Image")));
            this.PicBoxCreatedBy.Location = new System.Drawing.Point(112, 227);
            this.PicBoxCreatedBy.Name = "PicBoxCreatedBy";
            this.PicBoxCreatedBy.Size = new System.Drawing.Size(20, 20);
            this.PicBoxCreatedBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxCreatedBy.TabIndex = 56;
            this.PicBoxCreatedBy.TabStop = false;
            // 
            // lblCreatedBytxt
            // 
            this.lblCreatedBytxt.AutoSize = true;
            this.lblCreatedBytxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblCreatedBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblCreatedBytxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCreatedBytxt.Location = new System.Drawing.Point(43, 229);
            this.lblCreatedBytxt.Name = "lblCreatedBytxt";
            this.lblCreatedBytxt.Size = new System.Drawing.Size(66, 15);
            this.lblCreatedBytxt.TabIndex = 55;
            this.lblCreatedBytxt.Text = "Created By:";
            // 
            // lblLDLAppID
            // 
            this.lblLDLAppID.AutoSize = true;
            this.lblLDLAppID.BackColor = System.Drawing.SystemColors.Control;
            this.lblLDLAppID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLAppID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(125)))), ((int)(((byte)(86)))));
            this.lblLDLAppID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLDLAppID.Location = new System.Drawing.Point(136, 13);
            this.lblLDLAppID.Name = "lblLDLAppID";
            this.lblLDLAppID.Size = new System.Drawing.Size(32, 17);
            this.lblLDLAppID.TabIndex = 45;
            this.lblLDLAppID.Text = "N/A";
            // 
            // PicBoxApplicationFees
            // 
            this.PicBoxApplicationFees.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxApplicationFees.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxApplicationFees.Image")));
            this.PicBoxApplicationFees.Location = new System.Drawing.Point(112, 184);
            this.PicBoxApplicationFees.Name = "PicBoxApplicationFees";
            this.PicBoxApplicationFees.Size = new System.Drawing.Size(20, 20);
            this.PicBoxApplicationFees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxApplicationFees.TabIndex = 52;
            this.PicBoxApplicationFees.TabStop = false;
            // 
            // PicBoxLDLAppID
            // 
            this.PicBoxLDLAppID.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxLDLAppID.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxLDLAppID.Image")));
            this.PicBoxLDLAppID.Location = new System.Drawing.Point(112, 12);
            this.PicBoxLDLAppID.Name = "PicBoxLDLAppID";
            this.PicBoxLDLAppID.Size = new System.Drawing.Size(20, 20);
            this.PicBoxLDLAppID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxLDLAppID.TabIndex = 46;
            this.PicBoxLDLAppID.TabStop = false;
            // 
            // lblLDLAppIDtxt
            // 
            this.lblLDLAppIDtxt.AutoSize = true;
            this.lblLDLAppIDtxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblLDLAppIDtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLAppIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblLDLAppIDtxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLDLAppIDtxt.Location = new System.Drawing.Point(32, 14);
            this.lblLDLAppIDtxt.Name = "lblLDLAppIDtxt";
            this.lblLDLAppIDtxt.Size = new System.Drawing.Size(77, 15);
            this.lblLDLAppIDtxt.TabIndex = 44;
            this.lblLDLAppIDtxt.Text = "L.D.L. AppID:";
            // 
            // PicBoxApplicationID
            // 
            this.PicBoxApplicationID.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxApplicationID.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxApplicationID.Image")));
            this.PicBoxApplicationID.Location = new System.Drawing.Point(112, 55);
            this.PicBoxApplicationID.Name = "PicBoxApplicationID";
            this.PicBoxApplicationID.Size = new System.Drawing.Size(20, 20);
            this.PicBoxApplicationID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxApplicationID.TabIndex = 49;
            this.PicBoxApplicationID.TabStop = false;
            // 
            // PicBoxLicenseClass
            // 
            this.PicBoxLicenseClass.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxLicenseClass.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxLicenseClass.Image")));
            this.PicBoxLicenseClass.Location = new System.Drawing.Point(112, 141);
            this.PicBoxLicenseClass.Name = "PicBoxLicenseClass";
            this.PicBoxLicenseClass.Size = new System.Drawing.Size(20, 20);
            this.PicBoxLicenseClass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxLicenseClass.TabIndex = 51;
            this.PicBoxLicenseClass.TabStop = false;
            // 
            // lblApplicationIDtxt
            // 
            this.lblApplicationIDtxt.AutoSize = true;
            this.lblApplicationIDtxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblApplicationIDtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblApplicationIDtxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationIDtxt.Location = new System.Drawing.Point(25, 57);
            this.lblApplicationIDtxt.Name = "lblApplicationIDtxt";
            this.lblApplicationIDtxt.Size = new System.Drawing.Size(84, 15);
            this.lblApplicationIDtxt.TabIndex = 40;
            this.lblApplicationIDtxt.Text = "ApplicationID:";
            // 
            // PicBoxApplicationDate
            // 
            this.PicBoxApplicationDate.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxApplicationDate.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxApplicationDate.Image")));
            this.PicBoxApplicationDate.Location = new System.Drawing.Point(112, 98);
            this.PicBoxApplicationDate.Name = "PicBoxApplicationDate";
            this.PicBoxApplicationDate.Size = new System.Drawing.Size(20, 20);
            this.PicBoxApplicationDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxApplicationDate.TabIndex = 50;
            this.PicBoxApplicationDate.TabStop = false;
            // 
            // lblApplicationDatetxt
            // 
            this.lblApplicationDatetxt.AutoSize = true;
            this.lblApplicationDatetxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblApplicationDatetxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDatetxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblApplicationDatetxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationDatetxt.Location = new System.Drawing.Point(10, 100);
            this.lblApplicationDatetxt.Name = "lblApplicationDatetxt";
            this.lblApplicationDatetxt.Size = new System.Drawing.Size(99, 15);
            this.lblApplicationDatetxt.TabIndex = 42;
            this.lblApplicationDatetxt.Text = "Application Date:";
            // 
            // lblLicenseClasstxt
            // 
            this.lblLicenseClasstxt.AutoSize = true;
            this.lblLicenseClasstxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblLicenseClasstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClasstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblLicenseClasstxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLicenseClasstxt.Location = new System.Drawing.Point(31, 143);
            this.lblLicenseClasstxt.Name = "lblLicenseClasstxt";
            this.lblLicenseClasstxt.Size = new System.Drawing.Size(78, 15);
            this.lblLicenseClasstxt.TabIndex = 43;
            this.lblLicenseClasstxt.Text = "License Class:";
            // 
            // lblApplicationFeestxt
            // 
            this.lblApplicationFeestxt.AutoSize = true;
            this.lblApplicationFeestxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblApplicationFeestxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFeestxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.lblApplicationFeestxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationFeestxt.Location = new System.Drawing.Point(12, 186);
            this.lblApplicationFeestxt.Name = "lblApplicationFeestxt";
            this.lblApplicationFeestxt.Size = new System.Drawing.Size(97, 15);
            this.lblApplicationFeestxt.TabIndex = 45;
            this.lblApplicationFeestxt.Text = "Application Fees:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(439, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 99;
            this.btnSave.Tag = "1";
            this.btnSave.Text = "      Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.Btn_Click);
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
            this.btnClose.Location = new System.Drawing.Point(530, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 100;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.Btn_Click);
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
            this.panel2.Size = new System.Drawing.Size(651, 44);
            this.panel2.TabIndex = 101;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(621, 9);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 48;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            this.PicBoxClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(38, 10);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(303, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "New Local Driving License Application";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(3, 4);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(32, 32);
            this.PicBoxTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitleImage.TabIndex = 45;
            this.PicBoxTitleImage.TabStop = false;
            // 
            // frmAddNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabCtrlInfoContainer);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddNewLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.frmAddNewLocalDrivingLicenseApplication_Load);
            this.tabCtrlInfoContainer.ResumeLayout(false);
            this.TabPagePerson.ResumeLayout(false);
            this.TabPageUser.ResumeLayout(false);
            this.grpBoxUserInfo.ResumeLayout(false);
            this.grpBoxUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLDLAppID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLicenseClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxApplicationDate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrlInfoContainer;
        private System.Windows.Forms.TabPage TabPagePerson;
        private People.CtrlPersonCardWithFilter ctrlPersonCardWithFilter;
        private System.Windows.Forms.TabPage TabPageUser;
        private System.Windows.Forms.GroupBox grpBoxUserInfo;
        private System.Windows.Forms.Label lblLDLAppID;
        private System.Windows.Forms.PictureBox PicBoxApplicationFees;
        private System.Windows.Forms.PictureBox PicBoxLDLAppID;
        private System.Windows.Forms.Label lblLDLAppIDtxt;
        private System.Windows.Forms.PictureBox PicBoxApplicationID;
        private System.Windows.Forms.PictureBox PicBoxLicenseClass;
        private System.Windows.Forms.Label lblApplicationIDtxt;
        private System.Windows.Forms.PictureBox PicBoxApplicationDate;
        private System.Windows.Forms.Label lblApplicationDatetxt;
        private System.Windows.Forms.Label lblLicenseClasstxt;
        private System.Windows.Forms.Label lblApplicationFeestxt;
        private System.Windows.Forms.PictureBox PicBoxCreatedBy;
        private System.Windows.Forms.Label lblCreatedBytxt;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.ComboBox CmbBoxLicenseClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnBack;
    }
}