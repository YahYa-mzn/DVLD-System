// User Control: Displays person information in a card format
// Shows PersonID, Name, NationalNo, Gender, BirthDate, Email, Phone, Address, Nationality, and Image
// Provides edit link and handles default images by gender

using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.People
{
    public partial class CtrlPersonCard : UserControl
    {
        public clsPerson Person { get; private set; } = null;

        // Loads person image or sets default by gender
        void LoadImage()
        {
            // Set default image based on gender
            if (Person.Gender == 'M')
            {
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
            }
            else
            {
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultFemaleImagePath;
            }

            // If person has custom image, load it
            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                if (clsFile.IsFileExists(Person.ImagePath))
                {
                    PicBoxPersonImage.ImageLocation = Person.ImagePath;
                }
                else
                {
                    clsFormsUtility.MsgBoxExclamation("Person Image does not exist anymore. \t\t", "Image Not Found");
                }
            }
        }

        // Resets all fields to default values
        public void Reset()
        {
            lblPersonID.Text = "N/A";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblBirthDate.Text = "0000/00/00";
            lblPhone.Text = "[????]";
            lblNationality.Text = "[????]";

            LinkLblEditPersonInfo.Enabled = false;

            PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
        }
        public bool LoadPersonInfo(clsPerson Person)
        {
            if (Person == null)
            {
                Reset();
                clsFormsUtility.MsgBoxError("The Person does not exist in the System. \t", "Not Found");
                return false;
            }

            this.Person = Person;

            lblPersonID.Text = this.Person.PersonID.ToString();
            lblName.Text = this.Person.FullName;
            lblNationalNo.Text = this.Person.NationalNo;
            lblGender.Text = (this.Person.Gender == 'M') ? "Male" : "Female";
            lblEmail.Text = this.Person.Email.ToString();
            lblAddress.Text = this.Person.Address.ToString();
            lblBirthDate.Text = this.Person.BirthDate.ToString("d");
            lblPhone.Text = this.Person.Phone.ToString();
            lblNationality.Text = this.Person.Country.CountryName;

            // Disable edit for deleted persons
            LinkLblEditPersonInfo.Enabled = (this.Person.IsDeleted()) ? false : true;
            LoadImage();

            return true;
        }

        public CtrlPersonCard()
        {
            InitializeComponent();
        }
  

        // Opens edit form and reloads updated data
        void LinkLblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditPersonInfo frm = new frmEditPersonInfo(Person);

            // Subscribe to load updated data event
            frm.LoadUpdatedData += LoadPersonInfo;
            frm.ShowDialog();

            // Unsubscribe after form closes
            frm.LoadUpdatedData -= LoadPersonInfo;
        }
    }
}