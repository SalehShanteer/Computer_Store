using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/ShippingsApi")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        [HttpGet("Find/{shippingID}", Name = "FindShipping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ShippingDto> Find(int shippingID)
        {
            if (shippingID < 1)
            {
                return BadRequest($"Not accepted ID {shippingID}");
            }
            var shipping = clsShipping.Find(shippingID);
            if (shipping is null)
            {
                return NotFound($"Shipping with ID {shippingID} not found");
            }
            return Ok(shipping.ShippingDto);
        }

        [HttpGet("FindByOrder/{orderID}", Name = "FindShippingByOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ShippingDto> FindByOrder(int orderID)
        {
            if (orderID < 1)
            {
                return BadRequest($"Not accepted Order ID {orderID}");
            }
            var shipping = clsShipping.FindByOrder(orderID);
            if (shipping is null)
            {
                return NotFound($"Shipping for Order ID {orderID} not found");
            }
            return Ok(shipping.ShippingDto);
        }

        [HttpPost("Add", Name = "AddNewShipping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ShippingDto> AddNewShipping(ShippingDto shippingDto)
        {
            string errorMessage = string.Empty;
            if (!ShippingValidation.ValidateShippingDto(shippingDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsOrder.IsExist(shippingDto.OrderID))
            {
                return BadRequest($"Order with ID {shippingDto.OrderID} not found");
            }

            var shipping = new clsShipping(shippingDto, clsShipping.enMode.AddNew);
            if (!shipping.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save shipping");
            }

            return CreatedAtRoute("FindShipping", new { shippingID = shipping.ShippingID }, shipping.ShippingDto);
        }

        [HttpPut("Update", Name = "UpdateShipping")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ShippingDto> UpdateShipping(ShippingDto shippingDto)
        {
            string errorMessage = string.Empty;
            if (!ShippingValidation.ValidateShippingDto(shippingDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var shipping = new clsShipping(shippingDto, clsShipping.enMode.Update);
            if (shipping is null)
            {
                return NotFound($"Shipping with ID {shippingDto.ID} not found");
            }
            if (!shipping.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save shipping");
            }
            return Ok(shipping.ShippingDto);
        }

        [HttpDelete("Delete/{shippingID}", Name = "DeleteShipping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteShipping(int shippingID)
        {
            if (shippingID < 1)
            {
                return BadRequest($"Not accepted ID = {shippingID}");
            }
            if (!clsShipping.IsExist(shippingID))
            {
                return NotFound($"Shipping with ID = {shippingID} not found");
            }
            bool isDeleted = clsShipping.Delete(shippingID);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete shipping");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{shippingID}", Name = "IsExistShipping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int shippingID)
        {
            if (shippingID < 1)
            {
                return BadRequest($"Not accepted ID = {shippingID}");
            }
            bool isExist = clsShipping.IsExist(shippingID);
            if (!isExist)
            {
                return NotFound($"Shipping with ID = {shippingID} not found");
            }
            return Ok(isExist);
        }

        [HttpGet("GetAll", Name = "GetAllShippings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ShippingDto>> GetAllShippings()
        {
            var shippings = clsShipping.GetAllShippings();
            if (!shippings.Any())
            {
                return NotFound("No shippings found");
            }
            return Ok(shippings);
        }

        [HttpGet("GetShippingCost/{orderID}", Name = "GetShippingCost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<decimal?> GetShippingCost(int orderID)
        {
            if (orderID < 1)
            {
                return BadRequest($"Not accepted Order ID = {orderID}");
            }
            var shippingCost = clsShipping.GetShippingCost(orderID);
            if (shippingCost is null)
            {
                return NotFound($"Shipping cost for Order ID = {orderID} not found");
            }
            return Ok(shippingCost);
        }

        [HttpGet("GetEstimatedDeliveryDate/{orderID}", Name = "GetEstimatedDeliveryDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DateTime?> GetEstimatedDeliveryDate(int orderID)
        {
            if (orderID < 1)
            {
                return BadRequest($"Not accepted Order ID = {orderID}");
            }
            var estimatedDeliveryDate = clsShipping.GetEstimatedDeliveryDate(orderID);
            if (estimatedDeliveryDate is null)
            {
                return NotFound($"Estimated delivery date for Order ID = {orderID} not found");
            }
            return Ok(estimatedDeliveryDate);
        }

        [HttpGet("GetAvailableCarriers", Name = "GetAvailableCarriers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<string>> GetAvailableCarriers()
        {
            var carriers = clsShipping.GetAvailableCarriers();
            if (!carriers.Any())
            {
                return NotFound("No available carriers found");
            }
            return Ok(carriers);
        }
    }
}