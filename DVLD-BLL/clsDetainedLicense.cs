using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsDetainedLicense
    {
        enum enMode { NullOrEmpty = 0, AddNew = 1, Update = 2 };

        public enum enReadMode { None = 0, Detained = 1, Released = 2};
        public enum enFilterColumn
        {
            None = 0,
            DetainedLicenseID = 1,
            LicenseID = 2,
            SerialNumber = 3,
            NationalNo = 4
        }

        public int DetainedLicenseID { get; private set; }
        public int LicenseID { get; private set; }
        public DateTime DetainDate { get; private set; }
        public Decimal FineFees { get; private set; }
        public int CreatedByUserID { get; private set; }
        public bool IsReleased { get; private set; }
        public string Notes { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int ReleaseApplicationID { get; private set; }
        public int ReleasedByUserID { get; private set; }

        enMode _Mode { get; set; } = enMode.NullOrEmpty;


        private static clsDetainedLicense _Convert_DTO_To_Object(clsDetainedLicenseDAL.clsDetainedLicenseDTO DetainedLicenseDTO)
        {
            clsDetainedLicense DetainedLicense = new clsDetainedLicense();

            DetainedLicense.DetainedLicenseID = DetainedLicenseDTO.DetainedLicenseID;
            DetainedLicense.LicenseID = DetainedLicenseDTO.LicenseID;
            DetainedLicense.DetainDate = DetainedLicenseDTO.DetainDate;
            DetainedLicense.FineFees = DetainedLicenseDTO.FineFees;
            DetainedLicense.CreatedByUserID = DetainedLicenseDTO.CreatedByUserID;
            DetainedLicense.IsReleased = DetainedLicenseDTO.IsReleased;
            DetainedLicense.Notes = DetainedLicenseDTO.Notes;
            DetainedLicense.ReleaseDate = DetainedLicenseDTO.ReleaseDate;
            DetainedLicense.ReleaseApplicationID = DetainedLicenseDTO.ReleaseApplicationID;
            DetainedLicense.ReleasedByUserID = DetainedLicenseDTO.ReleasedByUserID;

            DetainedLicense._Mode = enMode.Update;

            return DetainedLicense;
        }
        private clsDetainedLicenseDAL.clsDetainedLicenseDTO _Convert_Object_To_DTO(clsDetainedLicense DetainedLicense)
        {
            clsDetainedLicenseDAL.clsDetainedLicenseDTO DetainedLicenseDTO = new clsDetainedLicenseDAL.clsDetainedLicenseDTO();

            DetainedLicenseDTO.DetainedLicenseID = DetainedLicense.DetainedLicenseID;
            DetainedLicenseDTO.LicenseID = DetainedLicense.LicenseID;
            DetainedLicenseDTO.DetainDate = DetainedLicense.DetainDate;
            DetainedLicenseDTO.FineFees = DetainedLicense.FineFees;
            DetainedLicenseDTO.CreatedByUserID = DetainedLicense.CreatedByUserID;
            DetainedLicenseDTO.IsReleased = DetainedLicense.IsReleased;
            DetainedLicenseDTO.Notes = DetainedLicense.Notes;
            DetainedLicenseDTO.ReleaseDate = DetainedLicense.ReleaseDate;
            DetainedLicenseDTO.ReleaseApplicationID = DetainedLicense.ReleaseApplicationID;
            DetainedLicenseDTO.ReleasedByUserID = DetainedLicense.ReleasedByUserID;

            return DetainedLicenseDTO;
        }

        private bool _AddNew()
        {
            this.DetainedLicenseID = clsDetainedLicenseDAL.AddNewDetainedLicense_InDB(_Convert_Object_To_DTO(this));

            return (this.DetainedLicenseID != -1);
        }
        private bool _Update()
        {
            return clsDetainedLicenseDAL.UpdateDetainedLicense_InDB(_Convert_Object_To_DTO(this));
        }

        clsDetainedLicense() { }
        clsDetainedLicense(int DetainedLicenseID, int LicenseID, DateTime DetainDate, Decimal FineFees, int CreatedByUserID, bool IsReleased, 
                           string Notes, DateTime ReleaseDate, int ReleaseApplicationID, int ReleasedByUserID, enMode Mode = enMode.Update) 
        {
            this.DetainedLicenseID = DetainedLicenseID; 
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;   
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.Notes = Notes; 
            this.ReleaseDate = ReleaseDate;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserID = ReleasedByUserID;

            this._Mode = Mode;
        }

        internal static clsDetainedLicense GetNewObjectToAdd(int License, Decimal FineFees, int CreatedByUserID, string Notes)
        {     
            if (!clsValidation.IsPositiveOrNull(FineFees)) return null;
            if (!clsUser.IsUserExists(CreatedByUserID)) return null;

            return new clsDetainedLicense(-1, License, DateTime.Now, FineFees, CreatedByUserID, false, Notes, default(DateTime), -1, -1, enMode.AddNew);
        }
        internal bool ReleaseDetainedLicense(int ReleaseApplicationID, int ReleasedByUserID)
        {
            if (this._Mode != enMode.Update) return false;
            if (this.IsReleased) return false;

            this.IsReleased = true;
            this.ReleaseDate = DateTime.Now;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserID = ReleasedByUserID;

            return this.Save();
        }

        public static clsDetainedLicense Find(int DetainedLicenseID)
        {
            return (DetainedLicenseID != -1)
                   ? _Convert_DTO_To_Object(clsDetainedLicenseDAL.GetDetainedLicense_InDB(DetainedLicenseID))
                   : null;
        }
        internal static clsDetainedLicense FindLatestDetainedLicenseByLicenseID(int LicenseID)
        {
            return (LicenseID != -1)
                   ? _Convert_DTO_To_Object(clsDetainedLicenseDAL.GetLatestDetainedLicenseByLicenseID_InDB(LicenseID))
                   : null;
        }
        internal static bool IsLicenseDetained(int LicenseID)
        {
            return (LicenseID != -1)
                   ? clsDetainedLicenseDAL.IsLicenseDetained_InDB(LicenseID)
                   : false;
        }

        internal bool Save()
        {
            switch (this._Mode)
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


        private static DataTable _GetLicenses(string StrValue, enFilterColumn FilterColumn)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();

                case enFilterColumn.DetainedLicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByDetainedLicenseID_InDB(Convert.ToInt32(StrValue))
                           : clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();

                case enFilterColumn.LicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByLicenseID_InDB(Convert.ToInt32(StrValue))
                           : clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();

                case enFilterColumn.SerialNumber:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredBySerialNumber_InDB(StrValue)
                           : clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();

                case enFilterColumn.NationalNo:
                    return (clsValidation.IsOnlyLettersAndDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByNationalNo_InDB(StrValue)
                           : clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();

                default:
                    return clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();
            }
        }
        private static DataTable _GetDetainedLicenses(string StrValue, enFilterColumn FilterColumn)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);

                case enFilterColumn.DetainedLicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue)) 
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByDetainedLicenseIDAndIsReleased_InDB(Convert.ToInt32(StrValue), false) 
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);

                case enFilterColumn.LicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue)) 
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByLicenseIDAndIsReleased_InDB(Convert.ToInt32(StrValue), false) 
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);

                case enFilterColumn.SerialNumber:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredBySerialNumberAndIsReleased_InDB(StrValue, false)
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);

                case enFilterColumn.NationalNo:
                    return (clsValidation.IsOnlyLettersAndDigits(StrValue)) 
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByNationalNoAndIsReleased_InDB(StrValue, false) 
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);

                default:
                    return clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(false);
            }
        }
        private static DataTable _GetReleasedLicenses(string StrValue, enFilterColumn FilterColumn)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);

                case enFilterColumn.DetainedLicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByDetainedLicenseIDAndIsReleased_InDB(Convert.ToInt32(StrValue), true)
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);

                case enFilterColumn.LicenseID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByLicenseIDAndIsReleased_InDB(Convert.ToInt32(StrValue), true)
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);

                case enFilterColumn.SerialNumber:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredBySerialNumberAndIsReleased_InDB(StrValue, true)
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);

                case enFilterColumn.NationalNo:
                    return (clsValidation.IsOnlyLettersAndDigits(StrValue))
                           ? clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByNationalNoAndIsReleased_InDB(StrValue, true)
                           : clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);

                default:
                    return clsDetainedLicenseDAL.GetAllDetainedLicensesFilteredByIsReleased_InDB(true);
            }
        }

        public static DataTable GetDetainedLicensesList(string StrValue, enFilterColumn FilterColumn, enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.None:
                    return _GetLicenses(StrValue, FilterColumn);

                case enReadMode.Detained:
                    return _GetDetainedLicenses(StrValue, FilterColumn);

                case enReadMode.Released:
                    return _GetReleasedLicenses(StrValue, FilterColumn);

                default:
                    return clsDetainedLicenseDAL.GetAllDetainedLicenses_InDB();
            }
        }
        public static int GetSystemRecordsNumber(enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.None:
                    return clsDetainedLicenseDAL.GetSystemRecordsNumber_InDB();

                case enReadMode.Detained:
                    return clsDetainedLicenseDAL.GetSystemRecordsNumberByIsReleased_InDB(false);

                case enReadMode.Released:
                    return clsDetainedLicenseDAL.GetSystemRecordsNumberByIsReleased_InDB(true);

                default:
                    return clsDetainedLicenseDAL.GetSystemRecordsNumber_InDB();
            }
        }
    }
}
