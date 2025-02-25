using DTOs;
using System;

namespace Validation
{
    public class ProductValidation
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

        // Validate if a quantity is non-negative
        public static bool ValidateQuantity(short quantity, out string errorMessage)
        {
            if (quantity < 0)
            {
                errorMessage = "Quantity cannot be negative.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Validate the entire ProductDto object
        public static bool ValidateProductDto(ProductDto productDto, out string errorMessage)
        {
            if (productDto is null)
            {
                errorMessage = "Product is null.";
                return false;
            }

            if (!ValidateString(productDto.Name, out errorMessage))
            {
                errorMessage = "Product name is null or empty.";
                return false;
            }

            if (!ValidateString(productDto.Description, out errorMessage))
            {
                errorMessage = "Product description is null or empty.";
                return false;
            }

            if (!ValidateNotNull(productDto.CategoryID, out errorMessage))
            {
                errorMessage = "Category ID is null.";
                return false;
            }

            if (!ValidateNotNull(productDto.Price, out errorMessage))
            {
                errorMessage = "Price is null.";
                return false;
            }

            if (!ValidatePrice(productDto.Price.Value, out errorMessage))
            {
                return false;
            }

            if (!ValidateNotNull(productDto.QuantityInStock, out errorMessage))
            {
                errorMessage = "Quantity is null.";
                return false;
            }

            if (!ValidateQuantity(productDto.QuantityInStock.Value, out errorMessage))
            {
                return false;
            }

            if (!ValidateNotNull(productDto.ReleaseDate, out errorMessage))
            {
                errorMessage = "Release Date is null.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }

}