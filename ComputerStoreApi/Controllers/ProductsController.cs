using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/ProductsApi")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet("Find/{id}", Name = "FindProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }
            var Product = clsProduct.Find(id);

            if (Product is null)
            {
                return NotFound($"Product with ID {id} not found");
            }
            return Ok(Product.ProductDto);
        }

        [HttpGet("Find", Name = "FindProductByName")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductDto> Find(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest($"Not accepted name {name}");
            }
            var Product = clsProduct.Find(name);
            if (Product is null)
            {
                return NotFound($"Product with name {name} not found");
            }
            return Ok(Product.ProductDto);
        }


        [HttpPost("Add", Name = "AddNewProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductDto> AddNewProduct(ProductDto productDto)
        {
            string errorMessage = string.Empty;

            if (!ProductValidation.ValidateProductDto(productDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsCategory.IsExist(productDto.CategoryID))
            {
                return BadRequest($"Category with ID {productDto.CategoryID} not found");
            }

            if (productDto.SubcategoryID is not null && !clsSubcategory.IsSubcategoryBelongsToCategory(productDto.SubcategoryID, productDto.CategoryID))
            {
                return BadRequest($"Subcategory with ID {productDto.SubcategoryID} not found or not belongs to category with ID {productDto.CategoryID}");
            }

            if (productDto.BrandID is not null && !clsBrand.IsExist(productDto.BrandID))
            {
                return BadRequest($"Brand with ID {productDto.BrandID} not found");
            }

            var Product = new clsProduct(productDto, clsProduct.enMode.AddNew);
            
            if (!Product.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save product");
            }

            return CreatedAtRoute("FindProduct", new { id = Product.ID }, Product.ProductDto);
        }


        [HttpPut("Update", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductDto> UpdateProduct(ProductDto productDto)
        {
            string errorMessage = string.Empty;
            if (!ProductValidation.ValidateProductDto(productDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var Product = new clsProduct(productDto, clsProduct.enMode.Update);

            if (Product is null)
            {
                return NotFound($"Product with ID {productDto.ID} not found");
            }

            if (!Product.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save product");
            }
            return Ok(Product.ProductDto);
        }


        [HttpDelete("Delete/{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteProduct(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }

            if (!clsProduct.IsExist(id))
            {
                return NotFound($"Product with ID = {id} not found");
            }

            bool IsDeleted = clsProduct.Delete(id);
            if (!IsDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete product");
            }
            return Ok(IsDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }
            bool IsExist = clsProduct.IsExist(id);
            if (!IsExist)
            {
                return NotFound($"Product with ID = {id} not found");
            }
            return Ok(IsExist);
        }

        [HttpGet("GetAll", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            var Products = clsProduct.GetAllProducts();

            if (!Products.Any())
            {
                return NotFound("No products found");
            }

            return Ok(Products);
        }

    }
}
