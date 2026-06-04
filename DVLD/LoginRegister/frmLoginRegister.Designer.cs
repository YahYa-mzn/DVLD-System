namespace DVLD.Users.LoginRegister
{
    partial class frmLoginRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginRegister));
            this.DGVLoginRegister = new System.Windows.Forms.DataGridView();
            this.colLoginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogoutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxFilterBy = new System.Windows.Forms.TextBox();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.MskdTxtBoxEndDate = new System.Windows.Forms.MaskedTextBox();
            this.MskdTxtBoxStartDate = new System.Windows.Forms.MaskedTextBox();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.errorProviderValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.CMSLogin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoginRegister)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValidation)).BeginInit();
            this.CMSLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVLoginRegister
            // 
            this.DGVLoginRegister.AllowUserToAddRows = false;
            this.DGVLoginRegister.AllowUserToDeleteRows = false;
            this.DGVLoginRegister.AllowUserToOrderColumns = true;
            this.DGVLoginRegister.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVLoginRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLoginID,
            this.colSep1,
            this.colUserID,
            this.colUsername,
            this.colSep2,
            this.colLoginTime,
            this.colLogoutTime});
            this.DGVLoginRegister.Location = new System.Drawing.Point(2, 114);
            this.DGVLoginRegister.Name = "DGVLoginRegister";
            this.DGVLoginRegister.ReadOnly = true;
            this.DGVLoginRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVLoginRegister.RowHeadersVisible = false;
            this.DGVLoginRegister.Size = new System.Drawing.Size(884, 223);
            this.DGVLoginRegister.TabIndex = 19;
            this.DGVLoginRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLoginRegister_CellDoubleClick);
            this.DGVLoginRegister.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVLoginRegister_CellMouseDown);
            // 
            // colLoginID
            // 
            this.colLoginID.HeaderText = "LoginID";
            this.colLoginID.Name = "colLoginID";
            this.colLoginID.ReadOnly = true;
            this.colLoginID.Width = 130;
            // 
            // colSep1
            // 
            this.colSep1.HeaderText = "";
            this.colSep1.Name = "colSep1";
            this.colSep1.ReadOnly = true;
            this.colSep1.Width = 20;
            // 
            // colUserID
            // 
            this.colUserID.HeaderText = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.Width = 120;
            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 170;
            // 
            // colSep2
            // 
            this.colSep2.HeaderText = "";
            this.colSep2.Name = "colSep2";
            this.colSep2.ReadOnly = true;
            this.colSep2.Width = 20;
            // 
            // colLoginTime
            // 
            this.colLoginTime.HeaderText = "Login Time";
            this.colLoginTime.Name = "colLoginTime";
            this.colLoginTime.ReadOnly = true;
            this.colLoginTime.Width = 200;
            // 
            // colLogoutTime
            // 
            this.colLogoutTime.HeaderText = "Logout Time";
            this.colLogoutTime.Name = "colLogoutTime";
            this.colLogoutTime.ReadOnly = true;
            this.colLogoutTime.Width = 200;
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(10, 9);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 20;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxFilterBy);
            this.panel1.Controls.Add(this.PicBoxRefresh);
            this.panel1.Controls.Add(this.MskdTxtBoxEndDate);
            this.panel1.Controls.Add(this.MskdTxtBoxStartDate);
            this.panel1.Controls.Add(this.CmbBoxFilterBy);
            this.panel1.Controls.Add(this.lblFilterBytxt);
            this.panel1.Location = new System.Drawing.Point(15, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 37);
            this.panel1.TabIndex = 21;
            // 
            // txtBoxFilterBy
            // 
            this.txtBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFilterBy.Location = new System.Drawing.Point(498, 6);
            this.txtBoxFilterBy.Name = "txtBoxFilterBy";
            this.txtBoxFilterBy.Size = new System.Drawing.Size(304, 23);
            this.txtBoxFilterBy.TabIndex = 4;
            this.txtBoxFilterBy.TextChanged += new System.EventHandler(this.txtBoxFilterBy_TextChanged);
            this.txtBoxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilterBy_KeyPress);
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(817, 5);
            this.PicBoxRefresh.Name = "PicBoxRefresh";
            this.PicBoxRefresh.Size = new System.Drawing.Size(26, 26);
            this.PicBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxRefresh.TabIndex = 56;
            this.PicBoxRefresh.TabStop = false;
            this.PicBoxRefresh.Click += new System.EventHandler(this.PicBoxRefresh_Click);
            // 
            // MskdTxtBoxEndDate
            // 
            this.MskdTxtBoxEndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskdTxtBoxEndDate.Location = new System.Drawing.Point(660, 6);
            this.MskdTxtBoxEndDate.Mask = "0000/00/00";
            this.MskdTxtBoxEndDate.Name = "MskdTxtBoxEndDate";
            this.MskdTxtBoxEndDate.Size = new System.Drawing.Size(142, 23);
            this.MskdTxtBoxEndDate.TabIndex = 3;
            this.MskdTxtBoxEndDate.ValidatingType = typeof(System.DateTime);
            this.MskdTxtBoxEndDate.TextChanged += new System.EventHandler(this.MskTxtBox_TextChanged);
            // 
            // MskdTxtBoxStartDate
            // 
            this.MskdTxtBoxStartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskdTxtBoxStartDate.Location = new System.Drawing.Point(498, 6);
            this.MskdTxtBoxStartDate.Mask = "0000/00/00";
            this.MskdTxtBoxStartDate.Name = "MskdTxtBoxStartDate";
            this.MskdTxtBoxStartDate.Size = new System.Drawing.Size(142, 23);
            this.MskdTxtBoxStartDate.TabIndex = 2;
            this.MskdTxtBoxStartDate.TextChanged += new System.EventHandler(this.MskTxtBox_TextChanged);
            // 
            // CmbBoxFilterBy
            // 
            this.CmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilterBy.FormattingEnabled = true;
            this.CmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "UserID",
            "UserName",
            "LoginTime",
            "LogoutTime",
            "Logged In Users"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(74, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(410, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRecords);
            this.panel3.Controls.Add(this.lblSystemRecords);
            this.panel3.Controls.Add(this.lblSystemRecordstxt);
            this.panel3.Controls.Add(this.lblRecordstxt);
            this.panel3.Location = new System.Drawing.Point(22, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 44);
            this.panel3.TabIndex = 23;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(107, 25);
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
            this.lblSystemRecords.Location = new System.Drawing.Point(107, 5);
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
            this.lblSystemRecordstxt.Location = new System.Drawing.Point(3, 4);
            this.lblSystemRecordstxt.Name = "lblSystemRecordstxt";
            this.lblSystemRecordstxt.Size = new System.Drawing.Size(107, 15);
            this.lblSystemRecordstxt.TabIndex = 0;
            this.lblSystemRecordstxt.Text = "# System Records: ";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(10, 24);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(99, 15);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblStartDate.Location = new System.Drawing.Point(547, 53);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(69, 17);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblEndDate.Location = new System.Drawing.Point(716, 53);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(63, 17);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End Date";
            // 
            // errorProviderValidation
            // 
            this.errorProviderValidation.ContainerControl = this;
            // 
            // CMSLogin
            // 
            this.CMSLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSLogin.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowDetails});
            this.CMSLogin.Name = "CMSInternationalLicenseApp";
            this.CMSLogin.Size = new System.Drawing.Size(168, 40);
            // 
            // TSMIShowDetails
            // 
            this.TSMIShowDetails.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowDetails.Image")));
            this.TSMIShowDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowDetails.Name = "TSMIShowDetails";
            this.TSMIShowDetails.Size = new System.Drawing.Size(167, 36);
            this.TSMIShowDetails.Tag = "1";
            this.TSMIShowDetails.Text = "Show Details";
            this.TSMIShowDetails.Click += new System.EventHandler(this.TSMI_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblTitletxt);
            this.panel2.Controls.Add(this.PicBoxTitleImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 39);
            this.panel2.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(859, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "2";
            this.pictureBox1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(33, 7);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(119, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Login Register";
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
            this.btnClose.Location = new System.Drawing.Point(780, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 53;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 395);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.DGVLoginRegister);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Register";
            this.Load += new System.EventHandler(this.frmLoginRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoginRegister)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValidation)).EndInit();
            this.CMSLogin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVLoginRegister;
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.MaskedTextBox MskdTxtBoxEndDate;
        private System.Windows.Forms.MaskedTextBox MskdTxtBoxStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.ErrorProvider errorProviderValidation;
        private System.Windows.Forms.ContextMenuStrip CMSLogin;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowDetails;
        private System.Windows.Forms.TextBox txtBoxFilterBy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogoutTime;
        private System.Windows.Forms.Button btnClose;
    }
}