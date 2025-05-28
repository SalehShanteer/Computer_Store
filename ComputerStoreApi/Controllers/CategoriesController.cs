using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using DTOs;
using Validation;

namespace ComputerStoreApi.Controllers
{
    [Route("api/CategoriesApi")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("Find/{id}", Name = "FindCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CategoryDto> Find(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            var category = clsCategory.Find(id);

            if (category is null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(category.categoryDto);
        }


        [HttpPost("Add", Name = "AddNewCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoryDto> AddNewCategory(CategoryDto categoryDto)
        {
            if (!CategoryValidation.ValidateCategoryDto(categoryDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var category = new clsCategory(categoryDto, clsCategory.enMode.AddNew);

            if (!category.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save category");
            }

            return CreatedAtRoute("FindCategory", new { id = category.ID }, category.categoryDto);
        }

        [HttpPut("Update", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            if (!CategoryValidation.ValidateCategoryDto(categoryDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var category = new clsCategory(categoryDto, clsCategory.enMode.Update);

            if (!clsCategory.IsExist(categoryDto.ID))
            {
                return NotFound($"Category with ID {categoryDto.ID} not found");
            }

            if (!category.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update category");
            }

            return Ok(category.categoryDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteCategory(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            if (!clsCategory.IsExist(id))
            {
                return NotFound($"Category with ID {id} not found");
            }

            bool isDeleted = clsCategory.Delete(id.Value);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete category");
            }

            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            bool exists = clsCategory.IsExist(id);

            if (!exists)
            {
                return NotFound($"Category with ID {id} does not exist");
            }

            return Ok(exists);
        }

        [HttpGet("IsExistByName/{name}", Name = "IsExistByNameCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExistByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Category name cannot be null or empty");
            }
            bool exists = clsCategory.IsExist(name);
            if (!exists)
            {
                return NotFound($"Category with name '{name}' does not exist");
            }
            return Ok(exists);
        }

        [HttpGet("GetAll", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = clsCategory.GetAll();

            if (!categories.Any())
            {
                return NotFound("No categories found");
            }

            return Ok(categories);
        }
    }
}