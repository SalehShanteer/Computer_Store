using DTOs;
using System;

namespace Validation
{
    public class ShippingValidation
    {
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

        public static bool ValidateShippingCost(decimal cost, out string errorMessage)
        {
            if (cost < 0)
            {
                errorMessage = "Shipping cost cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateStatus(byte? status, out string errorMessage)
        {
            if (!status.HasValue)
            {
                errorMessage = "Status is null.";
                return false;
            }
            if (status > 3 || status < 0) // 0: canceled, 1: pending, 2: processing, 3: delivered
            {
                errorMessage = "Status must be between 0 and 3.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateEstimatedDeliveryDate(DateTime date, out string errorMessage)
        {
            if (date < DateTime.Now)
            {
                errorMessage = "Estimated delivery date cannot be in the past.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateActualDeliveryDate(DateTime? date, DateTime estimatedDate, out string errorMessage)
        {
            if (date.HasValue && date.Value < estimatedDate)
            {
                errorMessage = "Actual delivery date cannot be before estimated delivery date.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateShippingDto(ShippingDto shippingDto, out string errorMessage)
        {
            if (shippingDto is null)
            {
                errorMessage = "Shipping is null.";
                return false;
            }

            if (!ValidateNotNull(shippingDto.OrderID, out errorMessage))
            {
                errorMessage = "Order ID is null.";
                return false;
            }

            if (!ValidateString(shippingDto.CarrierName, out errorMessage))
            {
                errorMessage = "Carrier name is null or empty.";
                return false;
            }

            if (!ValidateString(shippingDto.ShippingAddress, out errorMessage))
            {
                errorMessage = "Shipping address is null or empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateShippingStatusDto(ShippingStatusDto shippingStatus, out string errorMessage)
        {
            if (shippingStatus is null)
            {
                errorMessage = "Shipping status is null.";
                return false;
            }
            if (!ValidateNotNull(shippingStatus.OrderID, out errorMessage))
            {
                errorMessage = "Order ID is null.";
                return false;
            }
            if (!ValidateStatus(shippingStatus.Status, out errorMessage))
            {
                return false;
            }
            errorMessage = string.Empty;
            return true;

        }
    }
}