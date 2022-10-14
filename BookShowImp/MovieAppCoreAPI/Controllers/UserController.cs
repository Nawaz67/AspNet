using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _userServices.GetUsers();
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userServices.AddUser(user);
            return Ok("User Added Successfully");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            _userServices.DeleteUser(userId);
            return Ok("User Deleted Successfully");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userServices.UpdateUser(user);
            return Ok("User Updated Successfully");
        }

        [HttpGet("GetUserById")]
        public User GetUserById(int userId)
        {
            return _userServices.UserById(userId);
        }
    }
}
