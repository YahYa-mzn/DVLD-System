namespace DVLD.Drivers
{
    partial class frmDriverLicenseHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDriverLicenseHistory));
            this.PicBoxUsers = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxTitle = new System.Windows.Forms.PictureBox();
            this.CtrlPersonCard = new DVLD.People.CtrlPersonCard();
            this.CtrlDriverLicenses = new DVLD.Licenses.Controls.ctrlDriverLicenses();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUsers)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxUsers
            // 
            this.PicBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicBoxUsers.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxUsers.Image")));
            this.PicBoxUsers.Location = new System.Drawing.Point(8, 60);
            this.PicBoxUsers.Name = "PicBoxUsers";
            this.PicBoxUsers.Size = new System.Drawing.Size(241, 181);
            this.PicBoxUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxUsers.TabIndex = 2;
            this.PicBoxUsers.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PicBoxClose);
            this.panel2.Controls.Add(this.lblTitletxt);
            this.panel2.Controls.Add(this.PicBoxTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 47);
            this.panel2.TabIndex = 52;
            // 
            // PicBoxClose
            // 
            this.PicBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxClose.Image")));
            this.PicBoxClose.Location = new System.Drawing.Point(861, 9);
            this.PicBoxClose.Name = "PicBoxClose";
            this.PicBoxClose.Size = new System.Drawing.Size(24, 24);
            this.PicBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxClose.TabIndex = 47;
            this.PicBoxClose.TabStop = false;
            this.PicBoxClose.Tag = "2";
            this.PicBoxClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitletxt.Location = new System.Drawing.Point(41, 11);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(126, 21);
            this.lblTitletxt.TabIndex = 0;
            this.lblTitletxt.Tag = "";
            this.lblTitletxt.Text = "License History";
            // 
            // PicBoxTitle
            // 
            this.PicBoxTitle.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitle.Image")));
            this.PicBoxTitle.Location = new System.Drawing.Point(6, 5);
            this.PicBoxTitle.Name = "PicBoxTitle";
            this.PicBoxTitle.Size = new System.Drawing.Size(32, 32);
            this.PicBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitle.TabIndex = 45;
            this.PicBoxTitle.TabStop = false;
            // 
            // CtrlPersonCard
            // 
            this.CtrlPersonCard.Location = new System.Drawing.Point(255, 53);
            this.CtrlPersonCard.Name = "CtrlPersonCard";
            this.CtrlPersonCard.Size = new System.Drawing.Size(635, 216);
            this.CtrlPersonCard.TabIndex = 1;
            // 
            // CtrlDriverLicenses
            // 
            this.CtrlDriverLicenses.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlDriverLicenses.Location = new System.Drawing.Point(3, 243);
            this.CtrlDriverLicenses.Name = "CtrlDriverLicenses";
            this.CtrlDriverLicenses.Size = new System.Drawing.Size(884, 331);
            this.CtrlDriverLicenses.TabIndex = 0;
            // 
            // frmDriverLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PicBoxUsers);
            this.Controls.Add(this.CtrlPersonCard);
            this.Controls.Add(this.CtrlDriverLicenses);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDriverLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUsers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Licenses.Controls.ctrlDriverLicenses CtrlDriverLicenses;
        private People.CtrlPersonCard CtrlPersonCard;
        private System.Windows.Forms.PictureBox PicBoxUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxTitle;
    }
}