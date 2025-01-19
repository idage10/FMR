using FlightAlertData.Alert;
using FlightAlertLogic.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System;
using FlightAlertData.User;
using System.Threading.Tasks;

namespace FlightAlertAPI.Controllers
{
    [Route("Users/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserManagementController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                IQueryable<UserDTO> users = _userLogic.GetUsers();

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(users));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: "An error occurred while getting users: " + ex.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] int id)
        {
            try
            {
                UserDTO user = await _userLogic.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(user));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while getting user with id '{id}': " + ex.Message, statusCode: 500);
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                bool isSuccess = await _userLogic.CreateUser(user);
                if (!isSuccess)
                {
                    return Problem(detail: "Failed to create user.", statusCode: 500);
                }

                return CreatedAtAction(nameof(CreateUser), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while creating user with id '{user.UserId}': " + ex.Message, statusCode: 500);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] UserDTO user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch.");
            }

            try
            {
                bool isSuccess = await _userLogic.UpdateUser(user);
                if (!isSuccess)
                {
                    return Problem(detail: "Failed to update user.", statusCode: 500);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while updating user with id '{user.UserId}': " + ex.Message, statusCode: 500);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            try
            {
                bool isSuccess = await _userLogic.DeleteUser(id);
                if (!isSuccess)
                {
                    return Problem(detail: $"Failed to delete user with id {id}.", statusCode: 500);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while deleting user with id '{id}': " + ex.Message, statusCode: 500);
            }
        }
    }
}
