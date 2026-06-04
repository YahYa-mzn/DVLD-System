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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddNewLocalDrivingLicenseApplication : Form
    {
        enum enBtn
        {
            Save = 1,
            Close = 2,
            Next = 3,
            Back = 4
        }

        public frmAddNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            if (CmbBoxLicenseClass.Items.Count == 0)
            {
                DataTable DTLicenseClasses = clsLicenseClass.GetLicenseClassesList();

                foreach (DataRow Row in DTLicenseClasses.Rows)
                {
                    CmbBoxLicenseClass.Items.Add(Row["LicenseClassName"]);
                }

                CmbBoxLicenseClass.SelectedIndex = (CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName) != -1)
                                                   ? CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName)
                                                   : 0;
            }
        }


        void LoadLocalDrivingLicenseApplicationInfoPage()
        {
            lblLDLAppID.Text = "N/A";
            lblApplicationID.Text = "N/A";

            lblApplicationDate.Text = DateTime.Now.ToString("g");
            lblApplicationFees.Text = (clsApplicationType.Find(clsApplicationType.enApplicationType.NewLocalDrivingLicenseService).ApplicationTypeFees) .ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + " [" + clsGlobal.CurrentUser.Person.FullName + "] ";
        }
        
        void tabCtrlInfoContainer_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == TabPageUser)
            { 
                if (!ctrlPersonCardWithFilter.IsFound)
                {
                    e.Cancel = true;
                    return;
                }

                LoadLocalDrivingLicenseApplicationInfoPage();
            }
        }

        void Save()
        {
            if (!ctrlPersonCardWithFilter.IsFound)
            {
                clsFormsUtility.MsgBoxExclamation("There is no applicant to make this local driving license application.", "Not Allowed");
                return;
            }

            clsPerson Person = ctrlPersonCardWithFilter.ctrlPersonCard.Person;
            clsLicenseClass LicenseClass = clsLicenseClass.Find((clsLicenseClass.enLicenseClass)CmbBoxLicenseClass.SelectedIndex + 1);

            if (LicenseClass.MinimumAgeAllowed > Person.Age)
            {
                clsFormsUtility.MsgBoxExclamation($"Applicant's age [{Person.Age}] " +
                                                  $"is below the minimum allowed for this license class [{LicenseClass.MinimumAgeAllowed}]",
                                                   "Invalid Age");
                return;
            }
            if (clsLocalDrivingLicenseApplication.IsApplicantAlreadyExists(Person.PersonID, Convert.ToInt32(LicenseClass.LicenseClassID)))
            {
                clsFormsUtility.MsgBoxError($"This Person already exists as an Applicant.", "Duplicated Applicant");
                return;
            }

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected the Application fees? ")) return;

            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.GetNewLDLAppObjectToAdd(Person,
                                                                                                                 clsGlobal.CurrentUser.UserID,
                                                                                                                 LicenseClass);

            if (LDLApp == null) return;
            if (LDLApp.Save())
            {
                clsFormsUtility.MsgBoxActionSucceeded("Added", "Local driving license applicant");

                lblLDLAppID.Text = LDLApp.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationID.Text = LDLApp.ApplicationID.ToString();
                return;
            }

            clsFormsUtility.MsgBoxActionFailed("Adding", "Local driving license applicant");
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

                case enBtn.Next:
                    tabCtrlInfoContainer.SelectedIndex++;
                    break;

                case enBtn.Back:
                    tabCtrlInfoContainer.SelectedIndex--;
                    break;

                default:
                    break;
            }
        }


        // Permissions checking !
        private void frmAddNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.NewLocalDrivingLicenseApplication)) this.Close();
        }
    }
}
