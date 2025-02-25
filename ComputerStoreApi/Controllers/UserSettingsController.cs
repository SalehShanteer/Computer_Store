using ComputerStore_BusinessLayer;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStoreApi.Controllers
{
    [Route("api/UserSettingsApi")]
    [ApiController]
    public class UserSettingsController : ControllerBase
    {

        [HttpGet("Find/{Title}", Name = "FindUserSettingByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserSettingsDto> FindByTitle(string Title)
        {
            if (string.IsNullOrEmpty(Title))
            {
                return BadRequest("Invalid title.");
            }

            clsUserSetting userSetting = clsUserSetting.Find(Title);

            if (userSetting is null)
            {
                return NotFound("User setting not found");
            }

            return Ok(userSetting.userSettingsDto);
        }


        [HttpPut("Update", Name = "UpdateUserSetting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserSettingsDto> UpdateUserSetting(UserSettingsDto UserSettingDto)
        {
            if (UserSettingDto is null || string.IsNullOrEmpty(UserSettingDto.Title))
            {
                return BadRequest("Invalid information.");
            }

            clsUserSetting userSettings = new clsUserSetting(UserSettingDto);

            if (userSettings is null)
            {
                return NotFound("User setting not found.");
            }

            if (!userSettings.Save())
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(userSettings.userSettingsDto);
        }

    }
}
