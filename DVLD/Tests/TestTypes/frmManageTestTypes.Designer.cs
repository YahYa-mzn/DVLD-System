namespace DVLD.Tests.TestTypes
{
    partial class frmManageTestTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTestTypes));
            this.DGVTestTypes = new System.Windows.Forms.DataGridView();
            this.colTestTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestTypeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestTypeFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMSTestType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTestTypes)).BeginInit();
            this.CMSTestType.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVTestTypes
            // 
            this.DGVTestTypes.AllowUserToAddRows = false;
            this.DGVTestTypes.AllowUserToDeleteRows = false;
            this.DGVTestTypes.AllowUserToOrderColumns = true;
            this.DGVTestTypes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVTestTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTestTypeID,
            this.colTestTypeTitle,
            this.colTestTypeDescription,
            this.colTestTypeFees});
            this.DGVTestTypes.Location = new System.Drawing.Point(2, 43);
            this.DGVTestTypes.Name = "DGVTestTypes";
            this.DGVTestTypes.ReadOnly = true;
            this.DGVTestTypes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVTestTypes.RowHeadersVisible = false;
            this.DGVTestTypes.Size = new System.Drawing.Size(733, 130);
            this.DGVTestTypes.TabIndex = 0;
            this.DGVTestTypes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTestTypes_CellDoubleClick);
            this.DGVTestTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVTestTypes_CellMouseDown);
            // 
            // colTestTypeID
            // 
            this.colTestTypeID.HeaderText = "TestTypeID";
            this.colTestTypeID.Name = "colTestTypeID";
            this.colTestTypeID.ReadOnly = true;
            // 
            // colTestTypeTitle
            // 
            this.colTestTypeTitle.HeaderText = "TestTypeTitle";
            this.colTestTypeTitle.Name = "colTestTypeTitle";
            this.colTestTypeTitle.ReadOnly = true;
            this.colTestTypeTitle.Width = 130;
            // 
            // colTestTypeDescription
            // 
            this.colTestTypeDescription.HeaderText = "TestTypeDescription";
            this.colTestTypeDescription.Name = "colTestTypeDescription";
            this.colTestTypeDescription.ReadOnly = true;
            this.colTestTypeDescription.Width = 370;
            // 
            // colTestTypeFees
            // 
            this.colTestTypeFees.HeaderText = "TestTypeFees";
            this.colTestTypeFees.Name = "colTestTypeFees";
            this.colTestTypeFees.ReadOnly = true;
            this.colTestTypeFees.Width = 130;
            // 
            // CMSTestType
            // 
            this.CMSTestType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSTestType.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSTestType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIEdit});
            this.CMSTestType.Name = "CMSInternationalLicenseApp";
            this.CMSTestType.Size = new System.Drawing.Size(114, 40);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitletxt);
            this.panel1.Controls.Add(this.PicBoxTitleImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 33);
            this.panel1.TabIndex = 48;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(707, 3);
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
            this.lblTitletxt.Location = new System.Drawing.Point(34, 4);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(153, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "Manage Test Types";
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
            this.btnClose.Location = new System.Drawing.Point(622, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 55;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 213);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVTestTypes);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Types";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTestTypes)).EndInit();
            this.CMSTestType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVTestTypes;
        private System.Windows.Forms.ContextMenuStrip CMSTestType;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestTypeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestTypeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestTypeFees;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnClose;
    }
}