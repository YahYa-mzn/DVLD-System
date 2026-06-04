// Form: Edit Person Information
// Allows editing all person details except PersonID
// Validates unique fields against existing records (excluding current person)
// Handles image changes and deletes old images when updated
// Provides ResetUserInfoPage button to restore original values
// Fires event to notify parent forms of updates

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.People
{
    public partial class frmEditPersonInfo : Form
    {
        clsPerson _Person { get; set; } = null;

        // Event to notify parent forms when person is updated
        public delegate bool DelLoadUpdatedData(clsPerson Person);
        public event DelLoadUpdatedData LoadUpdatedData;

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
            Close = 2,
            Reset = 3
        }
        enum enField
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

                CmbBoxNationality.SelectedItem = CmbBoxNationality.FindString(clsSettings.clsPeople.DefaultCountryName);
            }

            // Set birth date limits
            DateTimePkrBirthDate.MinDate = DateTime.Now.AddYears(-clsSettings.clsPeople.MaxAge);
            DateTimePkrBirthDate.MaxDate = DateTime.Now.AddYears(-clsSettings.clsPeople.MinAge);

            // Configure save file dialog
            SaveFileDlg.InitialDirectory = clsSettings.clsPeople.InitialSaveFileDlgDir;
            SaveFileDlg.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff) | *.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff";
            SaveFileDlg.DefaultExt = "png";
            SaveFileDlg.FilterIndex = 1;
        }

        // Loads person image or sets default
        void LoadImage()
        {
            PicBoxPersonImage.ImageLocation = (_Person.Gender == 'M')
                                              ? clsSettings.clsPeople.DefaultMaleImagePath
                                              : clsSettings.clsPeople.DefaultFemaleImagePath;
            LinkLblRemove.Enabled = false;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                if (clsFile.IsFileExists(_Person.ImagePath))
                {
                    PicBoxPersonImage.ImageLocation = _Person.ImagePath;
                    LinkLblRemove.Enabled = true;
                }
                else
                {
                    clsFormsUtility.MsgBoxExclamation("Person Image does not exist anymore. \t\t", "Image Not Found");
                }
            }
        }

        // Loads person information into form controls
        public bool LoadPersonInfo(clsPerson Person)
        {
            if (Person != null)
            {
                _Person = Person;

                lblPersonID.Text = _Person.PersonID.ToString();
                txtBoxFirstName.Text = _Person.FirstName;
                txtBoxSecondName.Text = _Person.SecondName;
                txtBoxThirdName.Text = _Person.ThirdName;
                txtBoxLastName.Text = _Person.LastName;
                txtBoxNationalNo.Text = _Person.NationalNo;
                DateTimePkrBirthDate.Value = _Person.BirthDate;

                if (_Person.Gender == 'M')
                    rdBtnMale.Checked = true;
                else
                    rdBtnFemale.Checked = true;

                txtBoxPhone.Text = _Person.Phone.ToString();
                txtBoxEmail.Text = _Person.Email.ToString();
                txtBoxAddress.Text = _Person.Address.ToString();

                CmbBoxNationality.Text = _Person.Country.CountryName;

                LoadImage();

                return true;
            }

            clsFormsUtility.MsgBoxError("The Person does not exist in the System. \t", "Not Found");
            DisableControls();
            return false;
        }

        public frmEditPersonInfo(clsPerson Person)
        {
            InitializeComponent();

            LoadDefaults();
            LoadPersonInfo(Person);
        }


        bool IsPersonImageDefaultImage()
        {
            return PicBoxPersonImage.ImageLocation == clsSettings.clsPeople.DefaultMaleImagePath ||
                   PicBoxPersonImage.ImageLocation == clsSettings.clsPeople.DefaultFemaleImagePath;
        }

        void ChangeDefaultImage(enRdBtn RdBtn)
        {
            PicBoxPersonImage.ImageLocation = (RdBtn == enRdBtn.Male)
                                            ? clsSettings.clsPeople.DefaultMaleImagePath
                                            : clsSettings.clsPeople.DefaultFemaleImagePath;
        }

        // Updates default image when gender changes (only if using default)
        void RdBtn_Click(object sender, EventArgs e)
        {
            if (!IsPersonImageDefaultImage())
                return;

            enRdBtn enumTag = clsFormsUtility.GetEnumType<enRdBtn>(sender);
            ChangeDefaultImage(enumTag);
        }


        // Opens file dialog to select new image
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
            if (rdBtnMale.Checked == true)
            {
                ChangeDefaultImage(enRdBtn.Male);
            }
            else
            {
                ChangeDefaultImage(enRdBtn.Female);
            }

            LinkLblRemove.Enabled = false;
        }

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


        // Validates non-unique fields
        void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Control txtBoxCtrl = (Control)sender;
            enField enumField = (enField)(Convert.ToInt32(txtBoxCtrl.Tag));

            switch (enumField)
            {
                case enField.FirstName:
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

                case enField.SecondName:
                    {
                        if (clsValidation.IsValidOptionalName(txtBoxCtrl.Text.Trim()))
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
                        break;
                    }

                case enField.ThirdName:
                    {
                        if (clsValidation.IsValidOptionalName(txtBoxCtrl.Text.Trim()))
                        {
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBoxCtrl.Focus();
                            errorProviderValidation.SetError(txtBoxCtrl, "Third is Invalid.");
                        }
                        break;
                    }

                case enField.LastName:
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

                case enField.Address:
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

        // Validates unique fields (excludes current person's values)
        void txtBoxUnique_Validating(object sender, CancelEventArgs e)
        {
            Control txtBoxCtrl = (Control)sender;
            clsPerson.enUniqueField enumUQField = (clsPerson.enUniqueField)(Convert.ToInt32(txtBoxCtrl.Tag));

            switch (enumUQField)
            {
                case clsPerson.enUniqueField.NationalNo:
                    {
                        if (clsValidation.IsValidNationalNo(txtBoxCtrl.Text.Trim()))
                        {
                            // Skip check if value unchanged
                            if (_Person.NationalNo != txtBoxCtrl.Text.Trim())
                            {
                                if (clsPerson.IsNationalNoExists(txtBoxCtrl.Text.Trim()))
                                {
                                    e.Cancel = true;
                                    txtBoxCtrl.Focus();
                                    errorProviderValidation.SetError(txtBoxCtrl, "This NationalNo already Exists");
                                    break;
                                }
                            }

                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                            break;
                        }

                        e.Cancel = true;
                        txtBoxCtrl.Focus();
                        errorProviderValidation.SetError(txtBoxCtrl, "NationalNo is Invalid or Empty. Contains only Letter(s) and Number(s)");
                        break;
                    }

                case clsPerson.enUniqueField.Phone:
                    {
                        if (clsValidation.IsValidPhone(txtBoxPhone.Text.Trim()))
                        {
                            // Skip check if value unchanged
                            if (_Person.Phone != txtBoxCtrl.Text.Trim())
                            {
                                if (clsPerson.IsPhoneExists(txtBoxCtrl.Text.Trim()))
                                {
                                    e.Cancel = true;
                                    txtBoxCtrl.Focus();
                                    errorProviderValidation.SetError(txtBoxCtrl, "This Phone already Exists");
                                    break;
                                }
                            }
                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                            break;
                        }

                        e.Cancel = true;
                        txtBoxCtrl.Focus();
                        errorProviderValidation.SetError(txtBoxCtrl, "Phone is Invalid or Empty. Contains only Numbers");
                        break;
                    }

                case clsPerson.enUniqueField.Email:
                    {
                        if (clsValidation.IsValidEmail(txtBoxEmail.Text.Trim()))
                        {
                            // Skip check if value unchanged
                            if (_Person.Email != txtBoxCtrl.Text.Trim())
                            {
                                if (clsPerson.IsEmailExists(txtBoxCtrl.Text.Trim()))
                                {
                                    e.Cancel = true;
                                    txtBoxCtrl.Focus();
                                    errorProviderValidation.SetError(txtBoxCtrl, "This Email already Exists");
                                    break;
                                }
                            }

                            e.Cancel = false;
                            errorProviderValidation.SetError(txtBoxCtrl, "");
                            break;
                        }

                        e.Cancel = true;
                        txtBoxCtrl.Focus();
                        errorProviderValidation.SetError(txtBoxCtrl, "Email is Invalid or Empty. Example: You@example.com");
                        break;
                    }

                default:
                    break;
            }
        }


        // Checks if all fields are valid
        bool CanSave()
        {
            foreach (Control TxtBox in grpBoxEditPersonInfo.Controls)
            {
                if (TxtBox is TextBox)
                {
                    if (!string.IsNullOrEmpty(errorProviderValidation.GetError(TxtBox)))
                        return false;

                    // SecondName and ThirdName are optional
                    if (Convert.ToInt32(TxtBox.Tag) != Convert.ToInt32(enField.SecondName) &&
                        Convert.ToInt32(TxtBox.Tag) != Convert.ToInt32(enField.ThirdName))
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

            btnReset.Enabled = false;
            btnSave.Enabled = false;
        }

        // Saves new image and deletes old one if changed
        void SaveImage()
        {
            if (!IsPersonImageDefaultImage())
            {
                string SourcePath = PicBoxPersonImage.ImageLocation;
                string DestFolder = clsSettings.clsPeople.FolderImagesPath;
                string NewFileName = clsFile.GenerateGUID();
                ImageFormat ImgFormat = clsFile.GetImageFormat(SourcePath);

                // Delete old image
                clsFile.DeleteFile(_Person.ImagePath);
                PicBoxPersonImage.ImageLocation = clsFile.CopyImageIntoNewPath(SourcePath, DestFolder, NewFileName, ImgFormat);
            }
            else
            {
                // If switched to default, delete custom image
                clsFile.DeleteFile(_Person.ImagePath);
            }
        }

        // Saves updated person info
        void Save()
        {
            if (!CanSave())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" + "Please fill them in with correct Data.", "Required/Missed");
                return;
            }

            // If editing current user's person, update the global object
            if (clsGlobal.CurrentUser.Person.IsSameAs(_Person))
                _Person = clsGlobal.CurrentUser.Person;

            string NationalNo = txtBoxNationalNo.Text.Trim();
            string FirstName = clsUtility.Capitalize(txtBoxFirstName.Text.Trim());
            string SecondName = clsUtility.Capitalize(txtBoxSecondName.Text.Trim());
            string ThirdName = clsUtility.Capitalize(txtBoxThirdName.Text.Trim());
            string LastName = clsUtility.Capitalize(txtBoxLastName.Text.Trim());
            char Gender = (rdBtnMale.Checked) ? 'M' : 'F';
            DateTime BirthDate = DateTimePkrBirthDate.Value;
            string Phone = txtBoxPhone.Text.Trim();
            string Email = txtBoxEmail.Text.Trim();
            int CountryID = CmbBoxNationality.SelectedIndex + 1;
            string Address = txtBoxAddress.Text.Trim();
            string ImagePath = _Person.ImagePath;

            // Save image only if changed
            if (_Person.ImagePath != PicBoxPersonImage.ImageLocation)
            {
                SaveImage();
                ImagePath = (!IsPersonImageDefaultImage())
                            ? PicBoxPersonImage.ImageLocation
                            : string.Empty;
            }

            if (_Person.SetUpdatedPersonInfo(NationalNo, FirstName, SecondName, ThirdName, LastName, Gender,
                                         BirthDate, Phone, Email, Address, CountryID, ImagePath))
            {
                clsFormsUtility.MsgBoxActionSucceeded("Edited", $"Person");

                // Notify parent forms
                LoadUpdatedData?.Invoke(_Person);
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Editing", $"Person with PersonID [{_Person.PersonID}]");
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

                case enBtn.Reset:
                    LoadPersonInfo(_Person);
                    break;

                default:
                    break;
            }
        }
    }
}