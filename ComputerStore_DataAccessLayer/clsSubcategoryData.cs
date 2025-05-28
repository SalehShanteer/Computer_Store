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
    public class clsSubcategoryData
    {
        public static SubcategoryDto GetSubcategoryByID(int? id)
        {
            SubcategoryDto subcategory = null;
            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetSubcategoryByID", connetion))
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
                                subcategory = new SubcategoryDto();
                                subcategory.ID = id;
                                subcategory.Name = reader["Name"] as string;
                                subcategory.CategoryID = reader["CategoryID"] as int?;
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
            return subcategory;
        }

        public static int? AddNewSubcategory(SubcategoryDto subcategory)
        {
            int? newID = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewSubcategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", subcategory.Name);
                    command.Parameters.AddWithValue("@CategoryID", subcategory.CategoryID);
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

        public static bool UpdateSubcategory(SubcategoryDto subcategory)
        {
            bool IsUpdated = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateSubcategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", subcategory.ID);
                    command.Parameters.AddWithValue("@Name", subcategory.Name);
                    command.Parameters.AddWithValue("@CategoryID", subcategory.CategoryID);
                    try
                    {
                        connection.Open();
                        IsUpdated = command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsUpdated;
        }

        public static bool IsSubcategoryExist(int? id)
        {
            bool IsExists = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsSubcategoryExist", connection))
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
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsExists;
        }

        public static bool IsSubcategoryNameExist(string name, int? categoryID)
        {
            bool IsExists = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsSubcategoryNameExist", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    try
                    {
                        connection.Open();
                        IsExists = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsExists;

        }

        public static bool IsSubcategoryBelongsToCategory(int? subcategoryID, int? categoryID)
        {
            bool IsBelongsToCategory = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsSubcategoryBelongsToCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@SubcategoryID", subcategoryID);
                    try
                    {
                        connection.Open();
                        IsBelongsToCategory = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsBelongsToCategory;
        }

        public static bool DeleteSubcategory(int? id)
        {
            bool IsDeleted = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteSubcategory", connection))
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

        public static List<SubcategoryDto> GetAllSubcategories()
        {
            List<SubcategoryDto> subcategories = new();
            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllSubcategories", connetion))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connetion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SubcategoryDto subcategory = new();
                                subcategory.ID = reader["SubcategoryID"] as int?;
                                subcategory.Name = reader["Name"] as string;
                                subcategory.CategoryID = reader["CategoryID"] as int?;
                                subcategories.Add(subcategory);
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
            return subcategories;
        }

        public static List<SubcategoryDto> GetSubcategoriesByCategoryID(int? categoryID)
        {
            List<SubcategoryDto> subcategories = new();
            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetSubcategoriesByCategoryID", connetion))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    try
                    {
                        connetion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SubcategoryDto subcategory = new();
                                subcategory.ID = reader["SubcategoryID"] as int?;
                                subcategory.Name = reader["Name"] as string;
                                subcategory.CategoryID = reader["CategoryID"] as int?;
                                subcategories.Add(subcategory);
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
            return subcategories;
        }
    }
}
