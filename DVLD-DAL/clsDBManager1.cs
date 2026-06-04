using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    internal static class clsDBManager1
    {
        private static string ConnectionString;

        private static void _ReplaceParameter(SqlCommand Command, string Parameter, object Value)
        {
            if (Value != null && Value != default(object)) 
                Command.Parameters.AddWithValue($"@{Parameter}", Value);

            else
                Command.Parameters.AddWithValue($"@{Parameter}", DBNull.Value);
        }
        private static void _ReplaceParameters(SqlCommand Command, Dictionary<string, object> DicParameters)
        {
            foreach (string Key in DicParameters.Keys)
            {
                _ReplaceParameter(Command, Key, DicParameters[Key]);
            }
        }

        static clsDBManager1()
        {
            ConnectionString = clsSettings.ConnectionString;
        }

        public static DataTable GetAllRecords_InDB(string Query)
        {
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.HasRows) DT.Load(Reader);
                    }
                }
            }

            catch (Exception ex) 
            {
                throw;
            }

            return DT;
        }
        public static DataTable GetAllRecordsFilteredBy_InDB(string Query, Dictionary<string, object> DicParameters)
        {
            DataTable DT = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);             

                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.HasRows) DT.Load(Reader);
                    }
                }
            }

            catch (Exception ex) 
            {
                throw;
            }

            return DT;
        }

        public static int CountRecords_InDB(string Query)
        {
            int Counter = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out Counter))
                        {
                            //Succ 
                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return Counter;
        }
        public static int CountRecords_InDB(string Query, Dictionary<string, object> DicParameters)
        {
            int Counter = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out Counter))
                        { 
                            //Succ 
                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return Counter;
        }

        // The query should contain IsExist = 1 !
        public static bool IsExist_InDB(string Query, Dictionary<string, object> DicParameters)
        {
            bool IsExist = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(),out int ResultNumber))
                        {
                            IsExist = (ResultNumber == 1);
                        }
                    }
                }
            }
            catch(Exception ex) { throw; }

            return IsExist;
        }

        public static T GetColumnValueOfRecord_InDB<T>(string Query, Dictionary<string, object> DicParameters)
        {
            T ColumnValue = default(T);

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                        {
                            ColumnValue = (T)Result;
                        }
                    }
                }
            }
            
            catch(Exception ex) { throw; }

            return ColumnValue;
        }
        public static T GetRecord_InDB<T>(string Query, Dictionary<string, object> DicParameters, Func<SqlDataReader, T> FillDTO)
        {
            T DTOInstance = default(T);

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        
                        if (Reader.Read())
                            DTOInstance = FillDTO(Reader);
                    }
                }
            }
            catch(Exception ex) { throw; }

            return DTOInstance;
        }


        public static int AddNewRecord_InDB(string NonQuery, Dictionary<string, object> DicParameters)
        {
            int RowID = -1;
            NonQuery = NonQuery + "SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out RowID))
                        {
                            //Succ 
                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return RowID;
        }
        public static bool UpdateRecord_InDB(string NonQuery, Dictionary<string, object> DicParameters)
        {
            bool IsUpdatedSucc = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        _ReplaceParameters(Command, DicParameters);

                        Connection.Open();
                        int RowsAffected = Command.ExecuteNonQuery();

                        if (RowsAffected > 0) 
                            IsUpdatedSucc = true;
                    }
                }
            }
            catch (Exception ex) { throw; }

            return IsUpdatedSucc;
        }
        public static bool DeleteRecord_InDB(string NonQuery, string IDParameter, int Value)
        {
            bool IsDeletedSucc = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand Command = new SqlCommand(NonQuery, Connection))
                    {
                        _ReplaceParameter(Command, IDParameter, Value);

                        Connection.Open();
                        int RowsAffected = Command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                            IsDeletedSucc = true;
                    }
                }
            }
            catch (Exception ex) { throw; }

            return IsDeletedSucc;
        }
    }
}
