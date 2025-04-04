using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/ProductImagesApi")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {

        //private readonly DirectoryPaths _directoryPaths;

        //public ProductImagesController(DirectoryPaths directoryPaths)
        //{
        //    _directoryPaths = directoryPaths;
        //}

        [HttpGet("Find/{id}", Name = "FindProductImageByID")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductImageDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            var productImage = clsProductImage.Find(id);

            if (productImage is null)
            {
                return NotFound($"Product image with ID {id} not found");
            }

            return Ok(productImage.ProductImageDto);
        }

        [HttpGet("FindByImagePath", Name = "FindProductImageByImagePath")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductImageDto> Find(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return BadRequest("Image path cannot be null or empty");
            }

            var productImage = clsProductImage.Find(imagePath);

            if (productImage is null)
            {
                return NotFound($"Product image with path {imagePath} not found");
            }

            return Ok(productImage.ProductImageDto);
        }

        [HttpGet("FindFirstImage/{productId}", Name = "FindFirstImageByProductID")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductImageDto> FindFirstImage(int productId)
        {
            if (productId < 1)
            {
                return BadRequest($"Not accepted ID {productId}");
            }

            var productImage = clsProductImage.FindFirstImageByProductID(productId);

            if (productImage is null)
            {
                return NotFound($"Product image with ID {productId} not found");
            }

            return Ok(productImage.ProductImageDto);
        }

        [HttpPost("Add", Name = "AddNewProductImage")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductImageDto> AddNewProductImage(ProductImageDto productImageDto)
        {
            string errorMessage = string.Empty;

            if (!ProductImageValidation.ValidateProductImageDto(productImageDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsProduct.IsExist(productImageDto.ProductID))
            {
                return BadRequest($"Product with ID {productImageDto.ProductID} not found");
            }

            var productImage = new clsProductImage(productImageDto, clsProductImage.enMode.AddNew);

            if (!productImage.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save product image");
            }

            return CreatedAtRoute("FindProductImageByID", new { id = productImage.ID }, productImage.ProductImageDto);
        }

        [HttpPut("Update", Name = "UpdateProductImage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProductImageDto> UpdateProductImage(ProductImageDto productImageDto)
        {
            string errorMessage = string.Empty;

            if (!ProductImageValidation.ValidateProductImageDto(productImageDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var productImage = new clsProductImage(productImageDto, clsProductImage.enMode.Update);

            if (productImage is null)
            {
                return NotFound($"Product image with ID {productImageDto.ID} not found");
            }

            productImage.ImagePath = productImageDto.ImagePath;
            productImage.ProductID = productImageDto.ProductID;
            productImage.ImageOrder = productImageDto.ImageOrder;

            if (!productImage.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update product image");
            }

            return Ok(productImage.ProductImageDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteProductImageByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteProductImageByID(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }

            if (!clsProductImage.IsExist(id))
            {
                return NotFound($"Product image with ID = {id} not found");
            }

            bool isDeleted = clsProductImage.Delete(id);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete product image");
            }

            return Ok(isDeleted);
        }

        [HttpDelete("DeleteByImagePath", Name = "DeleteProductImageByImagePath")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteProductImageByImagePath(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return BadRequest("Image path cannot be null or empty");
            }

            if (!clsProductImage.IsExist(imagePath))
            {
                return NotFound($"Product image with path {imagePath} not found");
            }

            bool isDeleted = clsProductImage.Delete(imagePath);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete product image");
            }

            return Ok(isDeleted);
        }

        [HttpDelete("DeleteAll/{productID}", Name = "DeleteAllProductImagesRelated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteAllProductImagesRelated(int productID)
        {
            if (productID < 1)
            {
                return BadRequest($"Not accepted Product ID = {productID}");
            }
            bool isDeleted = clsProductImage.DeleteAllProductImagesRelated(productID);
            
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete product images");
            }
            return Ok(isDeleted);
        }

        [HttpDelete("DeleteAllWithFiles/{productID}", Name = "DeleteAllProductImagesRelatedWithFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteAllProductImagesRelatedWithFiles(int productID)
        {
            if (productID < 1)
            {
                return BadRequest($"Not accepted Product ID = {productID}");
            }
            bool isDeleted = clsProductImage.DeleteAllProductImagesRelatedWithFiles(productID);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete product images");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistProductImageByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }

            bool isExist = clsProductImage.IsExist(id);

            if (!isExist)
            {
                return NotFound($"Product image with ID = {id} not found");
            }

            return Ok(isExist);
        }

        [HttpGet("IsExistByImagePath", Name = "IsExistProductImageByImagePath")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return BadRequest("Image path cannot be null or empty");
            }

            bool isExist = clsProductImage.IsExist(imagePath);

            if (!isExist)
            {
                return NotFound($"Product image with path {imagePath} not found");
            }

            return Ok(isExist);
        }

        [HttpGet("GetAll/{productID}", Name = "GetAllProductImagesRelated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProductImageDto>> GetAllProductImagesRelated(int productID)
        {
            var productImages = clsProductImage.GetAllProductImagesRelated(productID);

            if (!productImages.Any())
            {
                return NotFound($"No product images found for product with ID {productID}");
            }

            return Ok(productImages);
        }

        [HttpPost("Upload", Name = "UploadProductImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadProductImage(IFormFile imageFile)
        {
            if (imageFile is null || imageFile.Length == 0)
                return BadRequest("Image file is invalid or empty.");

            if (!imageFile.ContentType.StartsWith("image/"))
                return BadRequest("Invalid image file type.");

            try
            {
                var uploadDirectory = Path.Combine(
                    "C:\\Users\\saleh\\Desktop\\Programming\\Projects\\Computer Store\\Images\\Server\\Product"
                );

                if (!Directory.Exists(uploadDirectory))
                    Directory.CreateDirectory(uploadDirectory);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await imageFile.CopyToAsync(stream);

                // Return a relative path or filename, not the server's absolute path
                return Ok(new { fileName });
            }
            catch (Exception ex) when (
                ex is UnauthorizedAccessException
                or IOException
                or PathTooLongException
            )
            {
                // Log the exception here (e.g., ILogger)
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload image.");
            }
        }

        [HttpGet("GetImage/{fileName}", Name = "GetProductImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductImage(string fileName)
        {
            //var fileDirectory = _directoryPaths.GetProductImagesDirectory();
            var fileDirectory = "C:\\Users\\saleh\\Desktop\\Programming\\Projects\\Computer Store\\Images\\Server\\Product";

            var filePath = Path.Combine(fileDirectory, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found");
            }
            var image = System.IO.File.OpenRead(filePath);
            var mimeType = GetMimeType(filePath);

            return PhysicalFile(filePath, GetMimeType(filePath));
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream",
            };

        }
    }
}