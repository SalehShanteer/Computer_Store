using DTOs;

namespace Validation
{
    public static class CategoryValidation
    {
        public static bool ValidateCategoryDto(CategoryDto categoryDto, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check if the DTO is null
            if (categoryDto is null)
            {
                errorMessage = "Category data is required";
                return false;
            }

            // Validate the Name property
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                errorMessage = "Category name is required";
                return false;
            }

            return true;
        }

        public static bool ValidateCategoryId(int? id, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check if the ID is valid
            if (id is null || id < 1)
            {
                errorMessage = "Invalid Category ID";
                return false;
            }

            return true;
        }
    }
}