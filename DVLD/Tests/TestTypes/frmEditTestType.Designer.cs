namespace DVLD.Tests.TestTypes
{
    partial class frmEditTestType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTestType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.PicBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PicBoxTitleImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpBoxTestTypeIDInfo = new System.Windows.Forms.GroupBox();
            this.NumUpDownFees = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescriptiontxt = new System.Windows.Forms.Label();
            this.txtBoxTestTypeDescription = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.PicBoxID = new System.Windows.Forms.PictureBox();
            this.PicBoxTitle = new System.Windows.Forms.PictureBox();
            this.lblTitletxt = new System.Windows.Forms.Label();
            this.PicBoxFees = new System.Windows.Forms.PictureBox();
            this.lblFeestxt = new System.Windows.Forms.Label();
            this.txtBoxTestTypeTitle = new System.Windows.Forms.TextBox();
            this.lblIDtxt = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).BeginInit();
            this.grpBoxTestTypeIDInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.PicBox);
            this.panel1.Controls.Add(this.PicBoxClose);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.PicBoxTitleImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 33);
            this.panel1.TabIndex = 50;
            // 
            // PicBox
            // 
            this.PicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBox.Image = ((System.Drawing.Image)(resources.GetObject("PicBox.Image")));
            this.PicBox.Location = new System.Drawing.Point(428, 2);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(24, 24);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBox.TabIndex = 58;
            this.PicBox.TabStop = false;
            this.PicBox.Tag = "2";
            this.PicBox.Click += new System.EventHandler(this.Btn_Click);
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
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.lblTitle.Location = new System.Drawing.Point(32, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(114, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Tag = "";
            this.lblTitle.Text = "Edit Test Type";
            // 
            // PicBoxTitleImage
            // 
            this.PicBoxTitleImage.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitleImage.Image")));
            this.PicBoxTitleImage.Location = new System.Drawing.Point(5, 2);
            this.PicBoxTitleImage.Name = "PicBoxTitleImage";
            this.PicBoxTitleImage.Size = new System.Drawing.Size(24, 24);
            this.PicBoxTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBoxTitleImage.TabIndex = 45;
            this.PicBoxTitleImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(261, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 51;
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
            this.btnClose.Location = new System.Drawing.Point(352, 209);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 52;
            this.btnClose.Tag = "2";
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // grpBoxTestTypeIDInfo
            // 
            this.grpBoxTestTypeIDInfo.Controls.Add(this.NumUpDownFees);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.pictureBox1);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.lblDescriptiontxt);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.txtBoxTestTypeDescription);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.lblID);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.PicBoxID);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.PicBoxTitle);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.lblTitletxt);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.PicBoxFees);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.lblFeestxt);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.txtBoxTestTypeTitle);
            this.grpBoxTestTypeIDInfo.Controls.Add(this.lblIDtxt);
            this.grpBoxTestTypeIDInfo.Location = new System.Drawing.Point(11, 34);
            this.grpBoxTestTypeIDInfo.Name = "grpBoxTestTypeIDInfo";
            this.grpBoxTestTypeIDInfo.Size = new System.Drawing.Size(435, 170);
            this.grpBoxTestTypeIDInfo.TabIndex = 61;
            this.grpBoxTestTypeIDInfo.TabStop = false;
            // 
            // NumUpDownFees
            // 
            this.NumUpDownFees.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.NumUpDownFees.ForeColor = System.Drawing.Color.Firebrick;
            this.NumUpDownFees.Location = new System.Drawing.Point(117, 136);
            this.NumUpDownFees.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            262144});
            this.NumUpDownFees.Name = "NumUpDownFees";
            this.NumUpDownFees.ReadOnly = true;
            this.NumUpDownFees.Size = new System.Drawing.Size(308, 23);
            this.NumUpDownFees.TabIndex = 72;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(89, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescriptiontxt
            // 
            this.lblDescriptiontxt.AutoSize = true;
            this.lblDescriptiontxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescriptiontxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptiontxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblDescriptiontxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDescriptiontxt.Location = new System.Drawing.Point(7, 97);
            this.lblDescriptiontxt.Name = "lblDescriptiontxt";
            this.lblDescriptiontxt.Size = new System.Drawing.Size(79, 17);
            this.lblDescriptiontxt.TabIndex = 61;
            this.lblDescriptiontxt.Text = "Description:";
            // 
            // txtBoxTestTypeDescription
            // 
            this.txtBoxTestTypeDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxTestTypeDescription.Location = new System.Drawing.Point(117, 95);
            this.txtBoxTestTypeDescription.MaxLength = 300;
            this.txtBoxTestTypeDescription.Name = "txtBoxTestTypeDescription";
            this.txtBoxTestTypeDescription.Size = new System.Drawing.Size(308, 23);
            this.txtBoxTestTypeDescription.TabIndex = 67;
            this.txtBoxTestTypeDescription.Tag = "2";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(125)))), ((int)(((byte)(86)))));
            this.lblID.Location = new System.Drawing.Point(115, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(40, 17);
            this.lblID.TabIndex = 62;
            this.lblID.Text = "[????]";
            // 
            // PicBoxID
            // 
            this.PicBoxID.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxID.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxID.Image")));
            this.PicBoxID.Location = new System.Drawing.Point(89, 14);
            this.PicBoxID.Name = "PicBoxID";
            this.PicBoxID.Size = new System.Drawing.Size(20, 20);
            this.PicBoxID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxID.TabIndex = 70;
            this.PicBoxID.TabStop = false;
            // 
            // PicBoxTitle
            // 
            this.PicBoxTitle.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxTitle.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxTitle.Image")));
            this.PicBoxTitle.Location = new System.Drawing.Point(89, 55);
            this.PicBoxTitle.Name = "PicBoxTitle";
            this.PicBoxTitle.Size = new System.Drawing.Size(20, 20);
            this.PicBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxTitle.TabIndex = 68;
            this.PicBoxTitle.TabStop = false;
            // 
            // lblTitletxt
            // 
            this.lblTitletxt.AutoSize = true;
            this.lblTitletxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitletxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitletxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblTitletxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitletxt.Location = new System.Drawing.Point(50, 56);
            this.lblTitletxt.Name = "lblTitletxt";
            this.lblTitletxt.Size = new System.Drawing.Size(36, 17);
            this.lblTitletxt.TabIndex = 63;
            this.lblTitletxt.Text = "Title:";
            // 
            // PicBoxFees
            // 
            this.PicBoxFees.BackColor = System.Drawing.SystemColors.Control;
            this.PicBoxFees.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxFees.Image")));
            this.PicBoxFees.Location = new System.Drawing.Point(89, 137);
            this.PicBoxFees.Name = "PicBoxFees";
            this.PicBoxFees.Size = new System.Drawing.Size(20, 20);
            this.PicBoxFees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxFees.TabIndex = 69;
            this.PicBoxFees.TabStop = false;
            // 
            // lblFeestxt
            // 
            this.lblFeestxt.AutoSize = true;
            this.lblFeestxt.BackColor = System.Drawing.SystemColors.Control;
            this.lblFeestxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeestxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblFeestxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFeestxt.Location = new System.Drawing.Point(48, 138);
            this.lblFeestxt.Name = "lblFeestxt";
            this.lblFeestxt.Size = new System.Drawing.Size(38, 17);
            this.lblFeestxt.TabIndex = 64;
            this.lblFeestxt.Text = "Fees:";
            // 
            // txtBoxTestTypeTitle
            // 
            this.txtBoxTestTypeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxTestTypeTitle.Location = new System.Drawing.Point(117, 54);
            this.txtBoxTestTypeTitle.MaxLength = 75;
            this.txtBoxTestTypeTitle.Name = "txtBoxTestTypeTitle";
            this.txtBoxTestTypeTitle.ReadOnly = true;
            this.txtBoxTestTypeTitle.Size = new System.Drawing.Size(308, 23);
            this.txtBoxTestTypeTitle.TabIndex = 65;
            this.txtBoxTestTypeTitle.Tag = "1";
            // 
            // lblIDtxt
            // 
            this.lblIDtxt.AutoSize = true;
            this.lblIDtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblIDtxt.Location = new System.Drawing.Point(6, 15);
            this.lblIDtxt.Name = "lblIDtxt";
            this.lblIDtxt.Size = new System.Drawing.Size(80, 17);
            this.lblIDtxt.TabIndex = 66;
            this.lblIDtxt.Text = "Test TypeID:";
            // 
            // frmEditTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 248);
            this.Controls.Add(this.grpBoxTestTypeIDInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditTestType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Edit Test Type";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitleImage)).EndInit();
            this.grpBoxTestTypeIDInfo.ResumeLayout(false);
            this.grpBoxTestTypeIDInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxFees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.PictureBox PicBoxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox PicBoxTitleImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpBoxTestTypeIDInfo;
        private System.Windows.Forms.NumericUpDown NumUpDownFees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescriptiontxt;
        private System.Windows.Forms.TextBox txtBoxTestTypeDescription;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox PicBoxID;
        private System.Windows.Forms.PictureBox PicBoxTitle;
        private System.Windows.Forms.Label lblTitletxt;
        private System.Windows.Forms.PictureBox PicBoxFees;
        private System.Windows.Forms.Label lblFeestxt;
        private System.Windows.Forms.TextBox txtBoxTestTypeTitle;
        private System.Windows.Forms.Label lblIDtxt;
    }
}