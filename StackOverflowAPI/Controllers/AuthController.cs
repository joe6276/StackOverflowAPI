using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request;
using StackOverflowAPI.Request.User;
using StackOverflowAPI.Response.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthController(IMapper mapper, UserInterface userInterface, IConfiguration configuration)
        {
            _mapper= mapper;
            _userInterface= userInterface;
            _configuration= configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserAddResponse>> AddUsers(UserAdd user)
        {
            var userInstance = _mapper.Map<User>(user);
            userInstance.Password =  BCrypt.Net.BCrypt.HashPassword(user.Password);
            _userInterface.AddUserAsync(userInstance);
            await _userInterface.SaveChangesAsync();
            return Ok(new UserAddResponse(201, "User Created Successfully"));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginSuccess>> LoginUser (LoginUser user)
        {
            var currentUser = await _userInterface.GetUserByEmail(user.Email);

            if(currentUser == null)
            {
                return BadRequest("User not Found");
            }

            var valid = BCrypt.Net.BCrypt.Verify(user.Password, currentUser.Password);
            if(!valid)
            {
                return BadRequest("User not Found");
            }

            var token = CreateToken(currentUser);
            return Ok(new LoginSuccess("User Logged in !", token, 200));

        }

        private string CreateToken(User user)
        {   

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Name", user.Name));
            claims.Add(new Claim("Uid", user.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               _configuration["Authentication:Issuer"],
              _configuration["Authentication:Audience"],
              claims,
              DateTime.UtcNow,
              signingCredentials: cred,
              expires: DateTime.Now.AddHours(3)
              );

             var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

    }
}
