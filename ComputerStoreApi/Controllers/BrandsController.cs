using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using DTOs;
using Validation;

namespace ComputerStoreApi.Controllers
{
    [Route("api/BrandsApi")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpGet("Find/{id}", Name = "FindBrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BrandDto> Find(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            var brand = clsBrand.Find(id);

            if (brand is null)
            {
                return NotFound($"Brand with ID {id} not found");
            }

            return Ok(brand.brandDto);
        }


        [HttpPost("Add", Name = "AddNewBrand")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BrandDto> AddNewBrand(BrandDto brandDto)
        {
            if (!BrandValidation.ValidateBrandDto(brandDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var brand = new clsBrand(brandDto, clsBrand.enMode.AddNew);

            if (!brand.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save brand");
            }

            return CreatedAtRoute("FindBrand", new { id = brand.ID }, brand.brandDto);
        }

        [HttpPut("Update", Name = "UpdateBrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BrandDto> UpdateBrand(BrandDto brandDto)
        {
            if (!BrandValidation.ValidateBrandDto(brandDto, out string errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var brand = new clsBrand(brandDto, clsBrand.enMode.Update);

            if (!clsBrand.IsExist(brandDto.ID))
            {
                return NotFound($"Brand with ID {brandDto.ID} not found");
            }

            if (!brand.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update brand");
            }

            return Ok(brand.brandDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteBrand(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            if (!clsBrand.IsExist(id))
            {
                return NotFound($"Brand with ID {id} not found");
            }

            bool isDeleted = clsBrand.Delete(id.Value);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete brand");
            }

            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            bool exists = clsBrand.IsExist(id);

            if (!exists)
            {
                return NotFound($"Brand with ID {id} does not exist");
            }

            return Ok(exists);
        }

        [HttpGet("IsExistByName/{name}", Name = "IsExistByNameBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExistByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Brand name cannot be null or empty");
            }
            bool exists = clsBrand.IsExist(name);
            if (!exists)
            {
                return NotFound($"Brand with name '{name}' does not exist");
            }
            return Ok(exists);
        }


        [HttpGet("GetAll", Name = "GetAllBrands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BrandDto>> GetAllBrands()
        {
            var brands = clsBrand.GetAll();

            if (!brands.Any())
            {
                return NotFound("No brands found");
            }

            return Ok(brands);
        }
    }
}