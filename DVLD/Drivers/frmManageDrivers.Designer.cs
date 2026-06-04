namespace DVLD.Drivers
{
    partial class frmManageDrivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDrivers));
            this.DGVDrivers = new System.Windows.Forms.DataGridView();
            this.colDriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSep2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActiveLicenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblSystemRecords = new System.Windows.Forms.Label();
            this.lblSystemRecordstxt = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicBoxRefresh = new System.Windows.Forms.PictureBox();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CmbBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.lblFilterBytxt = new System.Windows.Forms.Label();
            this.CMSDriver = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDrivers)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).BeginInit();
            this.CMSDriver.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVDrivers
            // 
            this.DGVDrivers.AllowUserToAddRows = false;
            this.DGVDrivers.AllowUserToDeleteRows = false;
            this.DGVDrivers.AllowUserToOrderColumns = true;
            this.DGVDrivers.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDriverID,
            this.colSep1,
            this.colPersonID,
            this.colNationalNo,
            this.colFullName,
            this.colSep2,
            this.colCreationDate,
            this.colActiveLicenses});
            this.DGVDrivers.Location = new System.Drawing.Point(1, 117);
            this.DGVDrivers.Name = "DGVDrivers";
            this.DGVDrivers.ReadOnly = true;
            this.DGVDrivers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVDrivers.Size = new System.Drawing.Size(903, 266);
            this.DGVDrivers.TabIndex = 23;
            this.DGVDrivers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDrivers_CellDoubleClick);
            this.DGVDrivers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVDrivers_CellMouseDown);
            // 
            // colDriverID
            // 
            this.colDriverID.HeaderText = "DriverID";
            this.colDriverID.Name = "colDriverID";
            this.colDriverID.ReadOnly = true;
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
            // colCreationDate
            // 
            this.colCreationDate.HeaderText = "Creation Date";
            this.colCreationDate.Name = "colCreationDate";
            this.colCreationDate.ReadOnly = true;
            this.colCreationDate.Width = 150;
            // 
            // colActiveLicenses
            // 
            this.colActiveLicenses.HeaderText = "Active Licenses";
            this.colActiveLicenses.Name = "colActiveLicenses";
            this.colActiveLicenses.ReadOnly = true;
            this.colActiveLicenses.Width = 110;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRecords);
            this.panel3.Controls.Add(this.lblSystemRecords);
            this.panel3.Controls.Add(this.lblSystemRecordstxt);
            this.panel3.Controls.Add(this.lblRecordstxt);
            this.panel3.Location = new System.Drawing.Point(21, 389);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 40);
            this.panel3.TabIndex = 22;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PicBoxRefresh);
            this.panel1.Controls.Add(this.txtBoxFilter);
            this.panel1.Controls.Add(this.CmbBoxFilterBy);
            this.panel1.Controls.Add(this.lblFilterBytxt);
            this.panel1.Location = new System.Drawing.Point(9, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 37);
            this.panel1.TabIndex = 21;
            // 
            // PicBoxRefresh
            // 
            this.PicBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxRefresh.Image")));
            this.PicBoxRefresh.Location = new System.Drawing.Point(851, 5);
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
            this.txtBoxFilter.Location = new System.Drawing.Point(448, 7);
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(395, 22);
            this.txtBoxFilter.TabIndex = 2;
            this.txtBoxFilter.TextChanged += new System.EventHandler(this.txtBoxFilter_TextChanged);
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilter_KeyPress);
            // 
            // CmbBoxFilterBy
            // 
            this.CmbBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.CmbBoxFilterBy.FormattingEnabled = true;
            this.CmbBoxFilterBy.Items.AddRange(new object[] {
            "None",
            "DriverID",
            "PersonID",
            "NationalNo"});
            this.CmbBoxFilterBy.Location = new System.Drawing.Point(67, 5);
            this.CmbBoxFilterBy.Name = "CmbBoxFilterBy";
            this.CmbBoxFilterBy.Size = new System.Drawing.Size(370, 25);
            this.CmbBoxFilterBy.TabIndex = 1;
            this.CmbBoxFilterBy.Tag = "";
            this.CmbBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilterBy_SelectedIndexChanged);
            // 
            // lblFilterBytxt
            // 
            this.lblFilterBytxt.AutoSize = true;
            this.lblFilterBytxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBytxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFilterBytxt.Location = new System.Drawing.Point(7, 9);
            this.lblFilterBytxt.Name = "lblFilterBytxt";
            this.lblFilterBytxt.Size = new System.Drawing.Size(57, 17);
            this.lblFilterBytxt.TabIndex = 25;
            this.lblFilterBytxt.Text = "Filter By";
            // 
            // CMSDriver
            // 
            this.CMSDriver.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSDriver.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSDriver.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowLicenseHistory});
            this.CMSDriver.Name = "CMSInternationalLicenseApp";
            this.CMSDriver.Size = new System.Drawing.Size(220, 40);
            // 
            // TSMIShowLicenseHistory
            // 
            this.TSMIShowLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowLicenseHistory.Image")));
            this.TSMIShowLicenseHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowLicenseHistory.Name = "TSMIShowLicenseHistory";
            this.TSMIShowLicenseHistory.Size = new System.Drawing.Size(219, 36);
            this.TSMIShowLicenseHistory.Tag = "1";
            this.TSMIShowLicenseHistory.Text = "Show License History";
            this.TSMIShowLicenseHistory.Click += new System.EventHandler(this.TSMIShowLicenseHistory_Click);
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
            this.panel2.Size = new System.Drawing.Size(905, 46);
            this.panel2.TabIndex = 48;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(875, 9);
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
            this.lblTitletxt.Location = new System.Drawing.Point(40, 12);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(130, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Manage Drivers";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(5, 6);
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
            this.btnClose.Location = new System.Drawing.Point(799, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 53;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 436);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGVDrivers);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drivers";
            this.Load += new System.EventHandler(this.frmManageDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDrivers)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxRefresh)).EndInit();
            this.CMSDriver.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVDrivers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblSystemRecords;
        private System.Windows.Forms.Label lblSystemRecordstxt;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilterBy;
        private System.Windows.Forms.ContextMenuStrip CMSDriver;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowLicenseHistory;
        private System.Windows.Forms.Label lblFilterBytxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSep2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActiveLicenses;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.PictureBox PicBoxRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}