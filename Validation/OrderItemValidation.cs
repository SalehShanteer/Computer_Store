using DTOs;
using System;

namespace Validation
{
    public class OrderItemValidation
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

        // Validate if a quantity is positive
        public static bool ValidateQuantity(int quantity, out string errorMessage)
        {
            if (quantity < 1)
            {
                errorMessage = "Quantity must be positive.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate if a price is non-negative
        public static bool ValidatePrice(decimal price, out string errorMessage)
        {
            if (price < 0)
            {
                errorMessage = "Price cannot be negative.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate if an ID is positive
        public static bool ValidateID(int id, string fieldName, out string errorMessage)
        {
            if (id < 1)
            {
                errorMessage = $"{fieldName} must be positive.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate the entire OrderItemDto object
        public static bool ValidateOrderItemDto(OrderItemDto orderItemDto, out string errorMessage)
        {
            if (orderItemDto is null)
            {
                errorMessage = "OrderItem is null.";
                return false;
            }

            if (!ValidateID((int)orderItemDto.ProductID, "ProductID", out errorMessage))
            {
                return false;
            }

            if (!ValidateQuantity((int)orderItemDto.Quantity, out errorMessage))
            {
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}