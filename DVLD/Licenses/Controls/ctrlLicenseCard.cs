using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlLicenseCard : UserControl
    {
        private clsLicense _License { get; set; } = null;


        void Reset()
        {
            lblLicenseID.Text = "N/A";
            lblSerialNumber.Text = "N/A";

            lblLicenseClass.Text = "[????]";

            lblName.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblBirthDate.Text = "0000/00/00"; 
            lblGender.Text = "[????]";

            lblIssueDate.Text = "0000/00/00";
            lblExpirationDate.Text = "0000/00/00";
            
            lblIsActive.Text = "[????]";
            lblIsDetained.Text = "[????]";

            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[No Notes]";

            PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
        }
        void LoadImage()
        {
            // Set default image based on gender
            if (_License.Driver.Person.Gender == 'M')
            {
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
            }
            else
            {
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultFemaleImagePath;
            }

            // If person has custom image, load it
            if (!string.IsNullOrEmpty(_License.Driver.Person.ImagePath))
            {
                if (clsFile.IsFileExists(_License.Driver.Person.ImagePath))
                {
                    PicBoxPersonImage.ImageLocation = _License.Driver.Person.ImagePath;
                }
                else
                {
                    clsFormsUtility.MsgBoxExclamation("Image was not found!   \t", "Image");
                }
            }
        }

        public bool LoadLicenseInfo(clsLicense License)
        {
            if (License == null)
            {
                Reset();
                return false;
            }

            _License = License;

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblSerialNumber.Text = _License.SerialNumber;

            lblLicenseClass.Text = _License.LicenseClass.LicenseClassName;

            lblName.Text = _License.Driver.Person.FullName;
            lblDriverID.Text = _License.Driver.DriverID.ToString();
            lblNationalNo.Text = _License.Driver.Person.NationalNo;
            lblBirthDate.Text = _License.Driver.Person.BirthDate.ToString("d");
            lblGender.Text = (_License.Driver.Person.Gender == 'M')
                             ? "Male"
                             : "Female";

            lblIssueDate.Text = _License.IssueDate.ToString("d");
            lblExpirationDate.Text = _License.ExpirationDate.ToString("d");

            lblIsActive.Text =  (_License.IsActive)
                                ? "Active"
                                : "Inactive";

            lblIsDetained.Text = (_License.IsDetained)
                                 ? "Detained"
                                 : "Not Detained";

            lblIssueReason.Text = _License.StrIssueReason;
            lblNotes.Text = (string.IsNullOrEmpty(_License.Notes)) 
                            ? lblNotes.Text 
                            : _License.Notes;

            LoadImage();

            return true;
        }

        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

    }
}
