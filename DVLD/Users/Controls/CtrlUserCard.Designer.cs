namespace DVLD.Users.Users.Controls
{
    partial class CtrlUserCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlUserCard));
            this.grpBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatustxt = new System.Windows.Forms.Label();
            this.PicBoxStatus = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.PicBoxUsername = new System.Windows.Forms.PictureBox();
            this.PicBoxUserID = new System.Windows.Forms.PictureBox();
            this.lblUserIDtxt = new System.Windows.Forms.Label();
            this.lblUserNametxt = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ctrlPersonCard = new DVLD.People.CtrlPersonCard();
            this.grpBoxUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserID)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxUserInfo
            // 
            this.grpBoxUserInfo.Controls.Add(this.lblStatus);
            this.grpBoxUserInfo.Controls.Add(this.lblStatustxt);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxStatus);
            this.grpBoxUserInfo.Controls.Add(this.lblUserID);
            this.grpBoxUserInfo.Controls.Add(this.lblUsername);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxUsername);
            this.grpBoxUserInfo.Controls.Add(this.PicBoxUserID);
            this.grpBoxUserInfo.Controls.Add(this.lblUserIDtxt);
            this.grpBoxUserInfo.Controls.Add(this.lblUserNametxt);
            this.grpBoxUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpBoxUserInfo.Location = new System.Drawing.Point(5, 212);
            this.grpBoxUserInfo.Name = "grpBoxUserInfo";
            this.grpBoxUserInfo.Size = new System.Drawing.Size(628, 71);
            this.grpBoxUserInfo.TabIndex = 1;
            this.grpBoxUserInfo.TabStop = false;
            this.grpBoxUserInfo.Text = "User Information";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(559, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 15);
            this.lblStatus.TabIndex = 71;
            this.lblStatus.Text = "[????]";
            // 
            // lblStatustxt
            // 
            this.lblStatustxt.AutoSize = true;
            this.lblStatustxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatustxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblStatustxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStatustxt.Location = new System.Drawing.Point(493, 32);
            this.lblStatustxt.Name = "lblStatustxt";
            this.lblStatustxt.Size = new System.Drawing.Size(43, 15);
            this.lblStatustxt.TabIndex = 69;
            this.lblStatustxt.Text = "Status:";
            // 
            // PicBoxStatus
            // 
            this.PicBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxStatus.Image")));
            this.PicBoxStatus.Location = new System.Drawing.Point(539, 30);
            this.PicBoxStatus.Name = "PicBoxStatus";
            this.PicBoxStatus.Size = new System.Drawing.Size(20, 20);
            this.PicBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxStatus.TabIndex = 70;
            this.PicBoxStatus.TabStop = false;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(125)))), ((int)(((byte)(86)))));
            this.lblUserID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserID.Location = new System.Drawing.Point(87, 32);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 15);
            this.lblUserID.TabIndex = 68;
            this.lblUserID.Text = "N/A";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Firebrick;
            this.lblUsername.Location = new System.Drawing.Point(227, 31);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(40, 17);
            this.lblUsername.TabIndex = 60;
            this.lblUsername.Text = "[????]";
            // 
            // PicBoxUsername
            // 
            this.PicBoxUsername.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxUsername.Image")));
            this.PicBoxUsername.Location = new System.Drawing.Point(204, 30);
            this.PicBoxUsername.Name = "PicBoxUsername";
            this.PicBoxUsername.Size = new System.Drawing.Size(20, 20);
            this.PicBoxUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxUsername.TabIndex = 59;
            this.PicBoxUsername.TabStop = false;
            // 
            // PicBoxUserID
            // 
            this.PicBoxUserID.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxUserID.Image")));
            this.PicBoxUserID.Location = new System.Drawing.Point(64, 30);
            this.PicBoxUserID.Name = "PicBoxUserID";
            this.PicBoxUserID.Size = new System.Drawing.Size(20, 20);
            this.PicBoxUserID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxUserID.TabIndex = 67;
            this.PicBoxUserID.TabStop = false;
            // 
            // lblUserIDtxt
            // 
            this.lblUserIDtxt.AutoSize = true;
            this.lblUserIDtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblUserIDtxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserIDtxt.Location = new System.Drawing.Point(15, 32);
            this.lblUserIDtxt.Name = "lblUserIDtxt";
            this.lblUserIDtxt.Size = new System.Drawing.Size(46, 15);
            this.lblUserIDtxt.TabIndex = 66;
            this.lblUserIDtxt.Text = "UserID:";
            // 
            // lblUserNametxt
            // 
            this.lblUserNametxt.AutoSize = true;
            this.lblUserNametxt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNametxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.lblUserNametxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserNametxt.Location = new System.Drawing.Point(138, 33);
            this.lblUserNametxt.Name = "lblUserNametxt";
            this.lblUserNametxt.Size = new System.Drawing.Size(65, 15);
            this.lblUserNametxt.TabIndex = 58;
            this.lblUserNametxt.Text = "UserName:";
            // 
            // ctrlPersonCard
            // 
            this.ctrlPersonCard.Location = new System.Drawing.Point(3, 2);
            this.ctrlPersonCard.Name = "ctrlPersonCard";
            this.ctrlPersonCard.Size = new System.Drawing.Size(630, 210);
            this.ctrlPersonCard.TabIndex = 0;
            // 
            // CtrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxUserInfo);
            this.Controls.Add(this.ctrlPersonCard);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtrlUserCard";
            this.Size = new System.Drawing.Size(637, 287);
            this.grpBoxUserInfo.ResumeLayout(false);
            this.grpBoxUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.CtrlPersonCard ctrlPersonCard;
        private System.Windows.Forms.GroupBox grpBoxUserInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox PicBoxUsername;
        private System.Windows.Forms.Label lblUserNametxt;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.PictureBox PicBoxUserID;
        private System.Windows.Forms.Label lblUserIDtxt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatustxt;
        private System.Windows.Forms.PictureBox PicBoxStatus;
    }
}
