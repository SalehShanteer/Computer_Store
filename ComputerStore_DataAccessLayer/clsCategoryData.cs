using DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore_DataAccessLayer
{
    public class clsCategoryData
    {
        public static CategoryDto GetCategoryByID(int? id)
        {
            CategoryDto category = null;

            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCategoryByID", connetion))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id.HasValue ? id : (object)DBNull.Value);
                    try
                    {
                        connetion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                category = new CategoryDto();
                                category.ID = id;
                                category.Name = reader["Name"] as string;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        System.Diagnostics.EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return category;
        }

        public static int? AddNewCategory(CategoryDto category)
        {
            int? newID = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.Add("@NewID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newID = (int?)command.Parameters["@NewID"].Value;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return newID;
        }

        public static bool UpdateCategory(CategoryDto category)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", category.ID);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return success;
        }

        public static bool IsCategoryExist(int? id)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsCategoryExist", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        connection.Open();
                        IsExists = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        System.Diagnostics.EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return IsExists;
        }

        public static bool DeleteCategory(int? id)
        {
            bool IsDeleted = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        connection.Open();
                        IsDeleted = command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsDeleted;
        }

        public static List<CategoryDto> GetAllCategories()
        {
            List<CategoryDto> categories = new List<CategoryDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllCategories", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CategoryDto category = new CategoryDto();
                                category.ID = reader["CategoryID"] as int?;
                                category.Name = reader["Name"] as string;
                                categories.Add(category);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        System.Diagnostics.EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return categories;
        }

    }
}
