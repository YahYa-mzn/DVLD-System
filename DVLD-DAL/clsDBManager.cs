// Class: Database Manager (DAL Infrastructure)
// Central database operations handler for all DAL classes
// Provides generic methods for CRUD operations with SQL Server
// Uses generics to work with any DTO type
// Handles parameter replacement and SqlCommand execution
// All DAL classes use these methods instead of duplicating database code

using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    internal static class clsDBManager
    {
        // Replaces SQL parameter with value or DBNull for null values
        private static void ReplaceParameter<T>(SqlCommand Command, string Parameter, T Value)
        {
            if (Value != null)
            {
                Command.Parameters.AddWithValue("@" + Parameter, Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@" + Parameter, DBNull.Value);
            }
        }


        // READING OPERATIONS

        // Gets all rows from query without conditions
        public static DataTable GetAllRows_InDB(string Query)
        {
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();

                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            DT.Load(Reader);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return DT;
        }

        // Gets rows with single WHERE condition
        public static DataTable GetAllRowsWithCondition_InDB<T>(string Query, string Parameter = null, T Value = default(T))
        {
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();

                        if (!string.IsNullOrEmpty(Parameter))
                        {
                            ReplaceParameter<T>(Command, Parameter, Value);
                        }

                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            DT.Load(Reader);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return DT;
        }

        // Gets rows with two WHERE conditions
        public static DataTable GetAllRowsWithConditions_InDB<T1, T2>(string Query, string Parameter1 = null, T1 Value1 = default(T1),
                                                                        string Parameter2 = null, T2 Value2 = default(T2))
        {
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();

                        if (!string.IsNullOrEmpty(Parameter1))
                            ReplaceParameter<T1>(Command, Parameter1, Value1);

                        if (!string.IsNullOrEmpty(Parameter2))
                            ReplaceParameter<T2>(Command, Parameter2, Value2);

                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            DT.Load(Reader);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return DT;


        }

        // Gets single row by column value, fills DTO using provided function
        public static T1 GetRowByColumn_InDB<T1, T2>(string Query, string ColumnName, T2 Value, Func<SqlDataReader, T1> FillDTO)
        {
            T1 Row = default(T1);

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        ReplaceParameter(Command, ColumnName, Value);
                        Connection.Open();

                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            Row = FillDTO(Reader);
                        }

                        Reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Row;
        }

        // Gets single row by two column values, fills DTO using provided function
        public static T1 GetRowByTwoColumns_InDB<T1, T2, T3>(string Query, string ColumnName1, T2 Value1,string ColumnName2, T3 Value2, Func<SqlDataReader, T1> FillDTO)
        {
            T1 Row = default(T1);

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        // Set parameters
                        ReplaceParameter(Command, ColumnName1, Value1);
                        ReplaceParameter(Command, ColumnName2, Value2);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                Row = FillDTO(Reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw; // You could also log ex.Message if you want
            }

            return Row;
        }

        // Checks if row exists by column value (query should select 1 if exists)
        public static bool IsRowExistsByColumn_InDB<T>(string Query, string ColumnName, T Value)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        ReplaceParameter<T>(Command, ColumnName, Value);
                        Connection.Open();

                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int Num))
                        {
                            if (Num == 1)
                            {
                                IsExists = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return IsExists;
        }

        // Checks if row exists by two column values (query should select 1 if exists)
        public static bool IsRowExistsByTwoColumns_InDB<T1, T2>(string Query, string ColumnName1, T1 Value1, string ColumnName2, T2 Value2)
        {
            bool IsExists = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        // Set parameters
                        ReplaceParameter(Command, ColumnName1, Value1);
                        ReplaceParameter(Command, ColumnName2, Value2);

                        Connection.Open();

                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int Num))
                        {
                            if (Num == 1)
                            {
                                IsExists = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return IsExists;
        }

        // Counts records with optional WHERE condition
        public static int CountRecords_InDB<T>(string Query, string Parameter = null, T Value = default(T))
        {
            int Counter = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        if (!string.IsNullOrEmpty(Parameter))
                            ReplaceParameter<T>(Command, Parameter, Value);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out Counter))
                        {
                            // Success
                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return Counter;
        }

        // Counts records with two parameters !
        public static int CountRecords_InDB<T1, T2>(string query,string param1Name, T1 value1,string param2Name, T2 value2)
        {
            int counter = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(param1Name, value1);
                    command.Parameters.AddWithValue(param2Name, value2);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out counter))
                    {
                        // parsed successfully
                    }
                }
            }
            catch
            {
                throw;
            }

            return counter;
        }
        // Counts records
        public static int CountRecords_InDB(string Query)
        {
            int Counter = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out Counter))
                        {
                            // Success
                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return Counter;
        }

        // Gets single column value with optional parameter
        public static T1 GetColumnRow_InDB<T1, T2>(string Query, string Parameter = null, T2 Value = default(T2))
        {
            T1 ColumnRow = default(T1);

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        if (!string.IsNullOrEmpty(Parameter)) ReplaceParameter(Command, Parameter, Value);

                        Connection.Open();

                        object Result = Command.ExecuteScalar();
                        if (Result != null)
                        {
                            ColumnRow = (T1)Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ColumnRow;
        }

        // WRITING OPERATIONS

        // Adds new row and returns generated ID
        public static int AddNewRow_InDB<T>(string NonQuery, Action<SqlCommand, T> ReplaceAllParameters, T DTO)
        {
            int RowID = -1;
            NonQuery = NonQuery + "SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        ReplaceAllParameters?.Invoke(Command, DTO);
                        Connection.Open();

                        object ResultID = Command.ExecuteScalar();

                        if (ResultID != null && int.TryParse(ResultID.ToString(), out RowID))
                        {
                            // Success
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw;
            }

            return RowID;
        }

        // Updates existing row, returns true if exactly 1 row updated
        public static bool UpdateRow_InDB<T>(string NonQuery, Action<SqlCommand, T> ReplaceAllParameters, T DTO)
        {
            bool IsUpdatedSucc = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        ReplaceAllParameters?.Invoke(Command, DTO);
                        Connection.Open();

                        int UpdatedRows = Command.ExecuteNonQuery();

                        if (UpdatedRows == 1)
                        {
                            IsUpdatedSucc = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                throw;
            }

            return IsUpdatedSucc;
        }

        // Deletes row by parameter, returns true if exactly 1 row deleted
        public static bool DeleteRow_InDB<T>(string NonQuery, string Parameter, T Value)
        {
            bool IsDeletedSucc = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        ReplaceParameter(Command, Parameter, Value);
                        Connection.Open();

                        int DeletedRows = Command.ExecuteNonQuery();

                        if (DeletedRows == 1)
                        {
                            IsDeletedSucc = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw;
            }

            return IsDeletedSucc;
        }
    }
}