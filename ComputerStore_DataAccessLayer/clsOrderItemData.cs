using DTOs;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ComputerStore_DataAccessLayer
{
    public class clsOrderItemData
    {
        public static OrderItemDto GetOrderItem(OrderItemKeyDto orderItemKey)
        {
            OrderItemDto orderItem = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderItemKey.OrderID);
                    command.Parameters.AddWithValue("@ProductID", orderItemKey.ProductID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                orderItem = new OrderItemDto
                                {
                                    OrderID = orderItemKey.OrderID,
                                    ProductID = orderItemKey.ProductID,
                                    Quantity = (short?)reader["Quantity"],
                                    Price = (decimal?)reader["Price"],
                                    TotalItemsPrice = (decimal?)reader["TotalItemsPrice"]
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
            return orderItem;
        }

        public static bool IsOrderItemExist(int orderId, int productId)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsOrderItemExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@ProductID", productId);

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

        public static OrderItemResultDto AddNewOrderItem(OrderItemDto orderItem)
        {
            // Validate input
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            if (orderItem.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.", nameof(orderItem.Quantity));

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters with explicit types
                    command.Parameters.Add("@ProductID", SqlDbType.Int).Value = orderItem.ProductID;
                    command.Parameters.Add("@Quantity", SqlDbType.Int).Value = orderItem.Quantity;
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = orderItem.UserID;

                    // Add a parameter to capture the return value
                    SqlParameter returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Get the return value from the stored procedure
                        int returnValue = (int)returnParameter.Value;

                        switch (returnValue)
                        {
                            case 0:
                                return new OrderItemResultDto { Success = true, Message = "Item added successfully." };
                            case -1:
                                return new OrderItemResultDto { Success = false, Message = "This item is out of stock. Please try again later." };
                            case -2:
                                return new OrderItemResultDto { Success = false, Message = "The product was not found." };
                            case -3:
                                return new OrderItemResultDto { Success = false, Message = "Failed to create a new order." };
                            case -4:
                                return new OrderItemResultDto { Success = false, Message = "Invalid quantity specified." };
                            case -5:
                                return new OrderItemResultDto { Success = false, Message = "A database error occurred. Please try again." };
                            default:
                                return new OrderItemResultDto { Success = false, Message = $"Unexpected error occurred. Please contact support." };
                        }
                    }
                    catch (SqlException ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), "SQL Error: " + ex.Message, EventLogEntryType.Error);
                        return new OrderItemResultDto { Success = false, Message = "A database error occurred. Please try again." };
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), "Unexpected error: " + ex.Message, EventLogEntryType.Error);
                        return new OrderItemResultDto { Success = false, Message = "An unexpected error occurred. Please contact support." };
                    }
                }
            }
        }

        public static bool UpdateOrderItem(OrderItemDto orderItem)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                    command.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

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

        public static bool DeleteOrderItem(int orderId, int productId)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@ProductID", productId);

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

        public static List<OrderItemDto> GetOrderItemsByOrderID(int orderId)
        {
            List<OrderItemDto> orderItems = new List<OrderItemDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetOrderItemsByOrderID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderItems.Add(new OrderItemDto
                                {
                                    OrderID = orderId,
                                    ProductID = (int)reader["ProductID"],
                                    Quantity = (short)reader["Quantity"],
                                    Price = (decimal)reader["Price"],
                                    TotalItemsPrice = (decimal)reader["TotalItemsPrice"]
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
            return orderItems;
        }
    }
}