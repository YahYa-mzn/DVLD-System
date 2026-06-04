// Form: Add New Person
// Collects all person information including names, contact details, address, nationality, and image
// Validates all fields before saving
// Saves person image to a dedicated folder with GUID filename
// Fires event to notify parent forms of newly added person

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;


namespace DVLD.People
{
    public partial class frmAddNewPerson : Form
    {
        // Event to notify parent forms when person is saved
        public delegate void DelSaveUpdatedData(clsPerson Person);
        public event DelSaveUpdatedData LoadParentData;

        enum enRdBtn
        {
            Male = 1,
            Female = 2
        }
        enum enLinkLbl
        {
            SetImage = 1,
            Remove = 2
        }
        enum enBtn
        {
            Save = 1,
            Close = 2
        }
        enum enTxtBox
        {
            FirstName = 1,
            SecondName = 2,
            ThirdName = 3,
            LastName = 4,
            Address = 5
        }

        // Loads default values for controls
        void LoadDefaults()
        {
            // Load countries into combo box
            if (CmbBoxNationality.Items.Count == 0)
            {
                DataTable DTCountries = clsCountry.GetAllCountries();

                foreach (DataRow Row in DTCountries.Rows)
                {
                    CmbBoxNationality.Items.Add(Row["CountryName"]);
                }

                CmbBoxNationality.SelectedIndex = (CmbBoxNationality.FindString(clsSettings.clsPeople.DefaultCountryName) != -1)
                                                  ? CmbBoxNationality.FindString(clsSettings.clsPeople.DefaultCountryName)
                                                  : 0;
            }

            // Set birth date limits (MinAge to MaxAge)
            DateTimePkrBirthDate.MinDate = DateTime.Now.AddYears(-clsSettings.clsPeople.MaxAge);
            DateTimePkrBirthDate.MaxDate = DateTime.Now.AddYears(-clsSettings.clsPeople.MinAge);

            // Configure save file dialog for image selection
            SaveFileDlg.InitialDirectory = clsSettings.clsPeople.InitialSaveFileDlgDir;
            SaveFileDlg.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff) | *.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff";
            SaveFileDlg.DefaultExt = "png";
            SaveFileDlg.FilterIndex = 1;
        }

        public frmAddNewPerson()
        {
            InitializeComponent();
            LoadDefaults();
        }

        
        bool IsPersonImageDefaultImage()
        {
            // Checks if current image is a default gender image

            return PicBoxPersonImage.ImageLocation == clsSettings.clsPeople.DefaultMaleImagePath ||
                   PicBoxPersonImage.ImageLocation == clsSettings.clsPeople.DefaultFemaleImagePath;
        }

        void ChangeDefaultImage(enRdBtn RdBtn)
        {
            PicBoxPersonImage.ImageLocation = (RdBtn == enRdBtn.Male)
                                            ? clsSettings.clsPeople.DefaultMaleImagePath
                                            : clsSettings.clsPeople.DefaultFemaleImagePath;
        }

        // Updates default image when gender radio button is clicked
        void RdBtn_Click(object sender, EventArgs e)
        {
            if (!IsPersonImageDefaultImage())
                return;

            enRdBtn enumTag = clsFormsUtility.GetEnumType<enRdBtn>(sender);
            ChangeDefaultImage(enumTag);
        }


        // Opens file dialog to select person image
        void SetImage()
        {
            if (SaveFileDlg.ShowDialog() == DialogResult.OK)
            {
                PicBoxPersonImage.ImageLocation = SaveFileDlg.FileName;
                LinkLblRemove.Enabled = true;
            }
        }

        // Removes custom image and resets to default
        void Remove()
        {
            RadioButton rdBtn = new RadioButton();

            if (rdBtnMale.Checked)
            {
                ChangeDefaultImage(enRdBtn.Male);
            }
            else
            {
                ChangeDefaultImage(enRdBtn.Female);
            }

            LinkLblRemove.Enabled = false;
        }

        // Handles image link label clicks
        void LinkLbl_Click(object sender, EventArgs e)
        {
            enLinkLbl enumTag = clsFormsUtility.GetEnumType<enLinkLbl>(sender);

            switch (enumTag)
            {
                case enLinkLbl.SetImage:
                    SetImage();
                    break;

                case enLinkLbl.Remove:
                    Remove();
                    break;

                default:
                    break;
            }
        }


        // Validates non-unique text fields
        void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Control txtBoxCtrl = (Control)sender;
            enTxtBox enumField = (enTxtBox)(Convert.ToInt32(txtBoxCtrl.Tag));

            switch (enumField)
            {
                case enTxtBox.FirstName:
                    {
                        if (clsValidation.IsValidRequiredName(txtBoxCtrl.Text.Trim()))
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "FirstName is Invalid or Empty.");
                        }
                        break;
                    }

                case enTxtBox.SecondName:
                    {
                        if (!string.IsNullOrEmpty(txtBoxCtrl.Text.Trim()))
                        {
                            if (clsValidation.IsValidRequiredName(txtBoxSecondName.Text.Trim()))
                            {
                                e.Cancel = false;
                                errorProviderValidation.SetError(txtBoxCtrl, "");
                            }
                            else
                            {
                                e.Cancel = true;
                                txtBoxCtrl.Focus();
                                errorProviderValidation.SetError(txtBoxCtrl, "SecondName is Invalid.");
                            }
                        }
                        else
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        break;
                    }

                case enTxtBox.ThirdName:
                    {
                        if (!string.IsNullOrEmpty(txtBoxCtrl.Text.Trim()))
                        {
                            if (clsValidation.IsValidRequiredName(txtBoxCtrl.Text.Trim()))
                            {
                                e.Cancel = false;
                                errorProviderValidation.SetError(txtBoxCtrl, "");
                            }
                            else
                            {
                                e.Cancel = true;
                                txtBoxCtrl.Focus();
                                errorProviderValidation.SetError(txtBoxCtrl, "ThirdName is Invalid.");
                            }
                        }
                        else
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        break;
                    }

                case enTxtBox.LastName:
                    {
                        if (clsValidation.IsValidRequiredName(txtBoxCtrl.Text.Trim()))
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "LastName is Invalid or Empty.");
                        }
                        break;
                    }

                case enTxtBox.Address:
                    {
                        if (clsValidation.IsValidAddress(txtBoxCtrl.Text.Trim()))
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "Address is Invalid or Empty.");
                        }
                        break;
                    }

                default:
                    break;
            }
        }

        // Validates unique fields (NationalNo, Phone, Email)
        void txtBoxUnique_Validating(object sender, CancelEventArgs e)
        {
            Control txtBoxCtrl = (Control)sender;
            clsPerson.enUniqueField enumTag = (clsPerson.enUniqueField)(Convert.ToInt32(txtBoxCtrl.Tag));

            switch (enumTag)
            {
                case clsPerson.enUniqueField.NationalNo:
                    {
                        if (clsValidation.IsValidNationalNo(txtBoxNationalNo.Text.Trim()))
                        {
                            if (!clsPerson.IsNationalNoExists(txtBoxCtrl.Text.Trim()))
                            {
                                e.Cancel = false;
                                errorProviderValidation.SetError(txtBoxCtrl, "");
                            }
                            else
                            {
                                e.Cancel = true;
                                txtBoxCtrl.Focus();
                                errorProviderValidation.SetError(txtBoxCtrl, "This NationalNo already Exists");
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "NationalNo is Invalid or Empty. Contains only Letter(s) and Number(s)");
                        }
                        break;
                    }

                case clsPerson.enUniqueField.Phone:
                    {
                        if (clsValidation.IsValidPhone(txtBoxPhone.Text.Trim()))
                        {
                            if (!clsPerson.IsPhoneExists(txtBoxCtrl.Text.Trim()))
                            {
                                e.Cancel = false;
                                errorProviderValidation.SetError(txtBoxCtrl, "");
                            }
                            else
                            {
                                e.Cancel = true;
                                txtBoxCtrl.Focus();
                                errorProviderValidation.SetError(txtBoxCtrl, "This Phone already Exists");
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "Phone is Invalid or Empty. Contains only Numbers");
                        }
                        break;
                    }

                case clsPerson.enUniqueField.Email:
                    {
                        if (clsValidation.IsValidEmail(txtBoxEmail.Text.Trim()))
                        {
                            if (!clsPerson.IsEmailExists(txtBoxCtrl.Text.Trim()))
                            {
                                e.Cancel = false;
                                errorProviderValidation.SetError(txtBoxCtrl, "");
                            }
                            else
                            {
                                e.Cancel = true;
                                txtBoxCtrl.Focus();
                                errorProviderValidation.SetError(txtBoxCtrl, "This Email already Exists");
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "Email is Invalid or Empty. Example: You@example.com");
                        }
                        break;
                    }

                default:
                    break;
            }
        }


        // Checks if all required fields are filled and valid
        bool CanSave()
        {
            foreach (Control TxtBox in grpBoxNewPersonInfo.Controls)
            {
                if (TxtBox is TextBox)
                {
                    if (!string.IsNullOrEmpty(errorProviderValidation.GetError(TxtBox)))
                        return false;

                    // SecondName and ThirdName are optional
                    if (Convert.ToInt32(TxtBox.Tag) != Convert.ToInt32(enTxtBox.SecondName) &&
                        Convert.ToInt32(TxtBox.Tag) != Convert.ToInt32(enTxtBox.ThirdName))
                    {
                        if (string.IsNullOrEmpty(TxtBox.Text.Trim()))
                            return false;
                    }
                }
            }

            return true;
        }

        void DisableControls()
        {
            txtBoxFirstName.Enabled = false;
            txtBoxSecondName.Enabled = false;
            txtBoxThirdName.Enabled = false;
            txtBoxLastName.Enabled = false;
            txtBoxNationalNo.Enabled = false;
            DateTimePkrBirthDate.Enabled = false;
            rdBtnMale.Enabled = false;
            rdBtnFemale.Enabled = false;
            txtBoxPhone.Enabled = false;
            txtBoxEmail.Enabled = false;
            CmbBoxNationality.Enabled = false;
            txtBoxAddress.Enabled = false;

            LinkLblSetImage.Enabled = false;
            LinkLblRemove.Enabled = false;
            btnSave.Enabled = false;
        }

        // Saves image to People Images folder with GUID filename
        void SaveImage()
        {
            if (!IsPersonImageDefaultImage())
            {
                string SourcePath = PicBoxPersonImage.ImageLocation;
                string DestFolder = clsSettings.clsPeople.FolderImagesPath;
                string NewFileName = clsFile.GenerateGUID();
                ImageFormat ImgFormat = clsFile.GetImageFormat(SourcePath);

                PicBoxPersonImage.ImageLocation = clsFile.CopyImageIntoNewPath(SourcePath, DestFolder, NewFileName, ImgFormat);
            }
        }

        // Saves person to database and triggers event
        void Save()
        {
            if (!CanSave())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" +
                                                  "Please fill them in with correct Data.",
                                                  "Required/Missed");
                return;
            }

            string NationalNo = txtBoxNationalNo.Text.Trim();
            string FirstName = clsUtility.Capitalize(txtBoxFirstName.Text.Trim());
            string SecondName = clsUtility.Capitalize(txtBoxSecondName.Text.Trim());
            string ThirdName = clsUtility.Capitalize(txtBoxThirdName.Text.Trim());
            string LastName = clsUtility.Capitalize(txtBoxLastName.Text.Trim());
            char Gender = (rdBtnMale.Checked == true) ? 'M' : 'F';
            DateTime BirthDate = DateTimePkrBirthDate.Value;
            string Phone = txtBoxPhone.Text.Trim();
            string Email = txtBoxEmail.Text.Trim();
            int CountryID = CmbBoxNationality.SelectedIndex + 1;
            string Address = txtBoxAddress.Text.Trim();

            SaveImage();
            string ImagePath = (!IsPersonImageDefaultImage())
                                ? PicBoxPersonImage.ImageLocation
                                : string.Empty;

            clsPerson Person = clsPerson.GetAddNewPersonObject(NationalNo, FirstName, SecondName, ThirdName, LastName, Gender,
                                                               BirthDate, Phone, Email, Address, CountryID, ImagePath);
            if (Person == null)
            {
                clsFormsUtility.MsgBoxError("Some of the fields are not valid.", "Not Allowed");
                return;
            }

            if (Person.Save())
            {
                lblPersonID.Text = Person.PersonID.ToString();
                clsFormsUtility.MsgBoxActionSucceeded("Added", $"Person");

                // Notify parent forms
                LoadParentData?.Invoke(Person);
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Adding", $"Person");
            }

            DisableControls();
        }


        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.Save:
                    Save();
                    break;

                case enBtn.Close:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        
    }
}