using DTOs;
using System;

namespace Validation
{
    public class ReviewValidation
    {
        // Validate if a string is null or empty
        public static bool ValidateString(string? value, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = "The field is null or empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate if a value is null
        public static bool ValidateNotNull<T>(T value, out string errorMessage)
        {
            if (value is null)
            {
                errorMessage = "The field is null.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate rating is between 1-5
        public static bool ValidateRating(byte? rating, out string errorMessage)
        {
            if (!rating.HasValue)
            {
                errorMessage = "Rating is required.";
                return false;
            }

            if (rating < 1 || rating > 5)
            {
                errorMessage = "Rating must be between 1 and 5.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate review text length (optional with max length)
        public static bool ValidateReviewText(string? reviewText, out string errorMessage)
        {
            if (reviewText != null && reviewText.Length > 255)
            {
                errorMessage = "Review text cannot exceed 255 characters.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate the entire ReviewDto object
        public static bool ValidateReviewDto(ReviewDto reviewDto, out string errorMessage)
        {
            if (reviewDto is null)
            {
                errorMessage = "Review is null.";
                return false;
            }

            if (!ValidateNotNull(reviewDto.ProductID, out errorMessage))
            {
                errorMessage = "Product ID is required.";
                return false;
            }

            if (!ValidateNotNull(reviewDto.UserID, out errorMessage))
            {
                errorMessage = "User ID is required.";
                return false;
            }

            if (!ValidateRating(reviewDto.Rating, out errorMessage))
            {
                return false;
            }

            if (!ValidateReviewText(reviewDto.ReviewText, out errorMessage))
            {
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}