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
        [HttpGet("Find", Name = "FindOrderItem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderItemDto> Find([FromQuery] OrderItemKeyDto orderItemKey)
        {
            if (orderItemKey.OrderID < 1 || orderItemKey.ProductID < 1)
            {
                return BadRequest($"Not accepted OrderID {orderItemKey.OrderID} or ProductID {orderItemKey.ProductID}");
            }

            var orderItem = clsOrderItem.Find(orderItemKey);
            if (orderItem is null)
            {
                return NotFound($"OrderItem with OrderID {orderItemKey.OrderID} and ProductID {orderItemKey.ProductID} not found");
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

            if (!clsUser.IsExistByID(orderItemDto.UserID))
            {
                return BadRequest($"Order with ID {orderItemDto.OrderID} not found");
            }

            if (!clsProduct.IsExist(orderItemDto.ProductID))
            {
                return BadRequest($"Product with ID {orderItemDto.ProductID} not found");
            }

            var orderItem = new clsOrderItem(orderItemDto);

            var Result = orderItem.AddNew();

            if (!Result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Result.Message);
            }

            OrderItemKeyDto orderItemKey = new OrderItemKeyDto
            {
                OrderID = orderItem.OrderID,
                ProductID = orderItem.ProductID
            };

            return CreatedAtRoute("FindOrderItem", new {orderItemKey}, orderItem.OrderItemDto);
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
            var orderItem = new clsOrderItem(orderItemDto);

            if (orderItem is null)
            {
                return NotFound($"OrderItem with OrderID {orderItemDto.OrderID} and ProductID {orderItemDto.ProductID} not found");
            }

            if (!orderItem.Update())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save order item");
            }
            return Ok(orderItem.OrderItemDto);
        }

        [HttpDelete("Delete", Name = "DeleteOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteOrderItem([FromQuery] OrderItemKeyDto orderItemKey)
        {
            if (orderItemKey.OrderID < 1 || orderItemKey.ProductID < 1)
            {
                return BadRequest($"Not accepted OrderID {orderItemKey.OrderID} or ProductID {orderItemKey.ProductID}");
            }

            if (!clsOrderItem.IsExist(orderItemKey))
            {
                return NotFound($"OrderItem with OrderID {orderItemKey.OrderID} and ProductID {orderItemKey.ProductID} not found");
            }

            bool isDeleted = clsOrderItem.Delete(orderItemKey);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete order item");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist", Name = "IsExistOrderItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist([FromQuery] OrderItemKeyDto orderItemKey)
        {
            if (orderItemKey.OrderID < 1 || orderItemKey.ProductID < 1)
            {
                return BadRequest($"Not accepted OrderID {orderItemKey.OrderID} or ProductID {orderItemKey.ProductID}");
            }
            bool isExist = clsOrderItem.IsExist(orderItemKey);
            if (!isExist)
            {
                return NotFound($"OrderItem with OrderID {orderItemKey.OrderID} and ProductID {orderItemKey.ProductID} not found");
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