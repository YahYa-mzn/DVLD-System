// Class: Person Business Logic
// Manages person CRUD operations with soft/permanent delete
// Validates all person data before database operations
// Handles unique field constraints (NationalNo, Phone, Email)
// Supports filtering and searching by multiple fields
// Works with Country for nationality data

using System;
using System.Data;
using DVLD_DAL;
using static DVLD_DAL.clsPersonDAL;

namespace DVLD_BLL
{
    public class clsPerson
    {
        // Operation modes
        enum enMode
        {
            NullOrEmpty = 0,
            AddNew = 1,
            Update = 2,
            SoftDelete = 3,
            PermanentDelete = 4
        }

        // Deletion options
        public enum enDeletionType
        {
            SoftDelete = 1,
            PermanentDelete = 2
        }

        // Read modes for filtering people list
        public enum enReadMode
        {
            Active = 0,     // Not marked for deletion
            All = 1,        // All records
            Deleted = 2     // Marked for deletion
        }

        // Unique fields requiring validation
        public enum enUniqueField
        {
            NationalNo = 1,
            Phone = 2,
            Email = 3
        }

        // Search filter columns
        public enum enFilterColumn
        {
            None = 0,
            PersonID = 1,
            NationalNo = 2,
            FirstName = 3,
            SecondName = 4,
            ThirdName = 5,
            LastName = 6,
            Phone = 7,
            Email = 8,
        }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;

        public int PersonID { get; private set; }
        public string NationalNo { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string LastName { get; private set; }

        // Computed property combining all name parts
        public string FullName => clsUtility.GetFullName(this.FirstName, this.SecondName, this.ThirdName, this.LastName);

        public char Gender { get; private set; }
        public DateTime BirthDate { get; private set; }

        // Property to get Person Age 
        public int Age => clsUtility.GetAge(this.BirthDate);

        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public clsCountry Country { get; private set; }
        public string ImagePath { get; private set; }
        private bool IsMarkedToDelete { get; set; }


        // Converts DTO from DAL to BLL person object
        internal static clsPerson _Convert_DTO_To_Object(clsPersonDAL.clsPersonDTO PersonDTO)
        {
            if (PersonDTO == null)
                return null;

            clsPerson Person = new clsPerson();

            Person.PersonID = PersonDTO.PersonID;
            Person.NationalNo = PersonDTO.NationalNo;
            Person.FirstName = PersonDTO.FirstName;

            // Handle optional name fields
            Person.SecondName = string.IsNullOrEmpty(PersonDTO.SecondName) ? "" : PersonDTO.SecondName;
            Person.ThirdName = string.IsNullOrEmpty(PersonDTO.ThirdName) ? "" : PersonDTO.ThirdName;

            Person.LastName = PersonDTO.LastName;
            Person.Gender = PersonDTO.Gender;
            Person.BirthDate = PersonDTO.BirthDate;
            Person.Phone = PersonDTO.Phone;
            Person.Email = PersonDTO.Email;
            Person.Address = PersonDTO.Address;

            Person.Country = clsCountry.Find(PersonDTO.CountryID);

            Person.ImagePath = (!string.IsNullOrEmpty(PersonDTO.ImagePath)) ? PersonDTO.ImagePath : "";
            Person.IsMarkedToDelete = PersonDTO.IsMarkedToDelete;
            Person._Mode = enMode.Update;

            return Person;
        }

        // Converts BLL person object to DTO for DAL
        internal static clsPersonDAL.clsPersonDTO _Convert_Object_To_DTO(clsPerson Person)
        {
            if (Person == null)
                return null;

            clsPersonDTO PersonDTO = new clsPersonDTO();

            PersonDTO.PersonID = Person.PersonID;
            PersonDTO.NationalNo = Person.NationalNo;
            PersonDTO.FirstName = Person.FirstName;

            // Convert empty strings to null for optional fields
            PersonDTO.SecondName = (!string.IsNullOrEmpty(Person.SecondName)) ? Person.SecondName : null;
            PersonDTO.ThirdName = (!string.IsNullOrEmpty(Person.ThirdName)) ? Person.ThirdName : null;

            PersonDTO.LastName = Person.LastName;
            PersonDTO.Gender = Person.Gender;
            PersonDTO.BirthDate = Person.BirthDate;
            PersonDTO.Phone = Person.Phone;
            PersonDTO.Email = Person.Email;
            PersonDTO.Address = Person.Address;
            PersonDTO.CountryID = Person.Country.CountryID;

            PersonDTO.ImagePath = (!string.IsNullOrEmpty(Person.ImagePath)) ? Person.ImagePath : null;
            PersonDTO.IsMarkedToDelete = Person.IsMarkedToDelete;

            return PersonDTO;
        }

        internal void _EmptyObject()
        {
            this.PersonID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.Gender = default(char);
            this.BirthDate = default(DateTime);
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.Country.EmptyObject();
            this.ImagePath = string.Empty;
            this.IsMarkedToDelete = false;
        }

        private bool _AddNew()
        {
            this.PersonID = clsPersonDAL.AddNewPerson_InDB(_Convert_Object_To_DTO(this));

            return (this.PersonID != -1) ? true : false;
        }
        private bool _Update()
        {
            return clsPersonDAL.UpdatePerson_InDB(_Convert_Object_To_DTO(this));
        }
        private bool _Delete()
        {
            if (clsPersonDAL.DeletePerson_InDB(this.PersonID))
            {
                this._EmptyObject();
                return true;
            }

            return false;
        }


        clsPerson() { }
        clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, char Gender, DateTime BirthDate,
                  string Phone, string Email, string Address, clsCountry Country, string ImagePath, bool IsMarkedToDelete, enMode Mode = enMode.Update)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.Country = Country;
            this.ImagePath = ImagePath;
            this.IsMarkedToDelete = IsMarkedToDelete;

            this._Mode = Mode;
        }


        // Factory method for creating new person object with validation
        public static clsPerson GetAddNewPersonObject(string NationalNo, string FirstName, string SecondName, string ThirdName,
                                               string LastName, char Gender, DateTime BirthDate, string Phone, string Email, string Address,
                                               int CountryID, string ImagePath)
        {
            // Validate all required inputs
            if (!clsValidation.IsValidNationalNo(NationalNo)) return null;
            if (!clsValidation.IsValidRequiredName(FirstName)) return null;
            if (!clsValidation.IsValidOptionalName(SecondName)) return null;
            if (!clsValidation.IsValidOptionalName(ThirdName)) return null;
            if (!clsValidation.IsValidRequiredName(LastName)) return null;
            if (clsUtility.GetAge(BirthDate) < 18) return null;
            if (!clsValidation.IsValidPhone(Phone)) return null;
            if (!clsValidation.IsValidEmail(Email)) return null;
            if (!clsValidation.IsValidAddress(Address)) return null;

            clsCountry Country = clsCountry.Find(CountryID);

            if (Country == null) return null;

            // All validations passed, create new person object
            return new clsPerson(-1, NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, BirthDate,
                                 Phone, Email, Address, Country, ImagePath, false, enMode.AddNew);
        }

        // Updates person information with validation
        public bool SetUpdatedPersonInfo(string NationalNo, string FirstName, string SecondName, string ThirdName,
                                 string LastName, char Gender, DateTime BirthDate, string Phone, string Email, string Address,
                                 int CountryID, string ImagePath)
        {
            // Validate all inputs before updating
            if (!clsValidation.IsValidNationalNo(NationalNo)) return false;
            if (!clsValidation.IsValidRequiredName(FirstName)) return false;
            if (!clsValidation.IsValidOptionalName(SecondName)) return false;
            if (!clsValidation.IsValidOptionalName(ThirdName)) return false;
            if (!clsValidation.IsValidRequiredName(LastName)) return false;
            if (clsUtility.GetAge(BirthDate) < 18) return false;
            if (!clsValidation.IsValidPhone(Phone)) return false;
            if (!clsValidation.IsValidEmail(Email)) return false;
            if (!clsValidation.IsValidAddress(Address)) return false;

            clsCountry Country = clsCountry.Find(CountryID);
            if (Country == null) return false;

            // Update all fields
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.Country = Country;
            this.ImagePath = ImagePath;

            return this.Save();
        }

        // Compares all fields for equality
        public bool IsSameAs(clsPerson Person)
        {
            if (Person == null) return false;

            return this.PersonID == Person.PersonID &&
                   this.NationalNo == Person.NationalNo &&
                   this.FirstName == Person.FirstName &&
                   this.SecondName == Person.SecondName &&
                   this.ThirdName == Person.ThirdName &&
                   this.LastName == Person.LastName &&
                   this.Gender == Person.Gender &&
                   this.BirthDate == Person.BirthDate &&
                   this.Phone == Person.Phone &&
                   this.Email == Person.Email &&
                   this.Address == Person.Address &&
                   this.Country.CountryID == Person.Country.CountryID &&
                   this.ImagePath == Person.ImagePath &&
                   this.IsMarkedToDelete == Person.IsMarkedToDelete;
        }

        public void PrepareObjectToDelete(enDeletionType DeletionType = enDeletionType.SoftDelete)
        {
            this._Mode = (DeletionType == enDeletionType.SoftDelete) ? enMode.SoftDelete : enMode.PermanentDelete;
        }

        // Checks if unique fields value already exists in database
        public static bool IsNationalNoExists(string NationalNo)
        {
            return (clsValidation.IsValidNationalNo(NationalNo))
                   ? clsPersonDAL.IsExistsByNationalNo_InDB(NationalNo)
                   : false;
        }
        public static bool IsEmailExists(string Email)
        {
            return (clsValidation.IsValidEmail(Email))
                   ? clsPersonDAL.IsExistsByEmail_InDB(Email)
                   : false;
        }
        public static bool IsPhoneExists(string Phone)
        {
            return (clsValidation.IsValidPhone(Phone))
                   ? clsPersonDAL.IsExistsByPhone_InDB(Phone)
                   : false;
        }


        public static clsPerson Find(int PersonID)
        {
            if (PersonID == -1) return null;

            return (clsValidation.IsOnlyDigits(PersonID.ToString()))
                   ? _Convert_DTO_To_Object(clsPersonDAL.GetPersonByPersonID_InDB(PersonID))
                   : null;
        }
        public static clsPerson Find(string NationalNo)
        {
            return (clsValidation.IsValidNationalNo(NationalNo))
                   ? _Convert_DTO_To_Object(clsPersonDAL.GetPersonByNationalNo_InDB(NationalNo))
                   : null;
        }


        public bool IsDeleted()
        {
            return (IsMarkedToDelete);
        }
        public bool CanDelete()
        {
            if (clsUser.IsUniqueFieldExists(clsUser.enUniqueField.PersonID, this.PersonID.ToString())) return false;
            if (clsDriver.IsPersonExistsAsDriver(this.PersonID)) return false;
            if (clsLocalDrivingLicenseApplication.IsPersonExistsAsApplicant(this.PersonID)) return false;

            return true;
        }
        public bool Recover()
        {
            if (this.IsDeleted() && this._Mode == enMode.Update)
            {
                this.IsMarkedToDelete = false;
                return _Update();
            }

            return false;
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    {
                        if (this._AddNew() == true)
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }

                case enMode.Update:
                    {
                        return this._Update();
                    }

                default:
                    {
                        return false;
                    }
            }
        }
        public bool Delete()
        {
            if (!CanDelete()) return false;

            switch (this._Mode)
            {
                case enMode.SoftDelete:
                    {
                        this._Mode = enMode.Update;
                        this.IsMarkedToDelete = true;
                        return this._Update();
                    }

                case enMode.PermanentDelete:
                    {
                        return this._Delete();
                    }


                default:
                    return false;
            }

        }


        // Gets total person record count by read mode
        public static int GetSystemRecordsNumber(enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.All:
                    return clsPersonDAL.GetAllSystemRecordsNumber_InDB();

                case enReadMode.Active:
                    return clsPersonDAL.GetSystemRecordsNumberFilteredByIsMarkedToDelete_InDB(false);

                case enReadMode.Deleted:
                    return clsPersonDAL.GetSystemRecordsNumberFilteredByIsMarkedToDelete_InDB(true);

                default:
                    return clsPersonDAL.GetAllSystemRecordsNumber_InDB();
            }
        }

        private static DataTable GetAllPeople(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue)) 
                           ? clsPersonDAL.GetAllPeopleFilteredByPersonID_InDB(Convert.ToInt32(StrValue)) 
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.NationalNo:
                    return (!string.IsNullOrEmpty(StrValue)) 
                           ? clsPersonDAL.GetAllPeopleFilteredByNationalNo_InDB(StrValue) 
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.FirstName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredByFirstName_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.SecondName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredBySecondName_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.ThirdName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredByThirdName_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.LastName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredByLastName_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.Phone:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredByPhone_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                case enFilterColumn.Email:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetAllPeopleFilteredByEmail_InDB(StrValue)
                           : clsPersonDAL.GetAllPeople_InDB();

                default:
                    return clsPersonDAL.GetAllPeople_InDB();
            }
        }
        private static DataTable GetActivePeople(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndPersonID_InDB(Convert.ToInt32(StrValue), false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.NationalNo:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndNationalNo_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.FirstName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndFirstName_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.SecondName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndSecondName_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.ThirdName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndThirdName_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.LastName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndLastName_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.Phone:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndPhone_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                case enFilterColumn.Email:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndEmail_InDB(StrValue, false)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);

                default:
                    return clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(false);
            }
        }
        private static DataTable GetDeletedPeople(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndPersonID_InDB(Convert.ToInt32(StrValue), true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.NationalNo:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndNationalNo_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.FirstName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndFirstName_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.SecondName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndSecondName_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.ThirdName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndThirdName_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.LastName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndLastName_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.Phone:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndPhone_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                case enFilterColumn.Email:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsPersonDAL.GetPeopleFilteredByIsMarkedToDeleteAndEmail_InDB(StrValue, true)
                           : clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);

                default:
                    return clsPersonDAL.GetPeopleFilteredByIsMarkedToDelete_InDB(true);
            }
        }

        // Gets people list based on read mode and optional filter
        public static DataTable GetPeopleList(enReadMode ReadMode, enFilterColumn FilterColumn = enFilterColumn.None, string StrValue = "")
        {
            switch (ReadMode)
            {
                case enReadMode.All:
                    return GetAllPeople(FilterColumn, StrValue);

                case enReadMode.Active:
                    return GetActivePeople(FilterColumn, StrValue);

                case enReadMode.Deleted:
                    return GetDeletedPeople(FilterColumn, StrValue);

                default:
                    return GetAllPeople(FilterColumn, StrValue);
            }
        }
    }
}