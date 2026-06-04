using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsDriver
    {
        enum enMode { NullOrEmpty = 0, AddNew = 1, Read = 2 };

        public enum enFilterColumn
        {
            None = 0,
            DriverID = 1,
            PersonID = 2,
            NationalNo = 3
        }

        public int DriverID { get; private set; }
        public clsPerson Person { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int CreatedByUserID { get; private set; }

        enMode _Mode {  get; set; } = enMode.NullOrEmpty;


        internal static clsDriver _Convert_DTO_To_Object(clsDriverDAL.clsDriverDTO DriverDTO)
        {
            if (DriverDTO == null || DriverDTO.PersonDTO == null) return null;

            clsDriver Driver = new clsDriver();

            Driver.DriverID = DriverDTO.DriverID;
            Driver.Person = clsPerson._Convert_DTO_To_Object(DriverDTO.PersonDTO);
            Driver.CreationDate = DriverDTO.CreationDate;
            Driver.CreatedByUserID = DriverDTO.CreatedByUserID;

            Driver._Mode = enMode.Read;

            return Driver;
        }
        internal static clsDriverDAL.clsDriverDTO _Convert_Object_To_DTO(clsDriver Driver)
        {
            if (Driver == null) return null;

            clsDriverDAL.clsDriverDTO DriverDTO = new clsDriverDAL.clsDriverDTO();

            DriverDTO.DriverID = Driver.DriverID;
            DriverDTO.PersonDTO = clsPerson._Convert_Object_To_DTO(Driver.Person);
            DriverDTO.CreationDate = Driver.CreationDate;
            DriverDTO.CreatedByUserID = Driver.CreatedByUserID;

            return DriverDTO;   
        }

        bool _AddNew()
        {
            this.DriverID = clsDriverDAL.AddNewDriver_InDB(_Convert_Object_To_DTO(this));

            return (DriverID != -1);
        }
        

        clsDriver() { }
        clsDriver(int DriverID, clsPerson Person, DateTime CreationDate, int CreatedByUserID, enMode Mode = enMode.Read)
        {
            this.DriverID = DriverID;
            this.Person = Person;
            this.CreationDate = CreationDate;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = Mode;
        }

        internal static clsDriver GetNewObjectToAdd(clsPerson Person, int CreatedByUserID)
        {
            if (Person == null) return null;
            if (clsDriver.IsPersonExistsAsDriver(Person.PersonID)) return null;
            if (!clsUser.IsUserExists(CreatedByUserID)) return null;

            return new clsDriver(-1, Person, DateTime.Now, CreatedByUserID, enMode.AddNew);
        }

        public static clsDriver Find(int DriverID)
        {
            return (DriverID != -1)
                   ? _Convert_DTO_To_Object(clsDriverDAL.GetDriver_InDB(DriverID))
                   : null;
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            return (PersonID != -1)
                   ? _Convert_DTO_To_Object(clsDriverDAL.GetDriverByPersonID_InDB(PersonID))
                   : null;
        }

        internal static bool IsPersonExistsAsDriver(int PersonID)
        {
            return (PersonID != -1)
                   ? clsDriverDAL.IsDriverExists_InDB(PersonID)
                   : false;
        }
        public bool HasActiveLicense(int LicenseClassID)
        {
            return clsLicense.IsActiveLicenseExists(this.DriverID, LicenseClassID);
        }

        internal bool Save()
        {
            if (this._Mode != enMode.AddNew) return false;
            if (!this._AddNew()) return false;

            this._Mode = enMode.Read;
            return true;
        }


        public static int GetSystemRecordsNumber()
        {
            return clsDriverDAL.GetSystemRecordsNumber_InDB();
        }
        public static DataTable GetDriversList(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsDriverDAL.GetAllDriversList_InDB();

                case enFilterColumn.DriverID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDriverDAL.GetAllDriversListFilteredByDriverID_InDB(Convert.ToInt32(StrValue))
                           : clsDriverDAL.GetAllDriversList_InDB();

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsDriverDAL.GetAllDriversListFilteredByPersonID_InDB(Convert.ToInt32(StrValue))
                           : clsDriverDAL.GetAllDriversList_InDB();
           
                case enFilterColumn.NationalNo:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsDriverDAL.GetAllDriversListFilteredByNationalNo_InDB(StrValue)
                           : clsDriverDAL.GetAllDriversList_InDB();

                default:
                    return clsDriverDAL.GetAllDriversList_InDB();
            }

        }

        public DataTable GetLicensesList() => clsLicense.GetLicensesListByDriverID(this.DriverID);
        public DataTable GetInternationalLicensesList() => clsInternationalLicense.GetInternationalLicensesList(this.DriverID);
    }
}
