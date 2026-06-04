using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private clsApplicationType _AppType {  get; set; }

        enum enBtn
        {
            Save = 1,
            Cancel
        }
        enum enTxtBox
        {
            Title = 1,
            Fees 
        }

        void LoadAppTypeInfo()
        {
            if (_AppType == null)
            {
                clsFormsUtility.MsgBoxError("The ApplicationType does not exist in the System. \t", "Not Found");
                return;
            }

            lblID.Text = Convert.ToInt32(_AppType.ApplicationTypeID).ToString();
            txtBoxTitle.Text = _AppType.ApplicationTypeTitle;
            NumUpDownFees.Text = _AppType.ApplicationTypeFees.ToString();

        }

        public frmEditApplicationType(clsApplicationType AppType)
        {
            InitializeComponent();

            this._AppType = AppType;
            LoadAppTypeInfo();

            NumUpDownFees.DecimalPlaces = 4;
            NumUpDownFees.Increment = 0.1000M;
        }


        void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            enTxtBox enumTag = clsFormsUtility.GetEnumType<enTxtBox>(sender);

            switch (enumTag)
            {
                case enTxtBox.Title:
                    clsFormsUtility.txtBox_KeyPress(sender, e, clsFormsUtility.enInputType.LettersAndSpaces);
                    break;

                case enTxtBox.Fees:
                    clsFormsUtility.txtBox_KeyPress(sender, e, clsFormsUtility.enInputType.Numbers);
                    break;

                default:
                    break;
            }
        }

        void DisableAllControls()
        {
            txtBoxTitle.Enabled = false;
            NumUpDownFees.Enabled = false;
            btnSave.Enabled = false;
        }
        decimal GetFees()
        {
            Decimal.TryParse(NumUpDownFees.Text.Trim(), out decimal Fees);

            return Fees;
        }
        void Save()
        {
            if (_AppType == null) return;

            if (_AppType.SetUpdatedAppTypeInfo(txtBoxTitle.Text.Trim(), GetFees()))
                clsFormsUtility.MsgBoxActionSucceeded("Edited", $"Application type");

            else
                clsFormsUtility.MsgBoxActionFailed("Editing", "Application type");

            DisableAllControls();
        }

        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.Save:
                    Save();
                    break;

                case enBtn.Cancel:
                    this.Close();
                    break;

                default:
                    break;
            }
        }
    }
}
