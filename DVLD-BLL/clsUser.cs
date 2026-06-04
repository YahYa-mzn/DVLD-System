// Class: User Business Logic
// Manages user accounts with activation/deactivation/deletion
// Links person records to user credentials
// Handles password validation and status management
// Supports soft delete (status=Deleted) and permanent delete
// Tracks who created each user account

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsUser
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

        // User account status values
        public enum enStatus
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }

        // Deletion options
        public enum enDeletionType
        {
            SoftDelete = 1,
            PermanentDelete = 2
        }

        // Read modes for filtering users list
        public enum enReadMode
        {
            All = 0,
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }

        // Unique fields requiring validation
        public enum enUniqueField
        {
            PersonID = 1,
            UserName = 2
        }

        // Search filter columns
        public enum enFilterColumn
        {
            None = 0,
            UserID = 1,
            PersonID = 2,
            UserName = 3,
            CreatedByUserID = 4
        }

        public clsPerson Person { get; private set; }

        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public enStatus Status { get; private set; }
        public int CreatedByUserID { get; private set; }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;


        private static clsUser _Convert_DTO_To_Object(clsUserDAL.clsUserDTO UserDTO)
        {
            if (UserDTO == null)
                return null;

            clsUser User = new clsUser();

            User.Person = clsPerson._Convert_DTO_To_Object(UserDTO.PersonDTO);
            User.UserID = UserDTO.UserID;
            User.UserName = UserDTO.UserName;
            User.Password = UserDTO.Password;
            User.Status = (enStatus)UserDTO.Status;
            User.CreatedByUserID = UserDTO.CreatedByUserID;
            User._Permissions = (enPermissions)UserDTO.Permissions; 
            User._GetRole();

            User._Mode = enMode.Update;

            return User;
        }
        private static clsUserDAL.clsUserDTO _Convert_Object_To_DTO(clsUser User)
        {
            clsUserDAL.clsUserDTO UserDTO = new clsUserDAL.clsUserDTO();

            UserDTO.PersonDTO = clsPerson._Convert_Object_To_DTO(User.Person);

            UserDTO.UserID = User.UserID;
            UserDTO.UserName = User.UserName;
            UserDTO.Password = User.Password;
            UserDTO.Status = Convert.ToInt32(User.Status);
            UserDTO.CreatedByUserID = Convert.ToInt32(User.CreatedByUserID);
            UserDTO.Permissions = Convert.ToInt32(User._Permissions);

            return UserDTO;
        }

        // Placeholder for future password hashing implementation
        private static string HashPassword(string Password)
        {
            // TODO: Password will be hashed later

            return Password;
        }

        // Resets user object to empty state
        private void _EmptyObject()
        {
            this.Person = null;
            this.UserID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Status = enStatus.Deleted;
            this.CreatedByUserID = -1;
        }

        private bool _AddNew()
        {
            this.UserID = clsUserDAL.AddNewUser_InDB(_Convert_Object_To_DTO(this));

            return (UserID != -1);
        }
        private bool _Update()
        {
            return clsUserDAL.UpdateUser_InDB(_Convert_Object_To_DTO(this));
        }
        private bool _Delete()
        {
            if (clsUserDAL.DeleteUser_InDB(this.UserID))
            {
                this._EmptyObject();
                return true;
            }

            return false;
        }


        clsUser() { }
        clsUser(clsPerson Person, int UserID, string UserName, string Password, enStatus Status, int CreatedByUserID, enPermissions Permissions, enMode Mode = enMode.Update)
        {
            this.Person = Person;
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.Status = Status;
            this.CreatedByUserID = CreatedByUserID;
            this._Permissions = Permissions;    
            this._GetRole();

            this._Mode = Mode;
        }


        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            return (clsValidation.IsValidUserName(UserName) && clsValidation.IsValidPassword(Password))
                ? _Convert_DTO_To_Object(clsUserDAL.GetUserByUserNamePassword_InDB(UserName, Password))
                : null;
        }
        public static clsUser FindByUserID(int UserID)
        {
            if (UserID == -1) return null;

            return (clsValidation.IsOnlyDigits(UserID.ToString()))
                   ? _Convert_DTO_To_Object(clsUserDAL.GetUserByUserID_InDB(UserID))
                   : null;
        }
        public static bool IsUserExists(int UserID)
        {
            return (UserID != -1)
                   ? clsUserDAL.IsUserExists_InDB(UserID)
                   : false;
        }

        // Checks if unique field value already exists in database
        public static bool IsUniqueFieldExists(enUniqueField Field, string StrValue)
        {
            switch (Field)
            {
                case enUniqueField.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.IsPersonIDExists_InDB(Convert.ToInt32(StrValue))
                           : false;

                case enUniqueField.UserName:
                    return (clsValidation.IsValidUserName(StrValue))
                           ? clsUserDAL.IsUserNameExists_InDB(StrValue)
                           : false;

                default:
                    return false;
            }
        }

        public static clsUser GetAddNewUserObject(clsPerson Person, string UserName, string Password, int CreatedByUserID, 
                                                  enPermissions Permissions, enStatus Status = enStatus.Active)
        {
            if (Person == null) return null;
            if (!clsValidation.IsValidUserName(UserName)) return null;
            if (!clsValidation.IsValidPassword(Password)) return null;
            if (Permissions == enPermissions.None) return null;
            // TODO: Hash the Password later

            return new clsUser(Person, -1, UserName, Password, Status, CreatedByUserID, Permissions, enMode.AddNew);
        }
        public static clsUser GetAddNewUserObject(clsPerson Person, string UserName, string Password, int CreatedByUserID,
                                                  enRole Role, enStatus Status = enStatus.Active)
        {
            if (Person == null) return null;
            if (!clsValidation.IsValidUserName(UserName)) return null;
            if (!clsValidation.IsValidPassword(Password)) return null;
            if (Role == enRole.None || Role == enRole.Clerk) return null;
            // TODO: Hash the Password later

            return new clsUser(Person, -1, UserName, Password, Status, CreatedByUserID, _GetPermissions(Role), enMode.AddNew);
        }
        public bool SetUpdatedUserInfo(string UserName, string Password, enStatus Status)
        {
            if (this.IsDeleted()) return false;
            if (!clsValidation.IsValidUserName(UserName)) return false;
            if (!clsValidation.IsValidPassword(Password)) return false;

            this.UserName = UserName;
            // TODO: Hash password here 
            this.Password = Password;
            this.Status = Status;

            return this.Save();
        }
        public bool SetUpdatedUserInfo(string UserName, string Password, enStatus Status, enRole Role)
        {
            if (this.IsDeleted()) return false;
            if (!clsValidation.IsValidUserName(UserName)) return false;
            if (!clsValidation.IsValidPassword(Password)) return false;
            if (Role == enRole.None) return false;

            this.UserName = UserName;
            // TODO: Hash password here 
            this.Password = Password;
            this.Status = Status;

            return this.Save();
        }
        public bool SetUpdatedUserInfo(string UserName, string Password, enStatus Status, enPermissions Permissions)
        {
            if (this.IsDeleted()) return false;
            if (!clsValidation.IsValidUserName(UserName)) return false;
            if (!clsValidation.IsValidPassword(Password)) return false;
            if (Permissions == enPermissions.None) return false;

            this.UserName = UserName;
            // TODO: Hash password here 
            this.Password = Password;
            this.Status = Status;
            this._Permissions = Permissions;

            return this.Save();
        }


        // Compares all fields for equality
        public bool IsSameAs(clsUser User)
        {
            if (User == null) return false;

            return (this.Person.IsSameAs(User.Person) &&
                    this.UserID == User.UserID &&
                    this.UserName == User.UserName &&
                    this.IsPasswordMatchUserPassword(User.Password) &&
                    this.CreatedByUserID == User.CreatedByUserID &&
                    this.Status == User.Status);
        }

        // Checks if password matches user's stored password
        public bool IsPasswordMatchUserPassword(string Password)
        {
            return (this.Password == Password);
        }

        // Sets deletion mode for Delete operations
        public void PrepareObjectToDelete(enDeletionType DeletionType)
        {
            this._Mode = (DeletionType == enDeletionType.SoftDelete) ? enMode.SoftDelete : enMode.PermanentDelete;
        }

        public bool IsActive()
        {
            return (this.Status == enStatus.Active);
        }
        public bool IsDeleted()
        {
            return (this.Status == enStatus.Deleted);
        }

        public bool Activate()
        {
            if (this.IsActive() || this.IsDeleted()) return false;

            this.Status = enStatus.Active;
            return Save();
        }
        public bool Deactivate()
        {
            if (!this.IsActive()) return false;

            this.Status = enStatus.Inactive;
            return Save();
        }
        public bool Recover()
        {
            if (!this.IsDeleted()) return false;

            this.Status = enStatus.Inactive;
            return Save();
        }

        /*
        public bool CanDelete()
        {
            if (clsDriver.IsPersonExistsAsDriver(this.Person.PersonID)) return false;
            if (clsLocalDrivingLicenseApplication.IsPersonExistsAsApplicant(this.Person.PersonID)) return false;

            return true;
        }
        */

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew() && !this.Person.IsDeleted())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }
        public bool Delete()
        {
            //if (!CanDelete()) return false;

            switch (this._Mode)
            {
                case enMode.SoftDelete:
                    if (this.Status != enStatus.Deleted)
                    {
                        this.Status = enStatus.Deleted;
                        this._Mode = enMode.Update;
                        return Save();
                    }
                    return false;

                // Incase if want to make permanent delete of a user
                case enMode.PermanentDelete:
                    return _Delete();

                default:
                    return false;
            }
        }


        // Gets total user record count by read mode
        public static int GetSystemRecordsNumber(enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.All:
                    return clsUserDAL.GetAllSystemRecordsNumber_InDB();

                case enReadMode.Active:
                    return clsUserDAL.GetSystemRecordsNumberFilteredByStatus_InDB(Convert.ToInt32(enStatus.Active));

                case enReadMode.Inactive:
                    return clsUserDAL.GetSystemRecordsNumberFilteredByStatus_InDB(Convert.ToInt32(enStatus.Inactive));

                case enReadMode.Deleted:
                    return clsUserDAL.GetSystemRecordsNumberFilteredByStatus_InDB(Convert.ToInt32(enStatus.Deleted));

                default:
                    return clsUserDAL.GetAllSystemRecordsNumber_InDB();
            }
        }

        // Converts read mode to status value for DAL queries
        private static int GetStatusByReadMode(enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.All:
                    return -1;

                case enReadMode.Active:
                    return Convert.ToInt32(enStatus.Active);

                case enReadMode.Inactive:
                    return Convert.ToInt32(enStatus.Inactive);

                case enReadMode.Deleted:
                    return Convert.ToInt32(enStatus.Deleted);

                default:
                    return -1;
            }
        }
        // Gets All users based on the filter column
        private static DataTable GetAllUsers(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsUserDAL.GetAllUsers_InDB();

                case enFilterColumn.UserID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByUserID_InDB(Convert.ToInt32(StrValue))
                           : clsUserDAL.GetAllUsers_InDB();

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByPersonID_InDB(Convert.ToInt32(StrValue))
                           : clsUserDAL.GetAllUsers_InDB();

                case enFilterColumn.UserName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByUserName_InDB(StrValue)
                           : clsUserDAL.GetAllUsers_InDB();

                case enFilterColumn.CreatedByUserID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByCreatedByUserID_InDB(Convert.ToInt32(StrValue))
                           : clsUserDAL.GetAllUsers_InDB();

                default:
                    return clsUserDAL.GetAllUsers_InDB();
            }
        }
        // Gets users list based on read mode and optional filter
        public static DataTable GetUsersList(enReadMode ReadMode, enFilterColumn FilterColumn, string StrValue)
        {
            if (ReadMode == enReadMode.All) return GetAllUsers(FilterColumn, StrValue);

            int Status = GetStatusByReadMode(ReadMode);

            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);

                case enFilterColumn.UserID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByStatusAndUserID_InDB(Convert.ToInt32(StrValue), Status)
                           : clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);

                case enFilterColumn.PersonID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByStatusAndPersonID_InDB(Convert.ToInt32(StrValue), Status)
                           : clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);

                case enFilterColumn.UserName:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByStatusAndUserName_InDB(StrValue, Status)
                           : clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);

                case enFilterColumn.CreatedByUserID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsUserDAL.GetAllUsersFilteredByStatusAndCreatedByUserID_InDB(Convert.ToInt32(StrValue), Status)
                           : clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);

                default:
                    return clsUserDAL.GetAllUsersFilteredByStatus_InDB(Status);
            }
        }



        [Flags]
        public enum enPermissions
        {
            // the [ 1 << n ] with [Flags] is like a generic binary setter !

            All = -1,

            None = 0,

            UsersManagement = 1 << 0,   // 1
            LoginRegister = 1 << 1,   // 2

            PeopleManagement = 1 << 2,   // 4
            DriversManagement = 1 << 3,   // 8

            NewLocalDrivingLicenseApplication = 1 << 4,   // 16
            NewInternationalDrivingLicenseApplication = 1 << 5,   // 32
            RetakeTestApplication = 1 << 6,   // 64
            RenewDrivingLicenseApplication = 1 << 7,   // 128
            ReplacementForLostOrDamagedLicenseApplication = 1 << 8,   // 256
            ReleaseDrivingLicenseApplication = 1 << 9,   // 512

            LocalDrivingLicenseApplicationsManagement = 1 << 10,  // 1024
            InternationalDrivingLicenseApplicationsManagement = 1 << 11,// 2048

            TodaysTestAppointments = 1 << 12,  // 4096
            DetainedDrivingLicenseManagement = 1 << 13,  // 8192
            DetainLicense = 1 << 14,  // 16384
            ManageApplicationTypes = 1 << 15,  // 32768
            ManageTestTypes = 1 << 16,  // 65536
        }
        public enum enRole
        {
            None = 0,
            Admin = 1,
            Clerk = 2,
            Tester = 3,
            ApplicationsOfficer = 4
        }

        enPermissions _Permissions { set; get; } = enPermissions.None;    
        public enRole Role { private set; get; } = enRole.Clerk;

        public string StrRole
        {
            get
            {
                switch (Role)
                {
                    case enRole.ApplicationsOfficer:
                        return "Applications Officer";

                    default:
                        return Role.ToString();
                }
            }
        }
        public bool HasPermission(enPermissions Permissions)
        {
            if (this._Permissions == enPermissions.All) return true;

            return (this._Permissions & Permissions) == Permissions;
        }

        // Gets role by permissions so you wont need to store it in the DB
        private void _GetRole()
        {
            if (this._Permissions == enPermissions.None)
            {
                Role = enRole.None;
                return;
            }

            if (this._Permissions == enPermissions.All)
            {
                Role = enRole.Admin;
                return;
            }
            
            if (this._Permissions == enPermissions.TodaysTestAppointments) 
            {
                Role = enRole.Tester;
                return;
            }

            if (this._Permissions == _ApplicationOfficerPermissions())
            {
                Role = enRole.ApplicationsOfficer;
                return;
            }

            Role = enRole.Clerk;
        }

        // Gets Permissions by role so you can save automatically by role
        private static enPermissions _ApplicationOfficerPermissions()
        {
            // the "|" represents "+" (conceptually)

            return
                enPermissions.NewLocalDrivingLicenseApplication |
                enPermissions.NewInternationalDrivingLicenseApplication |
                enPermissions.RetakeTestApplication |
                enPermissions.RenewDrivingLicenseApplication |
                enPermissions.ReplacementForLostOrDamagedLicenseApplication |
                enPermissions.ReleaseDrivingLicenseApplication |

                enPermissions.LocalDrivingLicenseApplicationsManagement |
                enPermissions.InternationalDrivingLicenseApplicationsManagement |

                enPermissions.TodaysTestAppointments |
                enPermissions.DetainedDrivingLicenseManagement |
                enPermissions.DetainLicense;
        }
        private static enPermissions _GetPermissions(enRole enRole)
        {
            switch (enRole)
            {
                case enRole.Admin:
                    return enPermissions.All;

                case enRole.Tester:
                    return enPermissions.TodaysTestAppointments;

                case enRole.ApplicationsOfficer:
                    return _ApplicationOfficerPermissions();

                default:
                    return enPermissions.None;
            }
        }


        // Sets permissions automatically only for (Admin - Tester - App Officer)
        /// Takes only enRole as a parameter !
        private bool SetPermissions(enRole Role)
        {
            if (Role == enRole.None || Role == enRole.Clerk) return false;
            if (this._Mode == enMode.NullOrEmpty) return false;
            if (this.IsDeleted()) return false;
        
            this.Role = Role;
            this._Permissions = _GetPermissions(Role);
            return true;
        }

        // Sets permissions manually only for (Clerk)
            /// Takes only enPermission as a parameter !
        public bool SetPermissions(enPermissions Permissions)
        {
            if (Permissions == enPermissions.None) return false;
            if (this._Mode == enMode.NullOrEmpty) return false;
            if (this.IsDeleted()) return false;

            this.Role = enRole.Clerk;
            this._Permissions = Permissions;
            return true;
        }
    }
}