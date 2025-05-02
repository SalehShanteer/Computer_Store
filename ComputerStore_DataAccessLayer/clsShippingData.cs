using DTOs;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ComputerStore_DataAccessLayer
{
    public class clsShippingData
    {
        public static ShippingDto GetShippingByID(int? shippingID)
        {
            ShippingDto shipping = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetShippingByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ShippingID", shippingID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                shipping = new ShippingDto
                                {
                                    ID = shippingID,
                                    OrderID = reader["OrderID"] as int?,
                                    CarrierName = reader["CarrierName"] as string,
                                    TrackingNumber = reader["TrackingNumber"] as string,
                                    ShippingCost = reader["ShippingCost"] as decimal?,
                                    ShippingAddress = reader["ShippingAddress"] as string,
                                    EstimatedDeliveryDate = reader["EstimatedDeliveryDate"] as DateTime?,
                                    ActualDeliveryDate = reader["ActualDeliveryDate"] as DateTime?,
                                    Status = reader["Status"] as byte?
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
            return shipping;
        }

        public static ShippingDto GetShippingByOrderID(int? orderID)
        {
            ShippingDto shipping = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetShippingByOrderID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                shipping = new ShippingDto
                                {
                                    ID = reader["ShippingID"] as int?,
                                    OrderID = orderID,
                                    CarrierName = reader["CarrierName"] as string,
                                    TrackingNumber = reader["TrackingNumber"] as string,
                                    ShippingCost = reader["ShippingCost"] as decimal?,
                                    ShippingAddress = reader["ShippingAddress"] as string,
                                    EstimatedDeliveryDate = reader["EstimatedDeliveryDate"] as DateTime?,
                                    ActualDeliveryDate = reader["ActualDeliveryDate"] as DateTime?,
                                    Status = reader["Status"] as byte?
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
            return shipping;
        }

        public static bool IsShippingExistID(int? shippingID)
        {
            bool isExist = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsShippingExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ShippingID", shippingID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        isExist = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return isExist;
        }

        public static int? AddNewShipping(ShippingDto shipping)
        {
            int? newID = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewShipping", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", shipping.OrderID);
                    command.Parameters.AddWithValue("@CarrierName", shipping.CarrierName);
                    command.Parameters.AddWithValue("@ShippingCost", shipping.ShippingCost);
                    command.Parameters.AddWithValue("@ShippingAddress", shipping.ShippingAddress);
                    command.Parameters.AddWithValue("@EstimatedDeliveryDate", shipping.EstimatedDeliveryDate);
                    command.Parameters.AddWithValue("@ActualDeliveryDate", shipping.ActualDeliveryDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", shipping.Status);

                    SqlParameter outputIdParam = new SqlParameter("@NewID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newID = (int?)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return newID;
        }

        public static bool UpdateShipping(ShippingDto shipping)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateShipping", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ShippingID", shipping.ID);
                    command.Parameters.AddWithValue("@OrderID", shipping.OrderID);
                    command.Parameters.AddWithValue("@CarrierName", shipping.CarrierName);
                    command.Parameters.AddWithValue("@ShippingCost", shipping.ShippingCost);
                    command.Parameters.AddWithValue("@ShippingAddress", shipping.ShippingAddress);
                    command.Parameters.AddWithValue("@EstimatedDeliveryDate", shipping.EstimatedDeliveryDate);
                    command.Parameters.AddWithValue("@ActualDeliveryDate", shipping.ActualDeliveryDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", shipping.Status);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static bool DeleteShipping(int? shippingID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteShipping", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ShippingID", shippingID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static List<ShippingDto> GetAllShippings()
        {
            List<ShippingDto> shippings = new List<ShippingDto>();
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllShippings", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ShippingDto shipping = new ShippingDto
                                {
                                    ID = reader["ShippingID"] as int?,
                                    OrderID = reader["OrderID"] as int?,
                                    CarrierName = reader["CarrierName"] as string,
                                    TrackingNumber = reader["TrackingNumber"] as string,
                                    ShippingCost = reader["ShippingCost"] as decimal?,
                                    ShippingAddress = reader["ShippingAddress"] as string,
                                    EstimatedDeliveryDate = reader["EstimatedDeliveryDate"] as DateTime?,
                                    ActualDeliveryDate = reader["ActualDeliveryDate"] as DateTime?,
                                    Status = reader["Status"] as byte?
                                };
                                shippings.Add(shipping);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return shippings;
        }

        public static decimal? GetShippingCost(int? orderID)
        {
            decimal? shippingCost = null;
            string query = "SELECT dbo.GetShippingCost(@OrderID)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        shippingCost = Convert.ToDecimal(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return shippingCost;
        }

        public static DateTime? GetEstimatedDeliveryDate(int? orderID)
        {
            DateTime? estimatedDeliveryDate = null;
            string query = "SELECT dbo.GetEstimatedDeliveryDate(@OrderID)";
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    try
                    {
                        connection.Open();
                        estimatedDeliveryDate = Convert.ToDateTime(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return estimatedDeliveryDate;

        }

        public static List<string> GetAvailableCarriers()
        {
            return new List<string>
             {
                 "USPS",
                 "FedEx",
                 "UPS",
                 "Aramex",
                 "Bahri",
                 "Emirates Shipping Line",
                 "Gulf Agency Company (GAC)",
                 "Qatar Navigation (Milaha)",
                 "Middle East Shipping Co. Ltd (MIDEAST)",
                 "DHL Express",
                 "Naqel Express"
             };
        }
    }


   
}