using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsLicense
    {
        // add an sql agent job, that checks if today s date is greater or equivalent to the expiration date
        // and if it is make the license inactive!

        enum enMode { NullOrEmpty = 0, AddNew = 1, Update = 2 };
        internal enum enIssueReason 
        { 
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4 
        };

        public int LicenseID { get; private set; }
        public string SerialNumber { get; private set; }
        public clsLicenseClass LicenseClass { get; private set; } 
        public int ApplicationID { get; private set; }
        public clsDriver Driver { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public Decimal PaidFees { get; private set; }
        internal enIssueReason IssueReason { get; private set; } // Only internal classes will use it !
        public string Notes { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDetained { get; private set; }
        public int CreatedByUserID { get; private set; }

        public string StrIssueReason
        {
            get 
            { 
                switch (this.IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";

                    case enIssueReason.Renew:
                        return "Renew";

                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement for Damaged";

                    case enIssueReason.ReplacementForLost:
                        return "Replacement for Lost";

                    default:
                        return "Unexpected error!";
                } 
            }
        }
        public bool IsExpired
        {
            get { return DateTime.Today >= this.ExpirationDate; }
        }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;


        internal static clsLicense _Convert_DTO_To_Object(clsLicenseDAL.clsLicenseDTO LicenseDTO)
        {
            if (LicenseDTO == null || LicenseDTO.DriverDTO == null) return null;
            
            clsLicense License = new clsLicense();

            License.LicenseID = LicenseDTO.LicenseID;
            License.SerialNumber = LicenseDTO.SerialNumber;
            License.LicenseClass = clsLicenseClass.Find((clsLicenseClass.enLicenseClass)LicenseDTO.LicenseClassID); // Lazy loading
            License.ApplicationID = LicenseDTO.ApplicationID;
            License.Driver = clsDriver._Convert_DTO_To_Object(LicenseDTO.DriverDTO);
            License.IssueDate = LicenseDTO.IssueDate;
            License.ExpirationDate = LicenseDTO.ExpirationDate;
            License.PaidFees = LicenseDTO.PaidFees;
            License.IssueReason = (enIssueReason)LicenseDTO.IssueReason;
            License.Notes = LicenseDTO.Notes;
            License.IsActive = LicenseDTO.IsActive;
            License.IsDetained = clsDetainedLicense.IsLicenseDetained(License.LicenseID);
            License.CreatedByUserID = LicenseDTO.CreatedByUserID;

            License._Mode = enMode.Update;

            return License;
        }
        internal static clsLicenseDAL.clsLicenseDTO _Convert_Object_To_DTO(clsLicense License)
        {
            if (License == null || License.LicenseClass ==  null || License.Driver == null) return null;

            clsLicenseDAL.clsLicenseDTO LicenseDTO = new clsLicenseDAL.clsLicenseDTO();

            LicenseDTO.LicenseID = License.LicenseID;
            LicenseDTO.SerialNumber = License.SerialNumber;
            LicenseDTO.LicenseClassID = Convert.ToInt32(License.LicenseClass.LicenseClassID);
            LicenseDTO.ApplicationID = License.ApplicationID;
            LicenseDTO.DriverDTO = clsDriver._Convert_Object_To_DTO(License.Driver);
            LicenseDTO.IssueDate = License.IssueDate;
            LicenseDTO.ExpirationDate = License.ExpirationDate;
            LicenseDTO.PaidFees = License.PaidFees;
            LicenseDTO.IssueReason = Convert.ToInt32(License.IssueReason);
            LicenseDTO.Notes = License.Notes;
            LicenseDTO.IsActive = License.IsActive;
            LicenseDTO.CreatedByUserID = License.CreatedByUserID;

            return LicenseDTO;
        }

        private static clsLicense _GetNewObjectToAdd(string SerialNumber, clsLicenseClass LicenseClass, int ApplicationID, 
                                                     clsDriver Driver, enIssueReason IssueReason, string Notes, int CreatedByUserID)
        {
            if (LicenseClass == null) return null;
            if (Driver == null) return null;
            if (IsLicenseExists(Driver.DriverID, Convert.ToInt32(LicenseClass.LicenseClassID))) return null;
            if (!clsUser.IsUserExists(CreatedByUserID)) return null;

            DateTime ExpirationDate = LicenseClass.ExpirationDate;

            return new clsLicense(-1, SerialNumber, LicenseClass, ApplicationID, Driver, DateTime.Now, ExpirationDate,
                                  LicenseClass.ClassFees, IssueReason, Notes, true, false, CreatedByUserID, enMode.AddNew);
        }
        private static clsLicense _GetNewObjectToAddToReplaceOldLicense(string SerialNumber, clsLicenseClass LicenseClass, int ApplicationID, clsDriver Driver, 
                                                                        enIssueReason IssueReason, string Notes, int CreatedByUserID)
        {
            if (LicenseClass == null) return null;
            if (Driver == null) return null;
            if (IsActiveLicenseExists(Driver.DriverID, Convert.ToInt32(LicenseClass.LicenseClassID))) return null;
            if (!clsUser.IsUserExists(CreatedByUserID)) return null;

            DateTime ExpirationDate = LicenseClass.ExpirationDate;

            return new clsLicense(-1, SerialNumber, LicenseClass, ApplicationID, Driver, DateTime.Now, ExpirationDate,
                                  LicenseClass.ClassFees, IssueReason, Notes, true, false, CreatedByUserID, enMode.AddNew);
        }



        private bool _AddNew()
        {
            this.LicenseID = clsLicenseDAL.AddNewLicense_InDB(_Convert_Object_To_DTO(this));

            return (this.LicenseID != -1);
        }
        private bool _Update()
        {
            return clsLicenseDAL.UpdateLicense_InDB(_Convert_Object_To_DTO(this));
        }
        private bool _Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        clsLicense() { }
        clsLicense(int LicenseID, string SerialNumber, clsLicenseClass LicenseClass, int ApplicationID, clsDriver Driver, DateTime IssueDate, DateTime ExpirationDate, 
            Decimal PaidFees, enIssueReason IssueReason, string Notes, bool IsActive, bool IsDetained, int CreatedByUserID, enMode Mode = enMode.Update) 
        {
            this.LicenseID = LicenseID;
            this.SerialNumber = SerialNumber;
            this.LicenseClass = LicenseClass;
            this.ApplicationID = ApplicationID;
            this.Driver = Driver;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.PaidFees = PaidFees;
            this.IssueReason = IssueReason;
            this.Notes = Notes; 
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.IsDetained = false; //Add a method that checks if license is detained from detained licenses class

            this._Mode = Mode;
        }

        public static clsLicense Find(int LicenseID)
        {
            return (LicenseID != -1)
                   ? _Convert_DTO_To_Object(clsLicenseDAL.GetLicenseByLicenseID_InDB(LicenseID))
                   : null;
        }
        public static clsLicense Find(string SerialNumber)
        {
            return (!string.IsNullOrEmpty(SerialNumber)) 
                   ? _Convert_DTO_To_Object(clsLicenseDAL.GetLicenseBySerialNumber_InDB(SerialNumber)) 
                   : null;
        }
        public static clsLicense FindLatestLicense(int DriverID, int LicenseClassID)
        {
            return (DriverID != -1 && LicenseClassID != -1)
                   ? _Convert_DTO_To_Object(clsLicenseDAL.GetLatestActiveLicense_InDB(DriverID, LicenseClassID))
                   : null;
        }
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            return (ApplicationID != -1)
                   ? _Convert_DTO_To_Object(clsLicenseDAL.GetLicenseByApplicationID_InDB(ApplicationID))
                   : null;
        }

        public static bool IsLicenseExists(int DriverID, int LicenseClassID)
        {
            return (DriverID != -1 && LicenseClassID != -1)
                   ? clsLicenseDAL.IsLicenseExistsByDriverIDAndLicenseClassID_InDB(DriverID, LicenseClassID)
                   : false;
        }
        public static bool IsActiveLicenseExists(int DriverID, int LicenseClassID)
        {
            return (DriverID != -1 && LicenseClassID != -1)
                   ? clsLicenseDAL.IsActiveLicenseExistsByDriverIDAndLicenseClassID_InDB(DriverID, LicenseClassID)
                   : false;
        }

        internal static clsLicense IssueNewDrivingLicense(clsPerson Person, clsLicenseClass LicenseClass, int ApplicationID, string Notes, int CreatedByUserID)
        {
            clsDriver Driver = clsDriver.FindByPersonID(Person.PersonID);

            if (Driver == null)
            {
                Driver = clsDriver.GetNewObjectToAdd(Person, CreatedByUserID);
                if (Driver == null) return null;
                if (!Driver.Save()) return null;
            }

            clsSerialNumber SerialNumberObj = clsSerialNumber.Find(clsSerialNumber.enSerialNumberID.Local);
            string SerialNumber = SerialNumberObj.GenerateNewSerialNumber();

            clsLicense License = clsLicense._GetNewObjectToAdd(SerialNumber, LicenseClass, ApplicationID, Driver, enIssueReason.FirstTime, Notes, CreatedByUserID);
            if (License == null) return null;
            if (!License._Save()) return null;

            return (SerialNumberObj.UpdateLatestSerialNumber()) ? License : null;
        }
        internal clsLicense ReissueDrivingLicense(int ApplicationID, enIssueReason IssueReason, string Notes, int CreatedByUserID)
        {
            if (this.IsDetained) return null;

            this.IsActive = false;
            if (!this._Save()) return null;

            clsSerialNumber SerialNumberObj = clsSerialNumber.Find(clsSerialNumber.enSerialNumberID.Local);
            string SerialNumber = SerialNumberObj.GenerateNewSerialNumber();

            clsLicense License = clsLicense._GetNewObjectToAddToReplaceOldLicense(SerialNumber, this.LicenseClass, ApplicationID, this.Driver, IssueReason, Notes, CreatedByUserID);
            if (!License._Save()) return null;

            return (SerialNumberObj.UpdateLatestSerialNumber()) ? License : null;
        }


        public clsLicense RenewDrivingLicense(out int RenewLicenseApplicationID, string Notes, int CreatedByUserID)
        {
            RenewLicenseApplicationID = -1;

            if (!this.IsExpired) return null;
            if (this.Driver.HasActiveLicense(Convert.ToInt32(this.LicenseClass.LicenseClassID))) return null;


            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.RenewDrivingLicenseService);

            clsApplication RenewDLApp = clsApplication.GetAddNewApplicationObject(this.Driver.Person, ApplicationType, CreatedByUserID);
            if (RenewDLApp == null) return null;
            if (!RenewDLApp.SaveBaseApplication()) return null;

            clsLicense NewLicense = this.ReissueDrivingLicense(RenewDLApp.ApplicationID, clsLicense.enIssueReason.Renew, Notes, CreatedByUserID);
            if (NewLicense == null) return null;

            RenewLicenseApplicationID = RenewDLApp.ApplicationID;
            return (RenewDLApp.CompleteApplication()) ? NewLicense : null;
        }
        public enum enReplacementType
        {
            Damaged = 1,
            Lost = 2
        }
        public clsLicense ReplacementDrivingLicense(out int ReplacementLicenseApplicationID, enReplacementType ReplacementType, string Notes, int CreatedByUserID)
        {
            ReplacementLicenseApplicationID = -1;
            if (!this.IsActive) return null;


            clsApplicationType ApplicationType = (ReplacementType == enReplacementType.Damaged)
                                                 ? clsApplicationType.Find(clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense)
                                                 : clsApplicationType.Find(clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense);

            clsApplication ReplacementDLApp = clsApplication.GetAddNewApplicationObject(this.Driver.Person, ApplicationType, CreatedByUserID);
            if (ReplacementDLApp == null) return null;
            if (!ReplacementDLApp.SaveBaseApplication()) return null;

            clsLicense.enIssueReason IssueReason = (ReplacementType == enReplacementType.Damaged)
                                                   ? clsLicense.enIssueReason.ReplacementForDamaged
                                                   : clsLicense.enIssueReason.ReplacementForLost;


            clsLicense NewLicense = this.ReissueDrivingLicense(ReplacementDLApp.ApplicationID, IssueReason, Notes, CreatedByUserID);
            if (NewLicense == null) return null;

            ReplacementLicenseApplicationID = ReplacementDLApp.ApplicationID;
            return (ReplacementDLApp.CompleteApplication()) ? NewLicense : null;
        }

        public clsDetainedLicense FindDetainedLicense() => clsDetainedLicense.FindLatestDetainedLicenseByLicenseID(this.LicenseID); 
 
        public bool Detain(out int DetainedLicenseID, Decimal FineFees, string Notes, int CreatedByUserID)
        {
            DetainedLicenseID = -1;

            if (!this.IsActive) return false;
            if (this.IsDetained) return false;

            clsDetainedLicense DetainedLicense = clsDetainedLicense.GetNewObjectToAdd(this.LicenseID, FineFees, CreatedByUserID, Notes);
            if (DetainedLicense == null) return false;
            if (!DetainedLicense.Save()) return false;

            DetainedLicenseID = DetainedLicense.DetainedLicenseID;
            this.IsDetained = true;
            return true;
        }
        public bool Release(out int ReleaseApplicationID, int ReleasedByUserID)
        {
            ReleaseApplicationID = -1;

            if (!this.IsDetained) return false;

            clsDetainedLicense DetainedLicense = clsDetainedLicense.FindLatestDetainedLicenseByLicenseID(LicenseID);
            if (DetainedLicense == null) return false;

            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);
            
            clsApplication Application = clsApplication.GetAddNewApplicationObject(this.Driver.Person, ApplicationType, ReleasedByUserID);
            if (Application == null) return false;
            if (!Application.SaveBaseApplication()) return false;

            if (!DetainedLicense.ReleaseDetainedLicense(Application.ApplicationID, ReleasedByUserID)) return false;

            if (!Application.CompleteApplication()) return false;

            this.IsDetained = false;
            ReleaseApplicationID = DetainedLicense.ReleaseApplicationID;
            return true;
        }


        public static int GetActiveLicensesSystemRecordsNumber() => clsLicenseDAL.GetActiveLicensesSystemRecordsNumber_InDB();
        public static int GetExpiredLicensesRecordsNumber() => clsLicenseDAL.GetExpiredLicensesSystemRecordsNumber_InDB();

        internal static DataTable GetLicensesListByDriverID(int DriverID)
        {
            return (DriverID != -1)
                   ? clsLicenseDAL.GetLicensesByDriverID_InDB(DriverID) 
                   : new DataTable();
        }
    }
}
