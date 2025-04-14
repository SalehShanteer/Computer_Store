using System;
using System.Diagnostics;
using DTOs;
using Microsoft.Data.SqlClient;

namespace ComputerStore_DataAccessLayer
{
    public static class clsReviewData
    {
        public static ReviewDto GetReviewByID(int? id)
        {
            ReviewDto review = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetReviewByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReviewID", id ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                review = new ReviewDto
                                {
                                    ID = id,
                                    ProductID = reader["ProductID"] as int?,
                                    UserID = reader["UserID"] as int?,
                                    ReviewText = reader["ReviewText"] as string,
                                    Rating = reader["Rating"] as byte?,
                                    ReviewDate = reader["ReviewDate"] as DateTime?
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
            return review;
        }

        public static List<ReviewDto> GetReviewsByProductID(int productId)
        {
            List<ReviewDto> reviews = new List<ReviewDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetReviewsByProductID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReviewDto review = new ReviewDto
                                {
                                    ID = reader["ReviewID"] as int?,
                                    ProductID = productId,
                                    UserID = reader["UserID"] as int?,
                                    ReviewText = reader["ReviewText"] as string,
                                    Rating = reader["Rating"] as byte?,
                                    ReviewDate = reader["ReviewDate"] as DateTime?
                                };
                                reviews.Add(review);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return reviews;
        }

        public static List<ReviewDto> GetReviewsByUserID(int userId)
        {
            List<ReviewDto> reviews = new List<ReviewDto>();

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetReviewsByUserID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReviewDto review = new ReviewDto
                                {
                                    ID = reader["ReviewID"] as int?,
                                    ProductID = reader["ProductID"] as int?,
                                    UserID = userId,
                                    ReviewText = reader["ReviewText"] as string,
                                    Rating = reader["Rating"] as byte?,
                                    ReviewDate = reader["ReviewDate"] as DateTime?
                                };
                                reviews.Add(review);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return reviews;
        }

        public static ReviewDto FindReviewByProductIDUserID(int productId, int userId)
        {
            ReviewDto review = null;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetReviewByProductIDUserID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                review = new ReviewDto
                                {
                                    ID = reader["ReviewID"] as int?,
                                    ProductID = productId,
                                    UserID = userId,
                                    ReviewText = reader["ReviewText"] as string,
                                    Rating = reader["Rating"] as byte?,
                                    ReviewDate = reader["ReviewDate"] as DateTime?
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
            return review;
        }

        public static bool IsReviewExistByID(int? id)
        {
            bool IsExist = false;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IsReviewExistByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        IsExist = Convert.ToBoolean(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsExist;
        }

        public static int? AddNewReview(ReviewDto review)
        {
            int? newID = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewReview", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", review.ProductID);
                    command.Parameters.AddWithValue("@UserID", review.UserID);
                    command.Parameters.AddWithValue("@ReviewText", review.ReviewText ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", review.Rating);

                    SqlParameter outputIdParam = new SqlParameter("@NewID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
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

        public static bool UpdateReview(ReviewDto review)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateReview", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", review.ID);
                    command.Parameters.AddWithValue("@ReviewText", review.ReviewText ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", review.Rating);

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

        public static bool DeleteReview(int? id)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteReview", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id ?? (object)DBNull.Value);

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

        public static double? GetAverageRatingForProduct(int productId)
        {
            double? averageRating = null;

            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAverageRatingForProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            averageRating = Convert.ToDouble(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return averageRating;
        }

        public static int GetTotalReviewsForProduct(int productId)
        {
            int totalReviews = 0;
            using (SqlConnection connection = new SqlConnection(DatabaseConfiguration.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTotalReviewsForProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productId);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalReviews = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(DatabaseConfiguration.GetSourceName(), ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return totalReviews;
        }
    }
}
