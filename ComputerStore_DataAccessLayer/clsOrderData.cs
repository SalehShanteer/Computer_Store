using DTOs;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ComputerStore_DataAccessLayer
{
    public class clsOrderData
    {
        public static OrderDto GetOrderByID(int? orderId)
        {
            OrderDto order = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetOrderByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new OrderDto
                                {
                                    ID = orderId,
                                    UserID = reader["UserID"] as int?,
                                    TotalAmount = reader["TotalAmount"] as decimal?,
                                    OrderDate = reader["OrderDate"] as DateTime?,
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
            return order;
        }

        public static OrderDto GetCurrentOrderByUserID(int? userId)
        {
            OrderDto order = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCurrentOrderByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new OrderDto
                                {
                                    ID = reader["OrderID"] as int?,
                                    UserID = userId,
                                    TotalAmount = reader["TotalAmount"] as decimal?,
                                    OrderDate = reader["OrderDate"] as DateTime?,
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
            return order;
        }

        public static bool IsOrderExist(int? orderId)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsOrderExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId ?? (object)DBNull.Value);

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

        public static int? AddNewOrder(OrderDto order)
        {
            int? newOrderId = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", order.UserID);
                   
                    SqlParameter outputIdParam = new SqlParameter("@NewOrderID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newOrderId = (int?)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return newOrderId;
        }

        public static bool UpdateOrder(OrderDto order)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", order.ID);
                    command.Parameters.AddWithValue("@UserID", order.UserID);
                    command.Parameters.AddWithValue("@Status", order.Status);

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

        public static bool DeleteOrder(int? orderId)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId ?? (object)DBNull.Value);

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

        public static List<OrderDto> GetAllOrders()
        {
            List<OrderDto> orders = new List<OrderDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orders.Add(new OrderDto
                                {
                                    ID = (int)reader["OrderID"],
                                    UserID = reader["UserID"] as int?,
                                    TotalAmount = reader["TotalAmount"] as decimal?,
                                    OrderDate = reader["OrderDate"] as DateTime?,
                                    Status = reader["Status"] as byte?
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return orders;
        }

        public static List<OrderDto> GetOrdersByUserID(int userId)
        {
            List<OrderDto> orders = new List<OrderDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetOrdersByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orders.Add(new OrderDto
                                {
                                    ID = reader["OrderID"] as int?,
                                    UserID = userId,
                                    TotalAmount = reader["TotalAmount"] as decimal?,
                                    OrderDate = reader["OrderDate"] as DateTime?,
                                    Status = reader["Status"] as byte?
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return orders;
        }

    }
}