using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using DTOs;

namespace ComputerStore_DataAccessLayer
{
    public class clsUserSettingData
    {
        public static UserSettingsDto FindUserSettingByTitle(string Title)
        {
            UserSettingsDto userSettings= null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_FindUserSettingByTitle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", Title);

                    SqlParameter userIDParam = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userIDParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        userSettings = new UserSettingsDto();
                        userSettings.UserID = userIDParam.Value == DBNull.Value ? null : (int?)userIDParam.Value;
                        userSettings.Title = Title;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return userSettings;
        }

        public static bool UpdateUserSetting(UserSettingsDto userSettings)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateUserSetting", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", userSettings.Title);
                    command.Parameters.AddWithValue("@UserID", userSettings.UserID != null ? userSettings.UserID : (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isUpdated;
        }

        public static int? GetCurrentUserID()
        {
            int? id = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCurrentUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int userID))
                        {
                            id = userID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return id;
        }
    }
}
