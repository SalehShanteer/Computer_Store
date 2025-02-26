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
    public class clsBrandData
    {
        
        public static BrandDto GetBrandByID(int? id)
        {
            BrandDto brand = null;

            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetBrandByID", connetion))
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
                                brand = new BrandDto();
                                brand.ID = id;
                                brand.Name = reader["Name"] as string;
                                brand.ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"] as string : null;
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
            return brand;
        }

        public static int? AddNewBrand(BrandDto brand)
        {
            int? newID = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewBrand", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", brand.Name);
                    command.Parameters.AddWithValue("@ImagePath", brand.ImagePath ?? (object)DBNull.Value);
                    command.Parameters.Add("@NewID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newID = (int)command.Parameters["@NewID"].Value;
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

        public static bool UpdateBrand(BrandDto brand)
        {
            bool IsUpdated = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateBrand", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", brand.ID);
                    command.Parameters.AddWithValue("@Name", brand.Name);
                    command.Parameters.AddWithValue("@ImagePath", brand.ImagePath ?? (object)DBNull.Value);
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

        public static bool IsBrandExist(int? id)
        {
            bool IsExists = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsBrandExist", connection))
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

        public static bool DeleteBrand(int? id)
        {
            bool IsDeleted = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteBrand", connection))
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
                        System.Diagnostics.EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return IsDeleted;
        }

        public static List<BrandDto> GetAllBrands()
        {
            List<BrandDto> brands = new List<BrandDto>();

            using (SqlConnection connetion = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllBrands", connetion))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connetion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BrandDto brand = new BrandDto();
                                brand.ID = reader["BrandID"] as int?;
                                brand.Name = reader["Name"] as string;
                                brand.ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"] as string : null;
                                brands.Add(brand);
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
            return brands;
        }

    }
}
