using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AMS.Dal;
using AMS.Dal.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using AssetsManagementsSystems.DAL;

namespace AMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AssetDbContext _dbContext;

        public LoginController(IConfiguration config, AssetDbContext dbContext)                          
        {
            _config = config;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost]//deserialize reqestbody
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { Token = token });
            }

            return NotFound("User not found");
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));//define the security key for token genration
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//create  signing credentials

            var claims = new List<Claim>              //defines claim for tokens
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], //create jwt token  with provider issuer 
                _config["Jwt:Audience"],//set audience for the token
                claims,//set claim for token
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);  //stri
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username.ToLower() == userLogin.Username.ToLower() && u.Password == userLogin.Password);
        }
    }
}








