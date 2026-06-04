namespace DVLD.People
{
    partial class CtrlPersonCardWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPersonCardWithFilter));
            this.CmbBoxFilter = new System.Windows.Forms.ComboBox();
            this.txtBoxFilter = new System.Windows.Forms.TextBox();
            this.grpBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.ctrlPersonCard = new DVLD.People.CtrlPersonCard();
            this.errorProviderValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbBoxFilter
            // 
            this.CmbBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.CmbBoxFilter.FormattingEnabled = true;
            this.CmbBoxFilter.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.CmbBoxFilter.Location = new System.Drawing.Point(11, 21);
            this.CmbBoxFilter.Name = "CmbBoxFilter";
            this.CmbBoxFilter.Size = new System.Drawing.Size(200, 25);
            this.CmbBoxFilter.TabIndex = 0;
            this.CmbBoxFilter.SelectedIndexChanged += new System.EventHandler(this.CmbBoxFilter_SelectedIndexChanged);
            // 
            // txtBoxFilter
            // 
            this.txtBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtBoxFilter.Location = new System.Drawing.Point(216, 21);
            this.txtBoxFilter.MaxLength = 100;
            this.txtBoxFilter.Multiline = true;
            this.txtBoxFilter.Name = "txtBoxFilter";
            this.txtBoxFilter.Size = new System.Drawing.Size(228, 25);
            this.txtBoxFilter.TabIndex = 1;
            this.txtBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBoxFilter_KeyPress);
            // 
            // grpBoxFilter
            // 
            this.grpBoxFilter.Controls.Add(this.btnReset);
            this.grpBoxFilter.Controls.Add(this.btnFind);
            this.grpBoxFilter.Controls.Add(this.txtBoxFilter);
            this.grpBoxFilter.Controls.Add(this.btnAddNewPerson);
            this.grpBoxFilter.Controls.Add(this.CmbBoxFilter);
            this.grpBoxFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(26)))));
            this.grpBoxFilter.Location = new System.Drawing.Point(5, 2);
            this.grpBoxFilter.Name = "grpBoxFilter";
            this.grpBoxFilter.Size = new System.Drawing.Size(628, 56);
            this.grpBoxFilter.TabIndex = 1;
            this.grpBoxFilter.TabStop = false;
            this.grpBoxFilter.Text = "Filter";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(581, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(41, 36);
            this.btnReset.TabIndex = 7;
            this.btnReset.Tag = "3";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(451, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(41, 36);
            this.btnFind.TabIndex = 6;
            this.btnFind.Tag = "1";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.Location = new System.Drawing.Point(501, 13);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(41, 36);
            this.btnAddNewPerson.TabIndex = 5;
            this.btnAddNewPerson.Tag = "2";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.Btn_Click);
            // 
            // ctrlPersonCard
            // 
            this.ctrlPersonCard.Location = new System.Drawing.Point(3, 59);
            this.ctrlPersonCard.Name = "ctrlPersonCard";
            this.ctrlPersonCard.Size = new System.Drawing.Size(630, 210);
            this.ctrlPersonCard.TabIndex = 0;
            // 
            // errorProviderValidation
            // 
            this.errorProviderValidation.ContainerControl = this.ctrlPersonCard;
            // 
            // CtrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxFilter);
            this.Controls.Add(this.ctrlPersonCard);
            this.Name = "CtrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(637, 273);
            this.grpBoxFilter.ResumeLayout(false);
            this.grpBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox CmbBoxFilter;
        private System.Windows.Forms.TextBox txtBoxFilter;
        private System.Windows.Forms.GroupBox grpBoxFilter;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ErrorProvider errorProviderValidation;
        public CtrlPersonCard ctrlPersonCard;
    }
}
