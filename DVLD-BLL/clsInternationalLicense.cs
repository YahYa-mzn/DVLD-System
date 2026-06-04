using System;
using System.Data;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsInternationalLicense
    {
        // Add SQL agent job that make the IsActive field false when the license is expired

        enum enMode { NullOrEmpty = 0, AddNew = 1, Read = 2 };
       

        public int InternationalLicenseID { get; private set; }
        public string InternationalSerialNumber { get; private set; }
        public clsLicense License { get; private set; }
        public int ApplicationID { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }
        public int CreatedByUserID { get; private set; }

        public bool IsExpired { get { return ExpirationDate >= DateTime.Today; } }  

        enMode _Mode {  get; set; } = enMode.NullOrEmpty;   


        private static clsInternationalLicense _Convert_DTO_To_Object(clsInternationalLicenseDAL.clsInternationalLicenseDTO InternationalLicenseDTO)
        {
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.InternationalLicenseID = InternationalLicenseDTO.InternationalLicenseID;
            InternationalLicense.InternationalSerialNumber = InternationalLicenseDTO.InternationalSerialNumber;
            InternationalLicense.License = clsLicense._Convert_DTO_To_Object(InternationalLicenseDTO.LicenseDTO);
            InternationalLicense.ApplicationID = InternationalLicenseDTO.ApplicationID;
            InternationalLicense.IssueDate = InternationalLicenseDTO.IssueDate;
            InternationalLicense.ExpirationDate = InternationalLicenseDTO.ExpirationDate;
            InternationalLicense.IsActive = InternationalLicenseDTO.IsActive;
            InternationalLicense.CreatedByUserID = InternationalLicenseDTO.CreatedByUserID;

            return InternationalLicense;
        }
        private clsInternationalLicenseDAL.clsInternationalLicenseDTO _Convert_Object_To_DTO(clsInternationalLicense InternationalLicense)
        {
            clsInternationalLicenseDAL.clsInternationalLicenseDTO InternationalLicenseDTO = new clsInternationalLicenseDAL.clsInternationalLicenseDTO();

            InternationalLicenseDTO.InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            InternationalLicenseDTO.InternationalSerialNumber = InternationalLicense.InternationalSerialNumber;
            InternationalLicenseDTO.LicenseDTO = clsLicense._Convert_Object_To_DTO(InternationalLicense.License);
            InternationalLicenseDTO.ApplicationID = InternationalLicense.ApplicationID;
            InternationalLicenseDTO.IssueDate = InternationalLicense.IssueDate;
            InternationalLicenseDTO.ExpirationDate = InternationalLicense.ExpirationDate;
            InternationalLicenseDTO.IsActive = InternationalLicense.IsActive;
            InternationalLicenseDTO.CreatedByUserID = InternationalLicense.CreatedByUserID;

            return InternationalLicenseDTO;
        }

        private bool _AddNew()
        {
            this.InternationalLicenseID = clsInternationalLicenseDAL.AddNewInternationalLicense_InDB(_Convert_Object_To_DTO(this));

            return (this.InternationalLicenseID != -1);
        }

        clsInternationalLicense() { }
        clsInternationalLicense(int InternationalLicenseID, string InternationalSerialNumber, clsLicense License, int ApplicationID, DateTime IssueDate, 
                                DateTime ExpirationDate, bool IsActive, int CreatedByUserID, enMode Mode = enMode.Read)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.InternationalSerialNumber = InternationalSerialNumber;
            this.License = License;
            this.ApplicationID = ApplicationID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = Mode;
        }


        internal static clsInternationalLicense GetNewObjectToAdd(string InternationalSerialNumber, clsLicense License, int ApplicationID, int CreatedByUserID)
        {
            DateTime ExpirationDate = License.LicenseClass.ExpirationDate;

            return new clsInternationalLicense(-1, InternationalSerialNumber, License, ApplicationID, DateTime.Today, ExpirationDate, true, CreatedByUserID, enMode.AddNew);
        }
        internal bool Save()
        {
            if (this._Mode != enMode.AddNew) return false;
            if (!this._AddNew()) return false;

            this._Mode = enMode.Read;
            return true;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            return (InternationalLicenseID != -1)
                   ? _Convert_DTO_To_Object(clsInternationalLicenseDAL.GetInternationalLicense_InDB(InternationalLicenseID)) 
                   : null;
        }
        public static bool IsActiveInternationalLicenseExistsByDriverID(int DriverID)
        {
            return (DriverID != -1)
                   ? clsInternationalLicenseDAL.IsActiveInternationalLicenseExistsByDriverID_InDB(DriverID) 
                   : false;
        }

        public static clsInternationalLicense IssueInternationalDrivingLicense(clsLicense License, int CreatedByUserID)
        {
            // No need to check the application bc it should be created inside the issue international license!
            // No need to check CreatedByUserID bc the application will do.

            if (License == null) return null;
            // Only class 3 (ordinary driving license) are allowed to get an international license !
            if (License.LicenseClass.LicenseClassID != clsLicenseClass.enLicenseClass.Class3_OrdinaryDriving) return null;
            if (!License.IsActive) return null;
            if (License.IsDetained) return null;
            if (IsActiveInternationalLicenseExistsByDriverID(License.Driver.DriverID)) return null;

            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.NewInternationalLicense);

            clsApplication Application = clsApplication.GetAddNewApplicationObject(License.Driver.Person, ApplicationType, CreatedByUserID);
            if (!Application.SaveBaseApplication()) return null;


            clsSerialNumber SerialNumberObj = clsSerialNumber.Find(clsSerialNumber.enSerialNumberID.International);
            string InternationalSerialNumber = SerialNumberObj.GenerateNewSerialNumber();

            clsInternationalLicense InternationalLicense = GetNewObjectToAdd(InternationalSerialNumber, License, Application.ApplicationID, CreatedByUserID);
            if (!InternationalLicense.Save()) return null;

            if (!Application.CompleteApplication()) return null;


            return (SerialNumberObj.UpdateLatestSerialNumber()) ? InternationalLicense : null;
        }
        public static bool DeactivatePreviousInternationalLicenses(int DriverID)
          => clsInternationalLicenseDAL.DeactivateAllLicenses_InDB(DriverID);

        public enum enFilterColumn
        {
            None = 0,
            InternationalLicenseID = 1,
            InternationalSerialNumber = 2,
            DriverID = 3,
            LicenseID = 4,
            NationalNo = 5
        }

        public static DataTable GetInternationalLicensesList(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                case enFilterColumn.InternationalLicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsInternationalLicenseDAL.GetAllInternationalLicensesFilteredByInternationalLicenseID_InDB(Convert.ToInt32(StrValue))
                           : clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                case enFilterColumn.InternationalSerialNumber:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsInternationalLicenseDAL.GetAllInternationalLicensesFilteredBySerialNumber(StrValue)
                           : clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                case enFilterColumn.DriverID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsInternationalLicenseDAL.GetAllInternationalLicensesFilteredByDriverID_InDB(Convert.ToInt32(StrValue))
                           : clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                case enFilterColumn.LicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                            ? clsInternationalLicenseDAL.GetAllInternationalLicensesFilteredByLicenseID_InDB(Convert.ToInt32(StrValue))
                            : clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                case enFilterColumn.NationalNo:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsInternationalLicenseDAL.GetAllInternationalLicensesFilteredByNationalNo_InDB(StrValue)
                           : clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();

                default:
                    return clsInternationalLicenseDAL.GetAllInternationalLicenses_InDB();
            }
        }
        public static int GetSystemRecordsNumber()
        {
            return clsInternationalLicenseDAL.GetSystemRecordsNumber_InDB();
        }

        internal static DataTable GetInternationalLicensesList(int DriverID)
        {
            return (DriverID != -1)
                   ? clsInternationalLicenseDAL.GetInternationalLicensesByDriverID_InDB(DriverID) 
                   : new DataTable();
        }
    }
}
