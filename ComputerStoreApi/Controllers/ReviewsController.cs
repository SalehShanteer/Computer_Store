using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/ReviewsApi")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        [HttpGet("Find/{id}", Name = "FindReview")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ReviewDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid review ID {id}");
            }

            var review = clsReview.Find(id);

            if (review is null)
            {
                return NotFound($"Review with ID {id} not found");
            }

            return Ok(review.ReviewDto);
        }

        [HttpPost("Add", Name = "AddNewReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReviewDto> AddNewReview(ReviewDto reviewDto)
        {
            string errorMessage = string.Empty;

            if (reviewDto.Rating < 1 || reviewDto.Rating > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5", nameof(reviewDto.Rating));
            }

            if (!ReviewValidation.ValidateReviewDto(reviewDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsProduct.IsExist(reviewDto.ProductID))
            {
                return BadRequest($"Product with ID {reviewDto.ProductID} not found");
            }

            if (!clsUser.IsExistByID(reviewDto.UserID))
            {
                return BadRequest($"User with ID {reviewDto.UserID} not found");
            }

            var review = new clsReview(reviewDto, clsReview.enMode.AddNew);

            if (!review.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save review");
            }

            return CreatedAtRoute("FindReview", new { id = review.ID }, review.ReviewDto);
        }

        [HttpPut("Update", Name = "UpdateReview")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ReviewDto> UpdateReview(ReviewDto reviewDto)
        {
            string errorMessage = string.Empty;

            if (reviewDto.Rating < 1 || reviewDto.Rating > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5", nameof(reviewDto.Rating));
            }

            if (!ReviewValidation.ValidateReviewDto(reviewDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsReview.IsExist(reviewDto.ID))
            {
                return NotFound($"Review with ID {reviewDto.ID} not found");
            }

            var review = new clsReview(reviewDto, clsReview.enMode.Update);

            if (!review.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update review");
            }

            return Ok(review.ReviewDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteReview(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid review ID {id}");
            }

            if (!clsReview.IsExist(id))
            {
                return NotFound($"Review with ID {id} not found");
            }

            bool isDeleted = clsReview.Delete(id);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete review");
            }

            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid review ID {id}");
            }

            bool isExist = clsReview.IsExist(id);

            if (!isExist)
            {
                return NotFound($"Review with ID {id} not found");
            }

            return Ok(isExist);
        }

        [HttpGet("GetByProduct/{productId}", Name = "GetReviewsByProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ReviewDto>> GetByProduct(int productId)
        {
            if (productId < 1)
            {
                return BadRequest($"Invalid product ID {productId}");
            }

            var reviews = clsReview.FindByProduct(productId)
                                 .Select(r => r.ReviewDto)
                                 .ToList();

            if (!reviews.Any())
            {
                return NotFound($"No reviews found for product ID {productId}");
            }

            return Ok(reviews);
        }

        [HttpGet("GetByUser/{userId}", Name = "GetReviewsByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ReviewDto>> GetByUser(int userId)
        {
            if (userId < 1)
            {
                return BadRequest($"Invalid user ID {userId}");
            }

            var reviews = clsReview.FindByUser(userId)
                                 .Select(r => r.ReviewDto)
                                 .ToList();

            if (!reviews.Any())
            {
                return NotFound($"No reviews found for user ID {userId}");
            }

            return Ok(reviews);
        }

        [HttpGet("FindByUserAndProduct/{productId}/{userId}", Name = "FindReviewByUserAndProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReviewDto> FindByUserAndProduct(int productId, int userId)
        {
            if (userId < 1 || productId < 1)
            {
                return BadRequest($"Invalid user ID {userId} or product ID {productId}");
            }
            var review = clsReview.Find(productId, userId);
            if (review is null)
            {
                return NotFound($"No review found for user ID {userId} and product ID {productId}");
            }
            return Ok(review.ReviewDto);
        }

        [HttpGet("GetAverageRating/{productId}", Name = "GetAverageRating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<double?> GetAverageRating(int productId)
        {
            if (productId < 1)
            {
                return BadRequest($"Invalid product ID {productId}");
            }

            double? averageRating = clsReview.GetAverageRatingForProduct(productId);
            return Ok(averageRating);
        }

        [HttpGet("GetTotalByProduct/{productId}", Name = "GetTotalByProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GetTotalReviewsForProduct(int productId)
        {
            if (productId < 1)
            {
                return BadRequest($"Invalid product ID {productId}");
            }
            int totalReviews = clsReview.GetTotalReviewsForProduct(productId);
            return Ok(totalReviews);
        }
    }
}