using DTOs;

namespace Validation
{
    public static class SubcategoryValidation
    {
        public static bool ValidateSubcategoryDto(SubcategoryDto subcategoryDto, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (subcategoryDto is null)
            {
                errorMessage = "Subcategory data is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(subcategoryDto.Name))
            {
                errorMessage = "Subcategory name is required";
                return false;
            }

            if (subcategoryDto.CategoryID is null || subcategoryDto.CategoryID < 1)
            {
                errorMessage = "Invalid Category ID";
                return false;
            }

            return true;
        }

        public static bool ValidateSubcategoryId(int? id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (id is null || id < 1)
            {
                errorMessage = "Invalid Subcategory ID";
                return false;
            }

            return true;
        }
    }
}