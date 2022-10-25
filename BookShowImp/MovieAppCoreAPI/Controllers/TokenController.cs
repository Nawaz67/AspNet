using BookMyShowData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using BookMyShowEntity;
using System.Linq;

namespace MovieAppCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MovieDbContext _context;

        public TokenController(IConfiguration config, MovieDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post(User _user)
        {

            if (_user != null && _user.Email != null && _user.Password != null)
            {
                var user = await GetUser(_user.Email, _user.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Phone", user.Phone.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("Password", user.Password),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string Email, string Password)
        {
            User user = null;
            var result = _context.users.Where(u => u.Email == Email && u.Password == Password);
            foreach (var item in result)
            {
                user = new User();
                user.UserId = item.UserId;
                user.UserName = item.UserName;
                user.Phone = item.Phone;
                user.Email = item.Email;
                user.Password = item.Password;
                
            }
            return user;

        }
    }
}
