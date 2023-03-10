using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.IdentityModel.Tokens;    
using System.IdentityModel.Tokens.Jwt;    
using System.Text;    
    
namespace JWTAuthentication.Controllers    
{    
    [Route("api/[controller]")]    
    [ApiController]    
    public class LoginController : Controller    
    {    
        private IConfiguration _config;    
    
        public LoginController(IConfiguration config)    
        {    
            _config = config;    
        }    

        [AllowAnonymous]    
        [HttpPost]    
        public IActionResult Login([FromBody]User login)    
        {    
            IActionResult response = Unauthorized();    
            var user = AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { status = 200, token = tokenString });    
            }    
    
            return response;    
        }    

        // Generate Authentication Token
        private string GenerateJSONWebToken(User userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
                _config["Jwt:Issuer"],    
                null,    
                expires: DateTime.Now.AddMinutes(120),    
                signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        //Validate the User Credentials    
        private User AuthenticateUser(User login)    
        {    
            User user = null;    

            // A secured database, preferablly SMSS TSQL is required to securely store user and password
            if (login.EmailAddress == "test@gmail.com" & login.Password == "password123")    
            {    
                user = new User { Username = "Johnny", EmailAddress = "test@gmail.com" };    
            }    

            return user;    
        }    
    }    
}   

