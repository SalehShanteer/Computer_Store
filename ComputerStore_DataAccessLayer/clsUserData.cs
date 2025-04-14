using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using DTOs;

namespace ComputerStore_DataAccessLayer
{
    public class clsUserData
    {

        public static UserDto GetUserByID(int? id)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id.HasValue ? id : (object)DBNull.Value);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserDto();
                                user.ID = id;
                                user.FirstName = reader["FirstName"] as string;
                                user.LastName = reader["LastName"] as string;
                                user.Email = reader["Email"] as string;
                                user.Phone = reader["Phone"] as string;
                                user.Password = reader["Password"] as string;
                                user.Role = (UserDto.enRole)Convert.ToByte(reader["Role"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return user;
        }

        public static UserDto GetUserByEmail(string Email)
        {
            UserDto user = null;

            using (SqlConnection connection = new (DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new ("SP_GetUserByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserDto();
                                user.Email = Email;
                                user.ID = Convert.ToInt32(reader["UserID"]);
                                user.FirstName = reader["FirstName"] as string;
                                user.LastName = reader["LastName"] as string;
                                user.Phone = reader["Phone"] as string;
                                user.Password = reader["Password"] as string;
                                user.Role = (UserDto.enRole)Convert.ToByte(reader["Role"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return user;
        }

        public static bool IsUserExistByEmail(string Email)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsUserExistByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameter
                    command.Parameters.AddWithValue("@Email", Email);

                    // Add a parameter to capture the return value
                    SqlParameter returnValue = new SqlParameter("@ReturnVal", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        int result = (int)returnValue.Value;

                        IsFound = result == 1;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsFound;
        }

        public static bool IsUserExistByID(int? id)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsUserExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add the parameter
                    command.Parameters.AddWithValue("@ID", id.HasValue ? id : (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        IsFound = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsFound;
        }

        public static int? AddNewUser(UserDto user)
        {
            int? newUserID = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@Password", clsUtility.ComputeHash(user.Password));
                    command.Parameters.AddWithValue("@Role", user.Role);

                    // Add the output parameter
                    SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newUserID = (int)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return newUserID;
        }

        public static bool UpdateUser(UserDto user)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@UserID", user.ID);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Phone", user.Phone);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static bool ChangeUserPassword(string Email, string NewPassword)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_ChangeUserPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NewPassword", clsUtility.ComputeHash(NewPassword));

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return rowsAffected > 0;
        }


    }
}
