using DTOs;

namespace Validation
{
    public static class ProductImageValidation
    {
        public static bool ValidateProductImageDto(ProductImageDto productImageDto, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(productImageDto.ImagePath))
            {
                errorMessage = "Image path cannot be null or empty.";
                return false;
            }

            if (productImageDto.ProductID < 1)
            {
                errorMessage = "Invalid product ID.";
                return false;
            }

            if (productImageDto.ImageOrder < 1)
            {
                errorMessage = "Image order cannot be less than one.";
                return false;
            }

            return true;
        }
    }
}