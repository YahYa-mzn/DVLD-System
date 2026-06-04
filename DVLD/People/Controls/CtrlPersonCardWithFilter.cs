// User Control: Person card with search functionality
// Allows searching by PersonID or NationalNo
// Includes Find, Add New, and ResetUserInfoPage buttons
// Validates input based on selected search column

using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.People
{
    public partial class CtrlPersonCardWithFilter : UserControl
    {
        // Indicates if a person was found
        public bool IsFound { get; set; } = false;

        enum enBtn
        {
            Find = 1,
            AddNew = 2,
            Reset = 3,
        }
        enum enCmbBoxItems
        {
            PersonID = 0,
            NationalNo = 1,
        }

        clsFormsUtility.enInputType _InputType { get; set; }

        // Disables all filter controls (used for locked scenarios)
        public void DisableFilterControls()
        {
            txtBoxFilter.Enabled = false;
            btnFind.Enabled = false;
            btnAddNewPerson.Enabled = false;
            btnReset.Enabled = false;
        }

        // Loads person info and checks if deleted
        public void LoadPersonInfo(clsPerson Person)
        {
            if (Person == null)
            {
                clsFormsUtility.MsgBoxError("Person does not exists in the system.", "Not Found");
                return;
            }

            if (!Person.IsDeleted())
            {
                if (ctrlPersonCard.LoadPersonInfo(Person))
                {
                    IsFound = true;
                    return;
                }
            }
            else
            {
                clsFormsUtility.MsgBoxExclamation("The Person may have been moved to Trash. \nPlease recover it first to perform this Action\t", "Not Allowed");
            }

            ctrlPersonCard.Reset();
            IsFound = false;
        }

        // Searches for person by PersonID or NationalNo
        void Find(enCmbBoxItems enumItem)
        {
            clsPerson Person = null;

            switch (enumItem)
            {
                case enCmbBoxItems.PersonID:
                    if (clsValidation.IsOnlyDigits(txtBoxFilter.Text.Trim()))
                        Person = clsPerson.Find(Convert.ToInt32(txtBoxFilter.Text.Trim()));
                    break;

                case enCmbBoxItems.NationalNo:
                    if (clsValidation.IsValidNationalNo(txtBoxFilter.Text.Trim()))
                        Person = clsPerson.Find(txtBoxFilter.Text.Trim());
                    break;

                default:
                    Person = null;
                    break;
            }

            LoadPersonInfo(Person);
        }

        void AddNew()
        {
            frmAddNewPerson frm = new frmAddNewPerson();

            // Subscribe to load saved data event
            frm.LoadParentData += this.LoadPersonInfo;
            frm.ShowDialog();

            // Unsubscribe after form closes
            frm.LoadParentData -= this.LoadPersonInfo;
        }

        void Reset()
        {
            txtBoxFilter.Clear();
            ctrlPersonCard.Reset();
            IsFound = false;
        }

        public CtrlPersonCardWithFilter()
        {
            InitializeComponent();
            CmbBoxFilter.SelectedIndex = CmbBoxFilter.FindString("NationalNo");
        }


        // Sets input type based on selected filter column
        void CmbBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFilter.Clear();

            switch ((enCmbBoxItems)CmbBoxFilter.SelectedIndex)
            {
                case enCmbBoxItems.PersonID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    break;

                case enCmbBoxItems.NationalNo:
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    break;

                default:
                    break;
            }
        }

        // Validates input and triggers search on Enter key
        void TxtBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);

            if (e.KeyChar == (char)Keys.Enter)
            {
                Find((enCmbBoxItems)CmbBoxFilter.SelectedIndex);
            }
        }


        // Handles button clicks
        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.Find:
                    Find((enCmbBoxItems)CmbBoxFilter.SelectedIndex);
                    break;

                case enBtn.AddNew:
                    AddNew();
                    break;

                case enBtn.Reset:
                    Reset();
                    break;

                default:
                    break;
            }
        }
    }
}