namespace DVLD.Licenses.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDriverLicenses));
            this.TabCtrlDriverLicenses = new System.Windows.Forms.TabControl();
            this.PgLocalLicenses = new System.Windows.Forms.TabPage();
            this.DGVLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLocalLicensesRecords = new System.Windows.Forms.Label();
            this.lblLocalLicensesRecordstxt = new System.Windows.Forms.Label();
            this.pnlLocalLicenses = new System.Windows.Forms.Panel();
            this.lblLocalLicensestxt = new System.Windows.Forms.Label();
            this.PgInternationalLicenses = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInternationalLicenseRecords = new System.Windows.Forms.Label();
            this.lblInternationalLicenseRecordstxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVInternationalLicense = new System.Windows.Forms.DataGridView();
            this.CMSLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIShowInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.colLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewImageColumn();
            this.colInternationalLicense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInternationalSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.TabCtrlDriverLicenses.SuspendLayout();
            this.PgLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicense)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlLocalLicenses.SuspendLayout();
            this.PgInternationalLicenses.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicense)).BeginInit();
            this.CMSLicense.SuspendLayout();
            this.CMSInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrlDriverLicenses
            // 
            this.TabCtrlDriverLicenses.Controls.Add(this.PgLocalLicenses);
            this.TabCtrlDriverLicenses.Controls.Add(this.PgInternationalLicenses);
            this.TabCtrlDriverLicenses.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCtrlDriverLicenses.Location = new System.Drawing.Point(3, 4);
            this.TabCtrlDriverLicenses.Name = "TabCtrlDriverLicenses";
            this.TabCtrlDriverLicenses.SelectedIndex = 0;
            this.TabCtrlDriverLicenses.Size = new System.Drawing.Size(881, 324);
            this.TabCtrlDriverLicenses.TabIndex = 0;
            // 
            // PgLocalLicenses
            // 
            this.PgLocalLicenses.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PgLocalLicenses.Controls.Add(this.DGVLocalDrivingLicense);
            this.PgLocalLicenses.Controls.Add(this.panel3);
            this.PgLocalLicenses.Controls.Add(this.pnlLocalLicenses);
            this.PgLocalLicenses.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PgLocalLicenses.Location = new System.Drawing.Point(4, 24);
            this.PgLocalLicenses.Name = "PgLocalLicenses";
            this.PgLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.PgLocalLicenses.Size = new System.Drawing.Size(873, 296);
            this.PgLocalLicenses.TabIndex = 0;
            this.PgLocalLicenses.Text = "Local Licenses";
            // 
            // DGVLocalDrivingLicense
            // 
            this.DGVLocalDrivingLicense.AllowUserToAddRows = false;
            this.DGVLocalDrivingLicense.AllowUserToDeleteRows = false;
            this.DGVLocalDrivingLicense.AllowUserToOrderColumns = true;
            this.DGVLocalDrivingLicense.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVLocalDrivingLicense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLicenseID,
            this.colSerialNumber,
            this.colLicenseClass,
            this.colApplicationID,
            this.colIssueDate,
            this.colExpirationDate,
            this.colIsActive});
            this.DGVLocalDrivingLicense.Location = new System.Drawing.Point(2, 49);
            this.DGVLocalDrivingLicense.Name = "DGVLocalDrivingLicense";
            this.DGVLocalDrivingLicense.ReadOnly = true;
            this.DGVLocalDrivingLicense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVLocalDrivingLicense.RowHeadersVisible = false;
            this.DGVLocalDrivingLicense.Size = new System.Drawing.Size(868, 213);
            this.DGVLocalDrivingLicense.TabIndex = 16;
            this.DGVLocalDrivingLicense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLocalDrivingLicense_CellDoubleClick);
            this.DGVLocalDrivingLicense.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVLocalDrivingLicense_CellMouseDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblLocalLicensesRecords);
            this.panel3.Controls.Add(this.lblLocalLicensesRecordstxt);
            this.panel3.Location = new System.Drawing.Point(29, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 25);
            this.panel3.TabIndex = 50;
            // 
            // lblLocalLicensesRecords
            // 
            this.lblLocalLicensesRecords.AutoSize = true;
            this.lblLocalLicensesRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLocalLicensesRecords.Location = new System.Drawing.Point(100, 5);
            this.lblLocalLicensesRecords.Name = "lblLocalLicensesRecords";
            this.lblLocalLicensesRecords.Size = new System.Drawing.Size(13, 13);
            this.lblLocalLicensesRecords.TabIndex = 7;
            this.lblLocalLicensesRecords.Text = "0";
            // 
            // lblLocalLicensesRecordstxt
            // 
            this.lblLocalLicensesRecordstxt.AutoSize = true;
            this.lblLocalLicensesRecordstxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesRecordstxt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLocalLicensesRecordstxt.Location = new System.Drawing.Point(5, 5);
            this.lblLocalLicensesRecordstxt.Name = "lblLocalLicensesRecordstxt";
            this.lblLocalLicensesRecordstxt.Size = new System.Drawing.Size(98, 13);
            this.lblLocalLicensesRecordstxt.TabIndex = 0;
            this.lblLocalLicensesRecordstxt.Text = "# Listed Records: ";
            // 
            // pnlLocalLicenses
            // 
            this.pnlLocalLicenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLocalLicenses.Controls.Add(this.lblLocalLicensestxt);
            this.pnlLocalLicenses.Location = new System.Drawing.Point(14, 16);
            this.pnlLocalLicenses.Name = "pnlLocalLicenses";
            this.pnlLocalLicenses.Size = new System.Drawing.Size(93, 27);
            this.pnlLocalLicenses.TabIndex = 49;
            // 
            // lblLocalLicensestxt
            // 
            this.lblLocalLicensestxt.AutoSize = true;
            this.lblLocalLicensestxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensestxt.ForeColor = System.Drawing.Color.Black;
            this.lblLocalLicensestxt.Location = new System.Drawing.Point(4, 5);
            this.lblLocalLicensestxt.Name = "lblLocalLicensestxt";
            this.lblLocalLicensestxt.Size = new System.Drawing.Size(82, 15);
            this.lblLocalLicensestxt.TabIndex = 47;
            this.lblLocalLicensestxt.Text = "Local Licenses";
            // 
            // PgInternationalLicenses
            // 
            this.PgInternationalLicenses.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PgInternationalLicenses.Controls.Add(this.panel1);
            this.PgInternationalLicenses.Controls.Add(this.panel2);
            this.PgInternationalLicenses.Controls.Add(this.DGVInternationalLicense);
            this.PgInternationalLicenses.Location = new System.Drawing.Point(4, 24);
            this.PgInternationalLicenses.Name = "PgInternationalLicenses";
            this.PgInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.PgInternationalLicenses.Size = new System.Drawing.Size(873, 296);
            this.PgInternationalLicenses.TabIndex = 1;
            this.PgInternationalLicenses.Text = "International Licenses";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInternationalLicenseRecords);
            this.panel1.Controls.Add(this.lblInternationalLicenseRecordstxt);
            this.panel1.Location = new System.Drawing.Point(29, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 25);
            this.panel1.TabIndex = 53;
            // 
            // lblInternationalLicenseRecords
            // 
            this.lblInternationalLicenseRecords.AutoSize = true;
            this.lblInternationalLicenseRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInternationalLicenseRecords.Location = new System.Drawing.Point(100, 5);
            this.lblInternationalLicenseRecords.Name = "lblInternationalLicenseRecords";
            this.lblInternationalLicenseRecords.Size = new System.Drawing.Size(13, 13);
            this.lblInternationalLicenseRecords.TabIndex = 7;
            this.lblInternationalLicenseRecords.Text = "0";
            // 
            // lblInternationalLicenseRecordstxt
            // 
            this.lblInternationalLicenseRecordstxt.AutoSize = true;
            this.lblInternationalLicenseRecordstxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseRecordstxt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInternationalLicenseRecordstxt.Location = new System.Drawing.Point(5, 5);
            this.lblInternationalLicenseRecordstxt.Name = "lblInternationalLicenseRecordstxt";
            this.lblInternationalLicenseRecordstxt.Size = new System.Drawing.Size(98, 13);
            this.lblInternationalLicenseRecordstxt.TabIndex = 0;
            this.lblInternationalLicenseRecordstxt.Text = "# Listed Records: ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(14, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 27);
            this.panel2.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "International Licenses";
            // 
            // DGVInternationalLicense
            // 
            this.DGVInternationalLicense.AllowUserToAddRows = false;
            this.DGVInternationalLicense.AllowUserToDeleteRows = false;
            this.DGVInternationalLicense.AllowUserToOrderColumns = true;
            this.DGVInternationalLicense.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVInternationalLicense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInternationalLicense,
            this.colInternationalSerialNumber,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.DGVInternationalLicense.Location = new System.Drawing.Point(2, 49);
            this.DGVInternationalLicense.Name = "DGVInternationalLicense";
            this.DGVInternationalLicense.ReadOnly = true;
            this.DGVInternationalLicense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVInternationalLicense.RowHeadersVisible = false;
            this.DGVInternationalLicense.Size = new System.Drawing.Size(868, 213);
            this.DGVInternationalLicense.TabIndex = 51;
            this.DGVInternationalLicense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInternationalLicensesList_CellDoubleClick);
            this.DGVInternationalLicense.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVInternationalLicensesList_CellMouseDown);
            // 
            // CMSLicense
            // 
            this.CMSLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSLicense.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowLicense});
            this.CMSLicense.Name = "CMSInternationalLicenseApp";
            this.CMSLicense.Size = new System.Drawing.Size(171, 40);
            // 
            // TSMIShowLicense
            // 
            this.TSMIShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowLicense.Image")));
            this.TSMIShowLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowLicense.Name = "TSMIShowLicense";
            this.TSMIShowLicense.Size = new System.Drawing.Size(170, 36);
            this.TSMIShowLicense.Tag = "1";
            this.TSMIShowLicense.Text = "Show License";
            this.TSMIShowLicense.Click += new System.EventHandler(this.TSMIShowLicense_Click);
            // 
            // CMSInternationalLicense
            // 
            this.CMSInternationalLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSInternationalLicense.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.CMSInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIShowInternationalLicense});
            this.CMSInternationalLicense.Name = "CMSInternationalLicenseApp";
            this.CMSInternationalLicense.Size = new System.Drawing.Size(253, 40);
            // 
            // TSMIShowInternationalLicense
            // 
            this.TSMIShowInternationalLicense.Image = ((System.Drawing.Image)(resources.GetObject("TSMIShowInternationalLicense.Image")));
            this.TSMIShowInternationalLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSMIShowInternationalLicense.Name = "TSMIShowInternationalLicense";
            this.TSMIShowInternationalLicense.Size = new System.Drawing.Size(252, 36);
            this.TSMIShowInternationalLicense.Tag = "1";
            this.TSMIShowInternationalLicense.Text = "Show International License";
            this.TSMIShowInternationalLicense.Click += new System.EventHandler(this.TSMIShowInternationalLicense_Click);
            // 
            // colLicenseID
            // 
            this.colLicenseID.HeaderText = "LicenseID";
            this.colLicenseID.Name = "colLicenseID";
            this.colLicenseID.ReadOnly = true;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.HeaderText = "Serial Number";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 140;
            // 
            // colLicenseClass
            // 
            this.colLicenseClass.HeaderText = "License Class";
            this.colLicenseClass.Name = "colLicenseClass";
            this.colLicenseClass.ReadOnly = true;
            this.colLicenseClass.Width = 165;
            // 
            // colApplicationID
            // 
            this.colApplicationID.HeaderText = "ApplicationID";
            this.colApplicationID.Name = "colApplicationID";
            this.colApplicationID.ReadOnly = true;
            this.colApplicationID.Width = 110;
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
            this.colIsActive.HeaderText = "Is Active";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            this.colIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsActive.Width = 90;
            // 
            // colInternationalLicense
            // 
            this.colInternationalLicense.Frozen = true;
            this.colInternationalLicense.HeaderText = "International License";
            this.colInternationalLicense.Name = "colInternationalLicense";
            this.colInternationalLicense.ReadOnly = true;
            this.colInternationalLicense.Width = 145;
            // 
            // colInternationalSerialNumber
            // 
            this.colInternationalSerialNumber.Frozen = true;
            this.colInternationalSerialNumber.HeaderText = "Serial Number";
            this.colInternationalSerialNumber.Name = "colInternationalSerialNumber";
            this.colInternationalSerialNumber.ReadOnly = true;
            this.colInternationalSerialNumber.Width = 180;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "LicenseID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "ApplicationID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Expiration Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Is Active";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabCtrlDriverLicenses);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(884, 327);
            this.TabCtrlDriverLicenses.ResumeLayout(false);
            this.PgLocalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLocalDrivingLicense)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlLocalLicenses.ResumeLayout(false);
            this.pnlLocalLicenses.PerformLayout();
            this.PgInternationalLicenses.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInternationalLicense)).EndInit();
            this.CMSLicense.ResumeLayout(false);
            this.CMSInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrlDriverLicenses;
        private System.Windows.Forms.TabPage PgLocalLicenses;
        private System.Windows.Forms.TabPage PgInternationalLicenses;
        private System.Windows.Forms.DataGridView DGVLocalDrivingLicense;
        private System.Windows.Forms.Panel pnlLocalLicenses;
        private System.Windows.Forms.Label lblLocalLicensestxt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLocalLicensesRecords;
        private System.Windows.Forms.Label lblLocalLicensesRecordstxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInternationalLicenseRecords;
        private System.Windows.Forms.Label lblInternationalLicenseRecordstxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGVInternationalLicense;
        private System.Windows.Forms.ContextMenuStrip CMSLicense;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowLicense;
        private System.Windows.Forms.ContextMenuStrip CMSInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowInternationalLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewImageColumn colIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternationalLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternationalSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewTextBoxColumn6;
    }
}
