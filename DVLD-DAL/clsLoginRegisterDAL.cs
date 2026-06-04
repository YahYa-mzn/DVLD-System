// Class: Login Register Data Access Layer
// Tracks user login and logout sessions in database
// Records when users log in and log out
// Provides filtering by login/logout time and currently logged in users
// Used for login history display and auditing

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace DVLD_DAL
{
    public class clsLoginRegisterDAL
    {
        // Data Transfer Object for login register data
        public class clsLoginRegisterDTO
        {
            public int LoginID { get; set; }
            public int UserID { get; set; }
            public DateTime LoginTime { get; set; }
            public DateTime LogoutTime { get; set; }
        }

        // Gets first login time in system (for date range validation)
        public static DateTime GetFirstLoginTime_InDB()
        {
            string Query = @"SELECT TOP 1 LoginTime
                             FROM LoginRegister ORDER BY LoginTime ASC";

            return clsDBManager1.GetColumnValueOfRecord_InDB<DateTime>(Query, new Dictionary<string, object>());
        }
        

        public static DataTable GetLoginRegister_InDB()
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }

        // Gets login records filtered by login time range
        public static DataTable GetLoginRegisterFilteredByLoginTime_InDB(DateTime StartDate, DateTime EndDate)
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID
                             WHERE L.LoginTime >= @StartDate
                             AND L.LoginTime <= @EndDate
                             AND L.LogoutTime IS NOT NULL; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["StartDate"] = StartDate,
                ["EndDate"] = EndDate
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Gets login records filtered by logout time range
        public static DataTable GetLoginRegisterFilteredByLogoutTime_InDB(DateTime StartDate, DateTime EndDate)
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID
                             WHERE L.LogoutTime >= @StartDate 
                             AND L.LogoutTime <= @EndDate
                             AND L.LogoutTime IS NOT NULL; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["StartDate"] = StartDate,
                ["EndDate"] = EndDate
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Gets login records filtered by UserID
        public static DataTable GetLoginRegisterFilteredByUserID_InDB(int UserID)
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID
                             WHERE L.UserID = @UserID 
                             AND L.LogoutTime IS NOT NULL; "
            ;

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Gets login records filtered by UserName
        public static DataTable GetLoginRegisterFilteredByUserName_InDB(string UserName)
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID
                             WHERE U.UserName LIKE '' + @UserName + '%'
                             AND L.LogoutTime IS NOT NULL; "
            ;

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Gets currently logged in users (LogoutTime is NULL)
        public static DataTable GetLoginRegisterFilteredByLogoutTimeIsNull_InDB()
        {
            string Query = @"SELECT L.*, U.UserName 
                             FROM LoginRegister AS L
                             INNER JOIN Users AS U
                             ON U.UserID = L.UserID
                             WHERE L.LogoutTime IS NULL; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }

        public static int GetAllSystemRecordsNumber()
        {
            string Query = @"SELECT COUNT(*) FROM LoginRegister; ";

            return clsDBManager1.CountRecords_InDB(Query);
        }


        // Adds new login record (called when user logs in)
        public static int AddNewLogin_InDB(clsLoginRegisterDTO LoginRegisterDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[LoginRegister]
                                ([UserID],[LoginTime],[LogoutTime])
                                VALUES (@UserID, @LoginTime, @LogoutTime);";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = LoginRegisterDTO.UserID,
                ["LoginTime"] = LoginRegisterDTO.LoginTime,
                ["LogoutTime"] = DBNull.Value
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
      
        // Updates logout time for active session (called when user logs out)
        public static bool UpdateLogoutTime_InDB(int UserID, DateTime LogoutTime)
        {
            string NonQuery = @"UPDATE [dbo].[LoginRegister] 
                                SET [LogoutTime] = @LogoutTime
                                WHERE [UserID] = @UserID AND [LogoutTime] IS NULL; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID,
                ["LogoutTime"] = LogoutTime
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);   
        }
    }
}