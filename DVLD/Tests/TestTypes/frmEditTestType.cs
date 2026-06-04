using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Tests.TestTypes
{
    public partial class frmEditTestType : Form
    {
        private clsTestType _TestType { get; set; } = null;

        enum enBtn
        {
            Save = 1,
            Cancel
        }
        enum enTxtBox
        {
            Title = 1,
            Description = 2,
            Fees = 3
        }

        void LoadTestTypeInfo()
        {
            if (_TestType == null)
            {
                clsFormsUtility.MsgBoxError("The Test Type does not exist in the System. \t", "Not Found");
                return;
            }

            lblID.Text = Convert.ToInt32(_TestType.TestTypeID).ToString();
            txtBoxTestTypeTitle.Text = _TestType.TestTypeTitle;  
            txtBoxTestTypeDescription.Text = _TestType.TestTypeDescription;
            NumUpDownFees.Text = _TestType.TestTypeFees.ToString();
        }

        public frmEditTestType(clsTestType TestType)
        {
            InitializeComponent();

            this._TestType = TestType;
            LoadTestTypeInfo();

            NumUpDownFees.DecimalPlaces = 4;
            NumUpDownFees.Increment = 0.1000M;
        }


        void DisableAllControls()
        {
            txtBoxTestTypeTitle.Enabled = false;
            txtBoxTestTypeDescription.Enabled = false;
            NumUpDownFees.Enabled = false;
            btnSave.Enabled = false;
        }
        decimal GetFees()
        {
            bool IsDecimal = Decimal.TryParse(NumUpDownFees.Text.Trim(), out decimal Fees);

            return (IsDecimal) ? Fees : _TestType.TestTypeFees;
        }
        void Save()
        {
            if (this._TestType == null) return;

            _TestType.SetUpdatedTestTypeInfo(txtBoxTestTypeDescription.Text.Trim(), GetFees());

            if (_TestType.Save())
                clsFormsUtility.MsgBoxActionSucceeded("Edited", $"Test Type");

            else
                clsFormsUtility.MsgBoxActionFailed("Editing", "Test Type");

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
