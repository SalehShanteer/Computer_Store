using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using DTOs;
using System.Data;
using System.Diagnostics;


namespace ComputerStore_DataAccessLayer
{
    public class clsProductImageData
    {

        public static ProductImageDto GetProductImageByID(int? id)
        {
            ProductImageDto productImage = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductImageByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID", id ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productImage = new ProductImageDto
                                {
                                    ID = reader["ProductImageID"] as int?,
                                    ImagePath = reader["ImagePath"] as string,
                                    ProductID = reader["ProductID"] as int?,
                                    ImageOrder = reader["ImageOrder"] as byte?
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return productImage;
        }

        public static ProductImageDto GetFirstProductImageByProductID(int? ProductId)
        {
            ProductImageDto productImage = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetFirstProductImageByProductID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductID", ProductId ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productImage = new ProductImageDto
                                {
                                    ID = reader["ProductImageID"] as int?,
                                    ImagePath = reader["ImagePath"] as string,
                                    ProductID = reader["ProductID"] as int?,
                                    ImageOrder = reader["ImageOrder"] as byte?
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return productImage;
        }

        public static ProductImageDto GetProductImageByImagePath(string? imagePath)
        {
            ProductImageDto productImage = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductImageByImagePath"))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productImage = new ProductImageDto
                                {
                                    ID = reader["ProductImageID"] as int?,
                                    ImagePath = reader["ImagePath"] as string,
                                    ProductID = reader["ProductID"] as int?,
                                    ImageOrder = reader["ImageOrder"] as byte?
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return productImage;
        }

        public static bool IsProductImageExistBy(int? id)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsProductImageExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        IsExist = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsExist;
        }

        public static bool IsProductImageExistImagePath(string? imagePath)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsProductImageExistByImagePath", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", imagePath ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        IsExist = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsExist;
        }

        public static int? AddNewProductImage(ProductImageDto productImage)
        {
            int? newID = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewProductImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ImagePath", productImage.ImagePath);
                    command.Parameters.AddWithValue("@ProductID", productImage.ProductID);
                    command.Parameters.AddWithValue("@ImageOrder", productImage.ImageOrder);

                    // Add the output parameter to capture the new ID
                    SqlParameter outputIdParam = new SqlParameter("@NewID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newID = (int)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return newID;
        }

        public static bool UpdateProductImage(ProductImageDto productImage)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateProductImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductImageID", productImage.ID);
                    command.Parameters.AddWithValue("@ImagePath", productImage.ImagePath);
                    command.Parameters.AddWithValue("@ProductID", productImage.ProductID);
                    command.Parameters.AddWithValue("@ImageOrder", productImage.ImageOrder);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isUpdated;
        }

        public static bool DeleteProductImageByID(int? id)
        {
            bool isDeleted = false;

            if (id is null) return isDeleted;

            return DeleteProductImageByImagePath(GetProductImageByID(id).ImagePath);

        }

        public static bool DeleteProductImageByImagePath(string? imagePath)
        {
            bool isDeleted = false;

            if (string.IsNullOrEmpty(imagePath)) return isDeleted;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteProductImageByImagePath", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ImagePath", imagePath);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isDeleted = rowsAffected > 0;

                        File.Delete(imagePath);
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isDeleted;
        }

        public static bool DeleteAllProductImagesRelated(int? productID, bool deleteFile = false)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteAllProductImagesRelated", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productID);

                    try
                    {
                        connection.Open();
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                isDeleted = true;

                                if (deleteFile)
                                {
                                    string imagePath = reader.GetString(reader.GetOrdinal("ImagePath"));
                                    File.Delete(imagePath);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isDeleted;
        }

        public static List<ProductImageDto> GetAllProductImagesRelated(int productID)
        {
            List<ProductImageDto> productImages = new List<ProductImageDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProductImagesRelated", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductImageDto productImage = new ProductImageDto
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("ProductImageID")),
                                    ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),
                                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                    ImageOrder = reader.GetByte(reader.GetOrdinal("ImageOrder"))
                                };
                                productImages.Add(productImage);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return productImages;
        }

    }
}
