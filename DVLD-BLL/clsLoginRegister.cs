// Class: Login Register Business Logic
// Tracks user login and logout sessions
// Creates record on login, updates logout time on sign out
// Provides login history filtering by date ranges
// Static properties track first login date for date range validation

using System;
using System.Data;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsLoginRegister
    {
        enum enMode
        {
            NullOrEmpty = 0,
            AddNew = 1,
            UpdateLogoutTime = 2
        }

        // Filter options for login history
        public enum enFilterColumn
        {
            None = 0,
            UserID = 1,
            UserName = 2,
            LoginTime = 3,
            LogoutTime = 4,
            LoggedInUsers = 5  // Users who haven't logged out yet
        }


        public int LoginID { get; private set; }
        public int UserID { get; private set; }
        public DateTime LoginTime { get; private set; }
        public DateTime LogoutTime { get; private set; }

        enMode _Mode { set; get; } = enMode.NullOrEmpty;

        // Date range boundaries for filtering (first login ever to now)
        public static DateTime LogsStartDate { get; private set; } = clsLoginRegisterDAL.GetFirstLoginTime_InDB().Date;
        public static DateTime LogsEndDate { get; private set; } = DateTime.Today;


        // Converts to DTO for DAL operations
        private clsLoginRegisterDAL.clsLoginRegisterDTO _Convert_clsLoginRegister_To_clsLoginRegisterDTO()
        {
            clsLoginRegisterDAL.clsLoginRegisterDTO LoginRegisterDTO = new clsLoginRegisterDAL.clsLoginRegisterDTO();

            LoginRegisterDTO.UserID = this.UserID;
            LoginRegisterDTO.LoginTime = this.LoginTime;
            LoginRegisterDTO.LogoutTime = this.LogoutTime;

            return LoginRegisterDTO;
        }

        // Resets object to empty state
        private void _EmptyObject()
        {
            this.LoginID = -1;
            this.UserID = -1;
            this.LoginTime = default(DateTime);
            this.LogoutTime = default(DateTime);
            this._Mode = enMode.NullOrEmpty;
        }

        // Creates new login record
        private bool _AddNew()
        {
            this.LoginID = clsLoginRegisterDAL.AddNewLogin_InDB(_Convert_clsLoginRegister_To_clsLoginRegisterDTO());

            return this.LoginID != -1;
        }

        // Updates logout time and empties object (session ended)
        private bool _UpdateLogoutTime()
        {
            if (clsLoginRegisterDAL.UpdateLogoutTime_InDB(this.UserID, this.LogoutTime))
            {
                this._EmptyObject();
                return true;
            }

            return false;
        }


        clsLoginRegister() { }
        clsLoginRegister(int LoginID, int UserID, DateTime LoginTime, DateTime LogoutTime, enMode Mode = enMode.NullOrEmpty)
        {
            this.LoginID = LoginID;
            this.UserID = UserID;
            this.LoginTime = LoginTime;
            this.LogoutTime = LogoutTime;
            this._Mode = Mode;
        }

        // Factory method for creating new login session
        public static clsLoginRegister GetAddNewLoginRegisterObject(int UserID)
        {
            if (!clsUser.IsUserExists(UserID)) return null;

            return new clsLoginRegister(-1, UserID, DateTime.Now, default(DateTime), enMode.AddNew);
        }

        // Sets logout time (called from clsGlobal.SignOut)
        public void SetLogoutTime(DateTime LogoutTime)
        {
            // Logout must be between login time and now
            if (!clsValidation.IsDateBetween(LogoutTime, this.LoginTime, DateTime.Now))
                return;

            this.LogoutTime = LogoutTime;
        }

        // Saves new login or updates logout time
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this._Mode = enMode.UpdateLogoutTime;
                        return true;
                    }
                    return false;

                case enMode.UpdateLogoutTime:
                    return _UpdateLogoutTime();

                default:
                    return false;
            }
        }


        // Gets total number of login records
        public static int GetSystemRecordsNumber()
        {
            return clsLoginRegisterDAL.GetAllSystemRecordsNumber();
        }

        // Gets login history with optional filtering
        public static DataTable GetLoginRegisterList(enFilterColumn FilterColumn, DateTime StartDate, DateTime EndDate)
        {
            // Validate date range, use defaults if invalid
            if (!clsValidation.IsDateBetween(StartDate, LogsStartDate, LogsEndDate))
                StartDate = LogsStartDate;
            if (!clsValidation.IsDateBetween(EndDate, LogsStartDate, LogsEndDate))
                EndDate = LogsEndDate;

            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsLoginRegisterDAL.GetLoginRegister_InDB();

                

                case enFilterColumn.LoginTime:
                    return clsLoginRegisterDAL.GetLoginRegisterFilteredByLoginTime_InDB(StartDate, EndDate);

                case enFilterColumn.LogoutTime:
                    return clsLoginRegisterDAL.GetLoginRegisterFilteredByLogoutTime_InDB(StartDate, EndDate);

                case enFilterColumn.LoggedInUsers:
                    return clsLoginRegisterDAL.GetLoginRegisterFilteredByLogoutTimeIsNull_InDB();

                default:
                    return clsLoginRegisterDAL.GetLoginRegister_InDB();
            }
        }

        public static DataTable GetLoginRegisterList(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsLoginRegisterDAL.GetLoginRegister_InDB();

                case enFilterColumn.UserID:
                    return (clsValidation.IsOnlyDigits(StrValue)) 
                           ? clsLoginRegisterDAL.GetLoginRegisterFilteredByUserID_InDB(Convert.ToInt32(StrValue))
                           : clsLoginRegisterDAL.GetLoginRegister_InDB();

                case enFilterColumn.UserName:
                    return (!string.IsNullOrEmpty(StrValue)) 
                           ? clsLoginRegisterDAL.GetLoginRegisterFilteredByUserName_InDB(StrValue)
                           : clsLoginRegisterDAL.GetLoginRegister_InDB(); 

                default:
                    return clsLoginRegisterDAL.GetLoginRegister_InDB();
            }
        }
    }
}