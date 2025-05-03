using DTOs;
using System;

namespace Validation
{
    public class PaymentValidation
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

        public static bool ValidateAmount(decimal amount, out string errorMessage)
        {
            if (amount <= 0)
            {
                errorMessage = "Amount must be greater than zero.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateTransactionDate(DateTime date, out string errorMessage)
        {
            if (date > DateTime.Now)
            {
                errorMessage = "Transaction date cannot be in the future.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidatePaymentMethodDto(PaymentMethodDto paymentMethodDto, out string errorMessage)
        {
            if (paymentMethodDto is null)
            {
                errorMessage = "Payment method is null.";
                return false;
            }

            if (!ValidateString(paymentMethodDto.Name, out errorMessage))
            {
                errorMessage = "Payment method name is null or empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidatePaymentDto(PaymentDto paymentDto, out string errorMessage)
        {
            if (paymentDto is null)
            {
                errorMessage = "Payment is null.";
                return false;
            }

            if (!ValidateNotNull(paymentDto.OrderID, out errorMessage))
            {
                errorMessage = "Order ID is null.";
                return false;
            }

            if (!ValidateNotNull(paymentDto.Amount, out errorMessage))
            {
                errorMessage = "Amount is null.";
                return false;
            }

            if (!ValidateAmount(paymentDto.Amount.Value, out errorMessage))
            {
                return false;
            }

            if (!ValidateNotNull(paymentDto.PaymentMethodID, out errorMessage))
            {
                errorMessage = "Payment method ID is null.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}