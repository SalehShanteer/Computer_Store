using ComputerStore_BusinessLayer;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Validation;

namespace ComputerStoreApi.Controllers
{
    [Route("api/UsersApi")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet("Find/{id}", Name = "FindUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDto> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            var User = clsUser.Find(id);

            if (User is null)
            {
                return NotFound($"User with ID {id} not found");
            }

            return Ok(User.userDto);
        }


        [HttpGet("Find", Name = "FindUserByEmail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDto> Find(string email)
        {
            if (!UserValidation.ValidateEmail(email))
            {
                return BadRequest($"The email is not valid");
            }

            var User = clsUser.Find(email);

            if (User == null)
            {
                return NotFound($"User with email {email} not found");
            }

            return Ok(User.userDto);
        }


        [HttpGet("IsExist", Name = "IsExistByEmail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> IsExist(string email)
        {
            if (!UserValidation.ValidateEmail(email))
            {
                return BadRequest($"The email is not valid");
            }

            bool IsExist = clsUser.IsExistByEmail(email);

            if (!IsExist)
            {
                return NotFound($"User with email {email} not found");
            }

            return Ok(IsExist);
        }

        [HttpGet("IsExist/{id}", Name = "IsExistByID")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> IsExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }
            bool IsExist = clsUser.IsExistByID(id);
            if (!IsExist)
            {
                return NotFound($"User with ID {id} not found");
            }
            return Ok(IsExist);
        }

        [HttpPost("Add", Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDto> AddNewUser(UserDto UserDto)
        {
            if (!UserValidation.ValidateUser(UserDto))
            {
                return BadRequest("Invalid user data");
            }

            clsUser user = new clsUser(UserDto, clsUser.enMode.AddNew);

            if (!user.Save())
            {
                // Handle the error and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the user");
            }

            UserDto.ID = user.ID;

            return CreatedAtRoute("FindUser", new { id = UserDto.ID }, UserDto);
        }


        [HttpPut("Update", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDto> UpdateUser(UserDto UserDto)
        {
            if (!UserValidation.ValidateUserForUpdate(UserDto))
            {
                return BadRequest("Invalid user data");
            }

            clsUser user = new clsUser(UserDto, clsUser.enMode.Update);

            if (!clsUser.IsExistByEmail(user.Email))
            {
                return NotFound($"The user not found");
            }

            if (!user.Save())
            {
                // Handle the error and return a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the user");
            }

            return Ok(user.userDto);
        }
        

        [HttpPatch("ChangePassword", Name = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> ChangePassword(UserChangePasswordDto request)
        {
            if (!UserValidation.ValidateEmail(request.Email))
            {
                return BadRequest("The email is not valid");
            }

            if (!UserValidation.ValidatePassword(request.Password))
            {
                return BadRequest("The password is not valid");
            }

            if (!clsUser.IsExistByEmail(request.Email))
            {
                return NotFound("The user is not found");
            }

            bool IsPasswordChanged = clsUser.ChangeUserPassword(request.Email, request.Password);

            if (!IsPasswordChanged)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while changing user password");
            }

            return Ok(IsPasswordChanged);
        }


    }


}
