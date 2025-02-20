using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using DTOs;

namespace ComputerStore_DataAccessLayer
{
    public static class clsLoginRecordData
    {
      
        public static LoginRecordDto GetLoginRecordByID(int Id)
        {
            LoginRecordDto loginRecord = new LoginRecordDto();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLoginRecordByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID", Id);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                loginRecord = new LoginRecordDto();
                                loginRecord.ID = Id;
                                loginRecord.UserID = Convert.ToInt32(reader["UserID"]);
                                loginRecord.LoginTime = Convert.ToDateTime(reader["LoginTime"]);
                                loginRecord.LoginStatus = Convert.ToBoolean(reader["LoginStatus"]);
                                loginRecord.FailureReason = reader["FailureReason"] != DBNull.Value ? reader["FailureReason"] as string : null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return loginRecord;
        }

        public static int? AddNewLoginRecord(int? UserID, bool LoginStatus, string? FailureReason)
        {
            int? ID = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewLoginRecord", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@LoginStatus", LoginStatus);
                    command.Parameters.AddWithValue("@FailureReason", FailureReason != string.Empty ? FailureReason : (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                        {
                            ID = NewID;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return ID;
        }

        public static DataTable GetAllLoginRecords()
        {
            DataTable dt = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLoginRecordsList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt = new DataTable();
                            dt.Load(reader); // Fill dataTable with all rows
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return dt;
        }

        public static int? GetLoginRecordsCount()
        {
            int? count = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLoginRecordsCount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int recordCount))
                        {
                            count = recordCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return count;
        }

    }
}
