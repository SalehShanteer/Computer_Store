using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/OrderItemsApi")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        [HttpGet("Find/{orderId}/{productId}", Name = "FindOrderItem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderItemDto> Find(int orderId, int productId)
        {
            if (orderId < 1 || productId < 1)
            {
                return BadRequest($"Not accepted OrderID {orderId} or ProductID {productId}");
            }
            var orderItem = clsOrderItem.Find(orderId, productId);

            if (orderItem is null)
            {
                return NotFound($"OrderItem with OrderID {orderId} and ProductID {productId} not found");
            }
            return Ok(orderItem.OrderItemDto);
        }

        [HttpPost("Add", Name = "AddNewOrderItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OrderItemDto> AddNewOrderItem(OrderItemDto orderItemDto)
        {
            string errorMessage = string.Empty;

            if (!OrderItemValidation.ValidateOrderItemDto(orderItemDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsOrder.IsExist(orderItemDto.OrderID))
            {
                return BadRequest($"Order with ID {orderItemDto.OrderID} not found");
            }

            if (!clsProduct.IsExist(orderItemDto.ProductID))
            {
                return BadRequest($"Product with ID {orderItemDto.ProductID} not found");
            }

            var orderItem = new clsOrderItem(orderItemDto, clsOrderItem.enMode.AddNew);

            if (!orderItem.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save order item");
            }

            return CreatedAtRoute("FindOrderItem", new { orderId = orderItem.OrderID, productId = orderItem.ProductID }, orderItem.OrderItemDto);
        }

        [HttpPut("Update", Name = "UpdateOrderItem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderItemDto> UpdateOrderItem(OrderItemDto orderItemDto)
        {
            string errorMessage = string.Empty;
            if (!OrderItemValidation.ValidateOrderItemDto(orderItemDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var orderItem = new clsOrderItem(orderItemDto, clsOrderItem.enMode.Update);

            if (orderItem is null)
            {
                return NotFound($"OrderItem with OrderID {orderItemDto.OrderID} and ProductID {orderItemDto.ProductID} not found");
            }

            if (!orderItem.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save order item");
            }
            return Ok(orderItem.OrderItemDto);
        }

        [HttpDelete("Delete/{orderId}/{productId}", Name = "DeleteOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteOrderItem(int orderId, int productId)
        {
            if (orderId < 1 || productId < 1)
            {
                return BadRequest($"Not accepted OrderID {orderId} or ProductID {productId}");
            }

            if (!clsOrderItem.IsExist(orderId, productId))
            {
                return NotFound($"OrderItem with OrderID {orderId} and ProductID {productId} not found");
            }

            bool isDeleted = clsOrderItem.Delete(orderId, productId);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete order item");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{orderId}/{productId}", Name = "IsExistOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int orderId, int productId)
        {
            if (orderId < 1 || productId < 1)
            {
                return BadRequest($"Not accepted OrderID {orderId} or ProductID {productId}");
            }
            bool isExist = clsOrderItem.IsExist(orderId, productId);
            if (!isExist)
            {
                return NotFound($"OrderItem with OrderID {orderId} and ProductID {productId} not found");
            }
            return Ok(isExist);
        }

        [HttpGet("GetByOrder/{orderId}", Name = "GetOrderItemsByOrderID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderItemDto>> GetOrderItemsByOrderID(int orderId)
        {
            if (orderId < 1)
            {
                return BadRequest($"Not accepted OrderID = {orderId}");
            }

            var orderItems = clsOrderItem.GetOrderItemsByOrderID(orderId);
            if (!orderItems.Any())
            {
                return NotFound($"No order items found for OrderID = {orderId}");
            }
            return Ok(orderItems);
        }
    }
}