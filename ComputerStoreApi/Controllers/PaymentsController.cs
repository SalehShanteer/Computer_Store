using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/PaymentsApi")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpGet("Find/{paymentID}", Name = "FindPayment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentDto> Find(int paymentID)
        {
            if (paymentID < 1)
            {
                return BadRequest($"Not accepted ID {paymentID}");
            }
            var payment = clsPayment.Find(paymentID);
            if (payment is null)
            {
                return NotFound($"Payment with ID {paymentID} not found");
            }
            return Ok(payment.PaymentDto);
        }

        [HttpGet("FindByOrder/{orderID}", Name = "FindPaymentByOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentDto> FindByOrder(int orderID)
        {
            if (orderID < 1)
            {
                return BadRequest($"Not accepted Order ID {orderID}");
            }
            var payment = clsPayment.FindByOrder(orderID);
            if (payment is null)
            {
                return NotFound($"Payment for Order ID {orderID} not found");
            }
            return Ok(payment.PaymentDto);
        }

        [HttpPost("Add", Name = "AddNewPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PaymentDto> AddNewPayment(PaymentDto paymentDto)
        {
            string errorMessage = string.Empty;
            if (!PaymentValidation.ValidatePaymentDto(paymentDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            if (!clsOrder.IsExist(paymentDto.OrderID))
            {
                return BadRequest($"Order with ID {paymentDto.OrderID} not found");
            }

            if (!clsPaymentMethod.IsExist(paymentDto.PaymentMethodID))
            {
                return BadRequest($"Payment method with ID {paymentDto.PaymentMethodID} not found");
            }

            var payment = new clsPayment(paymentDto, clsPayment.enMode.AddNew);
            if (!payment.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save payment");
            }

            return CreatedAtRoute("FindPayment", new { paymentID = payment.PaymentID }, payment.PaymentDto);
        }

        [HttpPut("Update", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentDto> UpdatePayment(PaymentDto paymentDto)
        {
            string errorMessage = string.Empty;
            if (!PaymentValidation.ValidatePaymentDto(paymentDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var payment = new clsPayment(paymentDto, clsPayment.enMode.Update);
            if (payment is null)
            {
                return NotFound($"Payment with ID {paymentDto.ID} not found");
            }
            if (!payment.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save payment");
            }
            return Ok(payment.PaymentDto);
        }

        [HttpDelete("Delete/{paymentID}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeletePayment(int paymentID)
        {
            if (paymentID < 1)
            {
                return BadRequest($"Not accepted ID = {paymentID}");
            }
            if (!clsPayment.IsExist(paymentID))
            {
                return NotFound($"Payment with ID = {paymentID} not found");
            }
            bool isDeleted = clsPayment.Delete(paymentID);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete payment");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{paymentID}", Name = "IsExistPayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int paymentID)
        {
            if (paymentID < 1)
            {
                return BadRequest($"Not accepted ID = {paymentID}");
            }
            bool isExist = clsPayment.IsExist(paymentID);
            if (!isExist)
            {
                return NotFound($"Payment with ID = {paymentID} not found");
            }
            return Ok(isExist);
        }

        [HttpGet("GetAll", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PaymentDto>> GetAllPayments()
        {
            var payments = clsPayment.GetAllPayments();
            if (!payments.Any())
            {
                return NotFound("No payments found");
            }
            return Ok(payments);
        }
    }
}