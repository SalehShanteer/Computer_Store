using DTOs;

namespace Validation
{
    public static class BrandValidation
    {
        public static bool ValidateBrandDto(BrandDto brandDto, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check if the DTO is null
            if (brandDto is null)
            {
                errorMessage = "Brand data is required";
                return false;
            }

            // Validate the Name property
            if (string.IsNullOrWhiteSpace(brandDto.Name))
            {
                errorMessage = "Brand name is required";
                return false;
            }

            return true;
        }

        public static bool ValidateBrandId(int? id, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check if the ID is valid
            if (id is null || id < 1)
            {
                errorMessage = "Invalid Brand ID";
                return false;
            }

            return true;
        }
    }
}