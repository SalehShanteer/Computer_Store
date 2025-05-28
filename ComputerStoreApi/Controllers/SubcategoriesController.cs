using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using DTOs;
using Validation;

namespace ComputerStoreApi.Controllers
{
    [Route("api/SubcategoriesApi")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        [HttpGet("Find/{id}", Name = "FindSubcategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SubcategoryDto> Find(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            var subcategory = clsSubcategory.Find(id);

            if (subcategory is null)
            {
                return NotFound($"Subcategory with ID {id} not found");
            }

            return Ok(subcategory.subcategoryDto);
        }

        [HttpPost("Add", Name = "AddNewSubcategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SubcategoryDto> AddNewSubcategory(SubcategoryDto subcategoryDto)
        {
            if (!SubcategoryValidation.ValidateSubcategoryDto(subcategoryDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsCategory.IsExist(subcategoryDto.CategoryID))
            {
                return BadRequest($"Category with ID {subcategoryDto.CategoryID} not found");
            }

            var subcategory = new clsSubcategory(subcategoryDto, clsSubcategory.enMode.AddNew);

            if (!subcategory.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save subcategory");
            }

            return CreatedAtRoute("FindSubcategory", new { id = subcategory.ID }, subcategory.subcategoryDto);
        }

        [HttpPut("Update", Name = "UpdateSubcategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SubcategoryDto> UpdateSubcategory(SubcategoryDto subcategoryDto)
        {
            if (!SubcategoryValidation.ValidateSubcategoryDto(subcategoryDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsCategory.IsExist(subcategoryDto.CategoryID))
            {
                return BadRequest($"Category with ID {subcategoryDto.CategoryID} not found");
            }

            var subcategory = new clsSubcategory(subcategoryDto, clsSubcategory.enMode.Update);

            if (!clsSubcategory.IsExist(subcategoryDto.ID))
            {
                return NotFound($"Subcategory with ID {subcategoryDto.ID} not found");
            }

            if (!subcategory.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update subcategory");
            }

            return Ok(subcategory.subcategoryDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteSubcategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteSubcategory(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            if (!clsSubcategory.IsExist(id))
            {
                return NotFound($"Subcategory with ID {id} not found");
            }

            bool isDeleted = clsSubcategory.Delete(id.Value);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete subcategory");
            }

            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistSubcategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            bool exists = clsSubcategory.IsExist(id);

            if (!exists)
            {
                return NotFound($"Subcategory with ID {id} does not exist");
            }

            return Ok(exists);
        }

        [HttpGet("IsExist", Name = "IsExistSubcategoryByNameAndCategoryID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExistByNameAndCategoryID([FromQuery] SubcategoryDto subcategory)
        {
            if (subcategory is null)
            {
                return BadRequest("Subcategory cannot be null");
            }
            if (string.IsNullOrWhiteSpace(subcategory.Name) || subcategory.CategoryID is null || subcategory.CategoryID < 1)
            {
                return BadRequest("Subcategory name and Category ID are required");
            }
            var exists = clsSubcategory.IsExist(subcategory.Name, subcategory.CategoryID);
            if (!exists)
            {
                return NotFound($"Subcategory with name '{subcategory.Name}' in category ID {subcategory.CategoryID} does not exist");
            }
            return Ok(exists);
        }


            [HttpGet("IsSubcategoryBelongsToCategory", Name = "IsSubcategoryBelongsToCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsSubcategoryBelongsToCategory(int? subcategoryID, int? categoryID)
        {
            if (subcategoryID is null || subcategoryID < 1 || categoryID is null || categoryID < 1)
            {
                return BadRequest("Invalid subcategory or category ID");
            }

            bool belongs = clsSubcategory.IsSubcategoryBelongsToCategory(subcategoryID, categoryID);

            if (!belongs)
            {
                return NotFound($"Subcategory with ID {subcategoryID} does not belong to category with ID {categoryID}");
            }

            return Ok(belongs);
        }

        [HttpGet("GetAll", Name = "GetAllSubcategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SubcategoryDto>> GetAllSubcategories()
        {
            var subcategories = clsSubcategory.GetAll();

            if (!subcategories.Any())
            {
                return NotFound("No subcategories found");
            }

            return Ok(subcategories);
        }

        [HttpGet("GetSubcategoriesByCategoryID/{categoryID}", Name = "GetSubcategoriesByCategoryID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SubcategoryDto>> GetSubcategoriesByCategoryID(int? categoryID)
        {
            if (categoryID is null || categoryID < 1)
            {
                return BadRequest($"Invalid Category ID: {categoryID}");
            }
            var subcategories = clsSubcategory.GetSubcategoriesByCategoryID(categoryID);
            if (!subcategories.Any())
            {
                return NotFound($"No subcategories found for category ID {categoryID}");
            }
            return Ok(subcategories);
        }
    }
}