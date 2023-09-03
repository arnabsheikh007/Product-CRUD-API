using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Product_CRUD_API.Models;
using Product_CRUD_API.Services.AuthServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Product_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public static User user = new User();
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration,IAuthService authService)
        {
            this._configuration = configuration;
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequest request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserNameOrEmailAddress = request.UserNameOrEmailAddress;
            user.PasswordHash = passwordHash;

            return Ok(await _authService.Register(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserRequest request)
        {
            var user = await _authService.Login(request);
            if (user is null)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserNameOrEmailAddress),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
