using Microsoft.AspNetCore.Mvc;
using ComputerStore_BusinessLayer;
using Validation;
using DTOs;

namespace ComputerStoreApi.Controllers
{
    [Route("api/PaymentMethodsApi")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        [HttpGet("Find/{paymentMethodID}", Name = "FindPaymentMethod")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentMethodDto> Find(int paymentMethodID)
        {
            if (paymentMethodID < 1)
            {
                return BadRequest($"Not accepted ID {paymentMethodID}");
            }
            var paymentMethod = clsPaymentMethod.Find(paymentMethodID);
            if (paymentMethod is null)
            {
                return NotFound($"Payment method with ID {paymentMethodID} not found");
            }
            return Ok(paymentMethod.PaymentMethodDto);
        }

        [HttpGet("FindByName", Name = "FindPaymentMethodByName")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentMethodDto> FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest($"Not accepted name {name}");
            }
            var paymentMethod = clsPaymentMethod.FindByName(name);
            if (paymentMethod is null)
            {
                return NotFound($"Payment method with name {name} not found");
            }
            return Ok(paymentMethod.PaymentMethodDto);
        }

        [HttpPost("Add", Name = "AddNewPaymentMethod")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PaymentMethodDto> AddNewPaymentMethod(PaymentMethodDto paymentMethodDto)
        {
            string errorMessage = string.Empty;
            if (!PaymentValidation.ValidatePaymentMethodDto(paymentMethodDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            var paymentMethod = new clsPaymentMethod(paymentMethodDto, clsPaymentMethod.enMode.AddNew);
            if (!paymentMethod.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save payment method");
            }

            return CreatedAtRoute("FindPaymentMethod", new { paymentMethodID = paymentMethod.PaymentMethodID }, paymentMethod.PaymentMethodDto);
        }

        [HttpPut("Update", Name = "UpdatePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PaymentMethodDto> UpdatePaymentMethod(PaymentMethodDto paymentMethodDto)
        {
            string errorMessage = string.Empty;
            if (!PaymentValidation.ValidatePaymentMethodDto(paymentMethodDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            var paymentMethod = new clsPaymentMethod(paymentMethodDto, clsPaymentMethod.enMode.Update);
            if (paymentMethod is null)
            {
                return NotFound($"Payment method with ID {paymentMethodDto.ID} not found");
            }
            if (!paymentMethod.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to save payment method");
            }
            return Ok(paymentMethod.PaymentMethodDto);
        }

        [HttpDelete("Delete/{paymentMethodID}", Name = "DeletePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeletePaymentMethod(int paymentMethodID)
        {
            if (paymentMethodID < 1)
            {
                return BadRequest($"Not accepted ID = {paymentMethodID}");
            }
            if (!clsPaymentMethod.IsExist(paymentMethodID))
            {
                return NotFound($"Payment method with ID = {paymentMethodID} not found");
            }
            bool isDeleted = clsPaymentMethod.Delete(paymentMethodID);
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete payment method");
            }
            return Ok(isDeleted);
        }

        [HttpGet("IsExist/{paymentMethodID}", Name = "IsExistPaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsExist(int paymentMethodID)
        {
            if (paymentMethodID < 1)
            {
                return BadRequest($"Not accepted ID = {paymentMethodID}");
            }
            bool isExist = clsPaymentMethod.IsExist(paymentMethodID);
            if (!isExist)
            {
                return NotFound($"Payment method with ID = {paymentMethodID} not found");
            }
            return Ok(isExist);
        }

        [HttpGet("GetAll", Name = "GetAllPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PaymentMethodDto>> GetAllPaymentMethods()
        {
            var paymentMethods = clsPaymentMethod.GetAllPaymentMethods();
            if (!paymentMethods.Any())
            {
                return NotFound("No payment methods found");
            }
            return Ok(paymentMethods);
        }
    }
}