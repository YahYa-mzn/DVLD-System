namespace DVLD.Licenses.Controls
{
    partial class ctrlLicenseCardWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLicenseCardWithFilter));
            this.CtrlLicenseCard = new DVLD.Licenses.Controls.ctrlLicenseCard();
            this.grpBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.CmbBoxFilter = new System.Windows.Forms.ComboBox();
            this.grpBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlLicenseCard
            // 
            this.CtrlLicenseCard.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlLicenseCard.Location = new System.Drawing.Point(2, 61);
            this.CtrlLicenseCard.Name = "CtrlLicenseCard";
            this.CtrlLicenseCard.Size = new System.Drawing.Size(599, 314);
            this.CtrlLicenseCard.TabIndex = 0;
            // 
            // grpBoxFilter
            // 
            this.grpBoxFilter.Controls.Add(this.btnFindLicense);
            this.grpBoxFilter.Controls.Add(this.btnReset);
            this.grpBoxFilter.Controls.Add(this.txtBoxFilter);
            this.grpBoxFilter.Controls.Add(this.CmbBoxFilter);
            this.grpBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.grpBoxFilter.Location = new System.Drawing.Point(4, 2);
            this.grpBoxFilter.Name = "grpBoxFilter";
            this.grpBoxFilter.Size = new System.Drawing.Size(593, 59);
            this.grpBoxFilter.TabIndex = 2;
            this.grpBoxFilter.TabStop = false;
            this.grpBoxFilter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnFindLicense.Image")));
            this.btnFindLicense.Location = new System.Drawing.Point(473, 15);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(41, 36);
            this.btnFindLicense.TabIndex = 8;
            this.btnFindLicense.Tag = "3";
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(544, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(41, 36);
            this.btnReset.TabIndex = 7;
            this.btnReset.Tag = "3";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.txtBoxFilter.Location = new System.Drawing.Point(237, 22);
            this.txtBoxFilter.MaxLength = 100;
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(230, 23);
            this.txtBoxFilter.TabIndex = 1;
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFilter_KeyPress);
            // 
            // CmbBoxFilter
            // 
            this.CmbBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxFilter.FormattingEnabled = true;
            this.CmbBoxFilter.Items.AddRange(new object[] {
            "LicenseID",
            "SerialNumber"});
            this.CmbBoxFilter.Location = new System.Drawing.Point(12, 21);
            this.CmbBoxFilter.Name = "CmbBoxFilter";
            this.CmbBoxFilter.Size = new System.Drawing.Size(219, 25);
            this.CmbBoxFilter.TabIndex = 0;
            this.CmbBoxFilter.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilter_SelectedIndexChanged);
            // 
            // ctrlLicenseCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxFilter);
            this.Controls.Add(this.CtrlLicenseCard);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlLicenseCardWithFilter";
            this.Size = new System.Drawing.Size(603, 374);
            this.grpBoxFilter.ResumeLayout(false);
            this.grpBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBoxFilter;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.ComboBox CmbBoxFilter;
        public ctrlLicenseCard CtrlLicenseCard;
    }
}
