// Class: User Data Access Layer
// Handles all database operations for Users table
// Supports filtering by status (Active, Inactive, Deleted)
// Validates unique constraints (PersonID, UserName)
// Joins with People table to include person information
// NOTE: Contains many methods due to multiple filter combinations
//       Author notes this should be code-generated to reduce repetition

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsUserDAL
    {
        // Data Transfer Object for user data
        public class clsUserDTO
        {
            public clsUserDTO() { }

            public clsPersonDAL.clsPersonDTO PersonDTO { get; set; }

            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Status { get; set; }
            public int CreatedByUserID { get; set; }
            public int Permissions { get; set; }
        }

        // Fills DTO from SqlDataReader (joins with Person data)
        private static clsUserDTO _FillUserDTO(SqlDataReader Reader)
        {
            clsUserDTO UserDTO = new clsUserDTO();

            // Fill person data first
            UserDTO.PersonDTO = clsPersonDAL._FillPersonDTO(Reader);

            UserDTO.UserID = Convert.ToInt32(Reader["UserID"]);
            UserDTO.UserName = Reader["UserName"].ToString();
            UserDTO.Password = Reader["Password"].ToString();
            UserDTO.Status = Convert.ToInt32(Reader["Status"]);

            // Handle system-created users (NULL CreatedByUserID)
            if (Reader["CreatedByUserID"] != DBNull.Value)
            {
                UserDTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
            }
            else
            {
                UserDTO.CreatedByUserID = -1;
            }

            UserDTO.Permissions = Convert.ToInt32(Reader["Permissions"]);

            return UserDTO;
        }


        // Reading: Getting all the records with filters
        public static DataTable GetAllUsers_InDB()
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                            FROM Users AS U 
                            INNER JOIN People AS P  
                            ON U.PersonID = P.PersonID ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllUsersFilteredByUserID_InDB(int UserID)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                            FROM Users AS U 
                            INNER JOIN People AS P  
                            ON U.PersonID = P.PersonID 
                            WHERE U.UserID = @UserID ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                    FROM Users AS U 
                    INNER JOIN People AS P  
                    ON U.PersonID = P.PersonID 
                    WHERE U.PersonID = @PersonID ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByUserName_InDB(string UserName)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                    FROM Users AS U 
                    INNER JOIN People AS P  
                    ON U.PersonID = P.PersonID 
                    WHERE U.UserName LIKE '' + @UserName + '%' ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByCreatedByUserID_InDB(int CreatedByUserID)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                    FROM Users AS U 
                    INNER JOIN People AS P  
                    ON U.PersonID = P.PersonID 
                    WHERE U.CreatedByUserID = @CreatedByUserID ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["CreatedByUserID"] = CreatedByUserID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }


        // Reading: Getting active/inactive/deleted records with filters
        public static DataTable GetAllUsersFilteredByStatus_InDB(int Status)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                            FROM Users AS U 
                            INNER JOIN People AS P  
                            ON U.PersonID = P.PersonID
                            AND Status = @Status; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Status"] = Status
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB (Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByStatusAndUserID_InDB(int UserID, int Status)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                            FROM Users AS U 
                            INNER JOIN People AS P  
                            ON U.PersonID = P.PersonID 
                            WHERE U.UserID = @UserID
                              AND Status = @Status; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID,
                ["Status"] = Status
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByStatusAndPersonID_InDB(int PersonID, int Status)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                             FROM Users AS U 
                             INNER JOIN People AS P  
                             ON U.PersonID = P.PersonID 
                             WHERE U.PersonID = @PersonID
                               AND Status = @Status; ";


            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID,
                ["Status"] = Status
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByStatusAndUserName_InDB(string UserName, int Status)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                             FROM Users AS U 
                             INNER JOIN People AS P  
                             ON U.PersonID = P.PersonID 
                             WHERE U.UserName LIKE '' + @UserName + '%' 
                               AND Status = @Status; ";


            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserName,
                ["Status"] = Status
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllUsersFilteredByStatusAndCreatedByUserID_InDB(int CreatedByUserID, int Status)
        {
            string Query = @"SELECT U.*, P.FirstName, P.SecondName, P.ThirdName, P.LastName
                    FROM Users AS U 
                    INNER JOIN People AS P  
                    ON U.PersonID = P.PersonID 
                    WHERE U.CreatedByUserID = @CreatedByUserID
                      AND Status = @Status; ";


            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["CreatedByUserID"] = CreatedByUserID,
                ["Status"] = Status
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }



        // Reading: Get user by UserID, PersonID, Username and Password (for login authentication)
        public static clsUserDTO GetUserByUserNamePassword_InDB(string UserName, string Password)
        {
            string Query = @"SELECT TOP 1 * FROM Users AS U 
                            INNER JOIN People AS P  
                            ON P.PersonID = U.PersonID 
                            WHERE U.UserName = @UserName
                            AND U.Password = @Password";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserName,
                ["Password"] = Password
            };

            return clsDBManager1.GetRecord_InDB<clsUserDTO>(Query, DicParameters, _FillUserDTO);
        }
        public static clsUserDTO GetUserByUserID_InDB(int UserID)
        {
            string Query = @"SELECT TOP 1 * FROM Users AS U 
                            INNER JOIN People AS P  
                            ON P.PersonID = U.PersonID 
                            WHERE U.UserID = @UserID";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID
            };

            return clsDBManager1.GetRecord_InDB<clsUserDTO>(Query, DicParameters, _FillUserDTO);
        }
        public static clsUserDTO GetUserByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT TOP 1 * FROM Users AS U 
                            INNER JOIN People AS P  
                            ON P.PersonID = U.PersonID 
                            WHERE U.PersonID = @PersonID";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetRecord_InDB<clsUserDTO>(Query, DicParameters, _FillUserDTO);
        }


        // COUNTING: Get total number of all user records and for active/inactive/deleted users
        public static int GetAllSystemRecordsNumber_InDB()
        {
            string Query = "SELECT COUNT(*) FROM Users ;";

            return clsDBManager1.CountRecords_InDB(Query);
        }
        public static int GetSystemRecordsNumberFilteredByStatus_InDB(int Status)
        {
            string Query = "SELECT COUNT(*) FROM Users WHERE Status = @Status; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Status"] = Status
            };

            return clsDBManager1.CountRecords_InDB(Query, DicParameters);
        }


        // Reading: Check if User already exists by UserID and PersonID
        public static bool IsUserExists_InDB(int UserID)
        {
            string Query = "SELECT TOP 1 Found = 1 FROM Users WHERE UserID = @UserID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserID"] = UserID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        public static bool IsPersonIDExists_InDB(int PersonID)
        {
            string Query = "SELECT TOP 1 Found = 1 FROM Users WHERE PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }

        // Reading: Check if username already exists to prevent duplications
        public static bool IsUserNameExists_InDB(string UserName)
        {
            string Query = "SELECT TOP 1 Found = 1 FROM Users WHERE UserName = @UserName; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserName
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Writing: Adding - Updating - Deleting Users
        public static int AddNewUser_InDB(clsUserDTO UserDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[Users] ([PersonID], [UserName], [Password], [Status], [CreatedByUserID], [Permissions])
                                                   VALUES (@PersonID, @UserName, @Password, @Status, @CreatedByUserID, @Permissions);";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = UserDTO.PersonDTO.PersonID,
                ["UserName"] = UserDTO.UserName,
                ["Password"] = UserDTO.Password,
                ["Status"] = UserDTO.Status,
                ["CreatedByUserID"] = UserDTO.CreatedByUserID,
                ["Permissions"] = UserDTO.Permissions
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdateUser_InDB(clsUserDTO UserDTO)
        {
            string NonQuery = @"UPDATE [dbo].[Users] SET
                                [UserName] = @UserName,
                                [Password] = @Password,
                                [Status] = @Status,
                                [Permissions] = @Permissions

                                 WHERE [UserID] = @UserID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["UserName"] = UserDTO.UserName,
                ["Password"] = UserDTO.Password,
                ["Status"] = UserDTO.Status,
                ["Permissions"] = UserDTO.Permissions,

                ["UserID"] = UserDTO.UserID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
        public static bool DeleteUser_InDB(int UserID)
        {
            string NonQuery = @"DELETE FROM [dbo].[Users] WHERE [UserID] = @UserID; ";

            return clsDBManager1.DeleteRecord_InDB(NonQuery, "UserID", UserID);
        }
    }
}