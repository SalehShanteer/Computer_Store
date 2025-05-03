using DTOs;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ComputerStore_DataAccessLayer
{
    public class clsPaymentData
    {
        public static PaymentDto GetPaymentByID(int? paymentID)
        {
            PaymentDto payment = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPaymentByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", paymentID ?? (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                payment = new PaymentDto
                                {
                                    ID = paymentID,
                                    OrderID = reader["OrderID"] as int?,
                                    Amount = reader["Amount"] as decimal?,
                                    PaymentMethodID = reader["PaymentMethodID"] as int?,
                                    TransactionDate = reader["TransactionDate"] as DateTime?
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
            return payment;
        }

        public static PaymentDto GetPaymentByOrderID(int? orderID)
        {
            PaymentDto payment = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPaymentByOrderID", connection))
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
                                payment = new PaymentDto
                                {
                                    ID = reader["PaymentID"] as int?,
                                    OrderID = orderID,
                                    Amount = reader["Amount"] as decimal?,
                                    PaymentMethodID = reader["PaymentMethodID"] as int?,
                                    TransactionDate = reader["TransactionDate"] as DateTime?
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
            return payment;
        }

        public static bool IsPaymentExistID(int? paymentID)
        {
            bool isExist = false;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPaymentExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", paymentID ?? (object)DBNull.Value);
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

        public static int? AddNewPayment(PaymentDto payment)
        {
            int? newID = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewPayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", payment.OrderID);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@PaymentMethodID", payment.PaymentMethodID);

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

        public static bool UpdatePayment(PaymentDto payment)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdatePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", payment.ID);
                    command.Parameters.AddWithValue("@OrderID", payment.OrderID);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@PaymentMethodID", payment.PaymentMethodID);
                    command.Parameters.AddWithValue("@TransactionDate", payment.TransactionDate);

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

        public static bool DeletePayment(int? paymentID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeletePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", paymentID ?? (object)DBNull.Value);
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

        public static List<PaymentDto> GetAllPayments()
        {
            List<PaymentDto> payments = new List<PaymentDto>();
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllPayments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaymentDto payment = new PaymentDto
                                {
                                    ID = reader["PaymentID"] as int?,
                                    OrderID = reader["OrderID"] as int?,
                                    Amount = reader["Amount"] as decimal?,
                                    PaymentMethodID = reader["PaymentMethodID"] as int?,
                                    TransactionDate = reader["TransactionDate"] as DateTime?
                                };
                                payments.Add(payment);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return payments;
        }
    }
}