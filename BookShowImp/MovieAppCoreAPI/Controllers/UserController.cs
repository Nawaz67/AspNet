using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {
            _userServices.Register(user);
            return Ok("User registered successfully");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            User user1=_userServices.Login(user);
            if (user1 != null)
                return Ok("Login Success");
            else
                return NotFound();
        }
    }
}
