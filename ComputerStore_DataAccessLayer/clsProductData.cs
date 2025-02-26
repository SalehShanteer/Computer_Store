using DTOs;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ComputerStore_DataAccessLayer
{
    public class clsProductData
    {

        public static ProductDto GetProductByID(int? id)
        {  
            ProductDto product = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new ProductDto
                                {
                                    ID = id,
                                    Name = reader["Name"] as string,
                                    Description = reader["Description"] as string,
                                    Price = reader["Price"] as decimal?,
                                    QuantityInStock = reader["QuantityInStock"] as short?,
                                    CategoryID = reader["CategoryID"] as int?,
                                    SubcategoryID = reader["SubcategoryID"] as int?,
                                    BrandID = reader["BrandID"] as int?,
                                    Rating = reader["Rating"] as decimal?,
                                    ReleaseDate = reader["ReleaseDate"] as DateTime?
                                };
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
            return product;
        }

        public static ProductDto GetProductByName(string? name)
        {
            ProductDto product = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductByName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the Name parameter
                    command.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new ProductDto
                                {
                                    ID = reader["ProductID"] as int?,
                                    Name = name,
                                    Description = reader["Description"] as string,
                                    Price = reader["Price"] as decimal?,
                                    QuantityInStock = reader["QuantityInStock"] as short?,
                                    CategoryID = reader["CategoryID"] as int?,
                                    SubcategoryID = reader["SubcategoryID"] as int?,
                                    BrandID = reader["BrandID"] as int?,
                                    Rating = reader["Rating"] as decimal?,
                                    ReleaseDate = reader["ReleaseDate"] as DateTime?
                                };
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
            return product;
        }

        public static bool IsProductExistID(int? id)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsProductExistByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id.HasValue ? id : (object)DBNull.Value);
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

        public static int? AddNewProduct(ProductDto product)
        {
            int? newID = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the parameters
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@SubcategoryID", product.SubcategoryID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@BrandID", product.BrandID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate ?? (object)DBNull.Value);

                    // Add the output parameter to capture the new ID
                    SqlParameter outputIdParam = new SqlParameter("@NewID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        // Retrieve the new ID
                        newID = (int)outputIdParam.Value;
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

        public static bool UpdateProduct(ProductDto product)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", product.ID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@SubcategoryID", product.SubcategoryID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@BrandID", product.BrandID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate ?? (object)DBNull.Value);

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

        public static bool DeleteProduct(int? id)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add the ID parameter
                    command.Parameters.AddWithValue("@ID", id.HasValue ? id : (object)DBNull.Value);
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

        public static List<ProductDto> GetAllProducts()
        {
            List<ProductDto> products = new List<ProductDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProducts", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductDto product = new ProductDto
                                {
                                    ID = reader["ProductID"] as int?,
                                    Name = reader["Name"] as string,
                                    Description = reader["Description"] as string,
                                    Price = reader["Price"] as decimal?,
                                    QuantityInStock = reader["QuantityInStock"] as short?,
                                    CategoryID = reader["CategoryID"] as int?,
                                    SubcategoryID = reader["SubcategoryID"] as int?,
                                    BrandID = reader["BrandID"] as int?,
                                    Rating = reader["Rating"] as decimal?,
                                    ReleaseDate = reader["ReleaseDate"] as DateTime?
                                };
                                products.Add(product);
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
            return products;
        }


    }
}
        
