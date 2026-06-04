namespace DVLD.Applications.ApplicationTypes
{
    partial class frmManageApplicationTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageApplicationTypes));
            this.DGVAppTypes = new System.Windows.Forms.DataGridView();
            this.colAppTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppTypeFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSAppType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblRecordstxt = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppTypes)).BeginInit();
            this.CMSAppType.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVAppTypes
            // 
            this.DGVAppTypes.AllowUserToAddRows = false;
            this.DGVAppTypes.AllowUserToDeleteRows = false;
            this.DGVAppTypes.AllowUserToOrderColumns = true;
            this.DGVAppTypes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVAppTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppTypeID,
            this.colAppTypeName,
            this.colAppTypeFees});
            this.DGVAppTypes.Location = new System.Drawing.Point(2, 41);
            this.DGVAppTypes.Name = "DGVAppTypes";
            this.DGVAppTypes.ReadOnly = true;
            this.DGVAppTypes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVAppTypes.RowHeadersVisible = false;
            this.DGVAppTypes.Size = new System.Drawing.Size(573, 249);
            this.DGVAppTypes.TabIndex = 0;
            this.DGVAppTypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAppTypes_CellDoubleClick);
            this.DGVAppTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVAppTypes_CellMouseDown);
            // 
            // colAppTypeID
            // 
            this.colAppTypeID.HeaderText = "AppTypeID";
            this.colAppTypeID.Name = "colAppTypeID";
            this.colAppTypeID.ReadOnly = true;
            this.colAppTypeID.Width = 140;
            // 
            // colAppTypeName
            // 
            this.colAppTypeName.HeaderText = "AppTypeName";
            this.colAppTypeName.Name = "colAppTypeName";
            this.colAppTypeName.ReadOnly = true;
            this.colAppTypeName.Width = 270;
            // 
            // colAppTypeFees
            // 
            this.colAppTypeFees.HeaderText = "AppTypeFees";
            this.colAppTypeFees.Name = "colAppTypeFees";
            this.colAppTypeFees.ReadOnly = true;
            this.colAppTypeFees.Width = 160;
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.Image = ((System.Drawing.Image)(resources.GetObject("TSMIEdit.Image")));
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.Size = new System.Drawing.Size(113, 36);
            this.TSMIEdit.Tag = "2";
            this.TSMIEdit.Text = "Edit";
            this.TSMIEdit.Click += new System.EventHandler(this.TSMIEdit_Click);
            // 
            // CMSAppType
            // 
            this.CMSAppType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSAppType.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSAppType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIEdit});
            this.CMSAppType.Name = "CMSInternationalLicenseApp";
            this.CMSAppType.Size = new System.Drawing.Size(114, 40);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRecords);
            this.panel3.Controls.Add(this.lblRecordstxt);
            this.panel3.Location = new System.Drawing.Point(12, 295);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(138, 27);
            this.panel3.TabIndex = 0;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecords.Location = new System.Drawing.Point(108, 6);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(13, 13);
            this.lblRecords.TabIndex = 0;
            this.lblRecords.Text = "0";
            // 
            // lblRecordstxt
            // 
            this.lblRecordstxt.AutoSize = true;
            this.lblRecordstxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordstxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblRecordstxt.Location = new System.Drawing.Point(6, 6);
            this.lblRecordstxt.Name = "lblRecordstxt";
            this.lblRecordstxt.Size = new System.Drawing.Size(98, 13);
            this.lblRecordstxt.TabIndex = 0;
            this.lblRecordstxt.Text = "# Listed Records: ";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTitle.Controls.Add(this.PicBoxClose);
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Controls.Add(this.lblTitletxt);
            this.pnlTitle.Controls.Add(this.PicBoxTitleImage);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(576, 33);
            this.pnlTitle.TabIndex = 48;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(547, 3);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 47;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(744, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(34, 4);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(212, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Manage Application Types";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(7, 3);
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
            this.btnClose.Location = new System.Drawing.Point(476, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 49;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 333);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DGVAppTypes);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Types";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppTypes)).EndInit();
            this.CMSAppType.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVAppTypes;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ContextMenuStrip CMSAppType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppTypeFees;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblRecordstxt;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Button btnClose;
    }
}