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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlInternationalLicenseCard : UserControl
    {
        private clsInternationalLicense _InternationalLicense { get; set; } = null;

        void Reset()
        {
            lblInternationalLicenseID.Text = "N/A";
            lblSerialNumber.Text = "N/A";
            lblLicenseID.Text = "N/A";

            lblName.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblBirthDate.Text = "0000/00/00";
            lblGender.Text = "[????]";

            lblIssueDate.Text = "0000/00/00";
            lblExpirationDate.Text = "0000/00/00";
            lblIsActive.Text = "[????]";

            PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
        }
        void LoadImage()
        {
            // Set default image based on gender
            if (_InternationalLicense.License.Driver.Person.Gender == 'M')       
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultMaleImagePath;
            
            else
                PicBoxPersonImage.ImageLocation = clsSettings.clsPeople.DefaultFemaleImagePath;
            

            // If person has custom image, load it
            if (!string.IsNullOrEmpty(_InternationalLicense.License.Driver.Person.ImagePath))
            {
                if (clsFile.IsFileExists(_InternationalLicense.License.Driver.Person.ImagePath))  
                    PicBoxPersonImage.ImageLocation = _InternationalLicense.License.Driver.Person.ImagePath;
                
                else
                    clsFormsUtility.MsgBoxExclamation("Image was not found!   \t", "Image");   
            }
        }

        public bool LoadLicenseInfo(clsInternationalLicense InternationalLicense)
        {
            if (InternationalLicense == null)
            {
                Reset();
                return false;
            }

            _InternationalLicense = InternationalLicense;

            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblSerialNumber.Text = _InternationalLicense.InternationalSerialNumber;
            lblLicenseID.Text = _InternationalLicense.License.LicenseID.ToString();

            lblName.Text = _InternationalLicense.License.Driver.Person.FullName;
            lblDriverID.Text = _InternationalLicense.License.Driver.DriverID.ToString();
            lblNationalNo.Text = _InternationalLicense.License.Driver.Person.NationalNo;
            lblBirthDate.Text = _InternationalLicense.License.Driver.Person.BirthDate.ToString("d");
            lblGender.Text = (_InternationalLicense.License.Driver.Person.Gender == 'M')
                             ? "Male"
                             : "Female";

            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("d");
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("d");
            
            lblIsActive.Text = (_InternationalLicense.IsActive) 
                               ? "Active"
                               : "Inactive";

            LoadImage();

            return true;
        }

        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }
    }
}
