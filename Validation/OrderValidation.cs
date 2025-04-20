using DTOs;
using System;

namespace Validation
{
    public class OrderValidation
    {
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

        // Validate if a total amount is non-negative
        public static bool ValidateTotalAmount(decimal totalAmount, out string errorMessage)
        {
            if (totalAmount < 0)
            {
                errorMessage = "TotalAmount cannot be negative.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate if a user ID is positive
        public static bool ValidateUserID(int? userId, out string errorMessage)
        {
            if (userId < 1)
            {
                errorMessage = "UserID must be positive.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate if a status is within range
        public static bool ValidateStatus(byte status, out string errorMessage)
        {
            if (status > 4) // 0 => Canceled, 1 => Draft, 2 => Pending, 3 => Processing, 4 => Delivered
            {
                errorMessage = "Status must be between 0 and 4.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate the entire OrderDto object
        public static bool ValidateOrderDto(OrderDto orderDto, out string errorMessage)
        {
            if (orderDto is null)
            {
                errorMessage = "Order is null.";
                return false;
            }

            if (!ValidateUserID(orderDto.UserID, out errorMessage))
            {
                return false;
            }

            if (!ValidateTotalAmount((decimal)orderDto.TotalAmount, out errorMessage))
            {
                return false;
            }

            if (!ValidateNotNull(orderDto.OrderDate, out errorMessage))
            {
                errorMessage = "OrderDate is null.";
                return false;
            }

            if (!ValidateStatus((byte)orderDto.Status, out errorMessage))
            {
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}