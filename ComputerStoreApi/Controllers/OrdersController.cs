using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/OrdersApi")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("Find/{id}", Name = "FindOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }
            var order = clsOrder.Find(id);

            if (order is null)
            {
                return NotFound($"Order with ID {id} not found");
            }
            return Ok(order.OrderDto);
        }

        [HttpGet("FindCurrent/{userId}", Name = "FindCurrentOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderDto> FindCurrentOrder(int userId)
        {
            if (userId < 1)
            {
                return BadRequest($"Not accepted UserID {userId}");
            }
            var order = clsOrder.FindCurrent(userId);
            if (order is null)
            {
                return NotFound($"No current order found for UserID {userId}");
            }
            return Ok(order.OrderDto);
        }

        [HttpPost("Add", Name = "AddNewOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OrderDto> AddNewOrder(OrderDto orderDto)
        {

            if (orderDto is null)
            {
                return BadRequest("OrderDto is null");
            }

            if (!clsUser.IsExistByID(orderDto.UserID))
            {
                return BadRequest($"User with ID {orderDto.UserID} not found");
            }

            var order = new clsOrder(orderDto, clsOrder.enMode.AddNew);

            if (!order.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save order");
            }

            return CreatedAtRoute("FindOrder", new { id = order.OrderID }, order.OrderDto);
        }

        [HttpPut("Update", Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<OrderDto> UpdateOrder(OrderDto orderDto)
        {
            string errorMessage = string.Empty;
            if (!OrderValidation.ValidateOrderDto(orderDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var order = new clsOrder(orderDto, clsOrder.enMode.Update);

            if (order is null)
            {
                return NotFound($"Order with ID {orderDto.OrderID} not found");
            }

            if (!order.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save order");
            }
            return Ok(order.OrderDto);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteOrder(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }

            if (!clsOrder.IsExist(id))
            {
                return NotFound($"Order with ID = {id} not found");
            }

            bool isDeleted = clsOrder.Delete(id);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete order");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID = {id}");
            }
            bool isExist = clsOrder.IsExist(id);
            if (!isExist)
            {
                return NotFound($"Order with ID = {id} not found");
            }
            return Ok(isExist);
        }

        [HttpGet("GetAll", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = clsOrder.GetAllOrders();

            if (!orders.Any())
            {
                return NotFound("No orders found");
            }

            return Ok(orders);
        }

        [HttpGet("GetByUser/{userId}", Name = "GetOrdersByUserID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDto>> GetOrdersByUserID(int userId)
        {
            if (userId < 1)
            {
                return BadRequest($"Not accepted UserID = {userId}");
            }

            var orders = clsOrder.GetOrdersByUserID(userId);
            if (!orders.Any())
            {
                return NotFound($"No orders found for UserID = {userId}");
            }
            return Ok(orders);
        }
    }
}