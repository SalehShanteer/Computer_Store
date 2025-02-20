using ComputerStore_BusinessLayer;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Validation;

namespace ComputerStoreApi.Controllers
{
    [Route("api/LoginRecordsApi")]
    [ApiController]
    public class LoginRecordsController : ControllerBase
    {

        [HttpGet("Find/{id}", Name = "FindLoginRecord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LoginRecordDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid login record ID");
            }

            var loginRecord = clsLoginRecord.Find(id);

            if (loginRecord is null)
            {
                return NotFound($"Login record with id = {id}");
            }

            return Ok(loginRecord.loginRecordDto);
        }

        [HttpPost("Add", Name = "AddNewLoginRecord")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> AddNewLoginRecord(LoginRecordDto loginRecordDto)
        {
            if (!LoginRecordValidation.ValidateLoginRecord(loginRecordDto))
            {
                return BadRequest("Invalid login record data.");
            }

            clsLoginRecord loginRecord = new clsLoginRecord(loginRecordDto);

            if (!loginRecord.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the login record");
            }

            return CreatedAtRoute("FindLoginRecord", new { id = loginRecordDto.ID }, loginRecord);
        }


        [HttpGet("RecordList", Name = "GetLoginRecordsList")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DataTable> GetRecordsList()
        {
            DataTable dtLoginRecords = clsLoginRecord.GetAllLoginRecords();

            if (dtLoginRecords is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting the login records");
            }

            if (dtLoginRecords.Rows.Count == 0)
            {
                return NotFound("There is no login records");
            }

            return Ok(dtLoginRecords);
        }


        [HttpGet("Count", Name = "GetLoginRecordsCount")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> Count()
        {
            int? loginRecordsCount = clsLoginRecord.GetLoginRecordsCount();

            if (loginRecordsCount is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting records count");
            }

            return Ok(loginRecordsCount);
        }

    }
}
