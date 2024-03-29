﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StackOverflowAPI.EmailServices;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request;
using StackOverflowAPI.Request.Auth;
using StackOverflowAPI.Request.Email;
using StackOverflowAPI.Request.User;
using StackOverflowAPI.Response.Auth;
using StackOverflowAPI.Response.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly EmailInterface _emailInterface;
        public AuthController(IMapper mapper, UserInterface userInterface, IConfiguration configuration, EmailInterface emailInterface)
        {
            _mapper = mapper;
            _userInterface = userInterface;
            _configuration = configuration;
            _emailInterface = emailInterface;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserAddResponse>> AddUsers(UserAdd user)
        {   

            var checkUser = await _userInterface.GetUserByEmail(user.Email);

            if(checkUser != null) {

                return BadRequest(new AuthResponse(400, "Email in Use Already "));
            }

            var userInstance = _mapper.Map<User>(user);
            userInstance.Password =  BCrypt.Net.BCrypt.HashPassword(user.Password);
                 var token = CreateRandomToken();
            userInstance.VerificationToken= token;
            _userInterface.AddUserAsync(userInstance);
            await _userInterface.SaveChangesAsync();
            // send user an Email
            var verify = new Verify(user.Name, token);
            var email = new EmailDto(user.Email, verify.getTemplate(), "Verify User");
            _emailInterface.sendEmail(email);
            return Ok(new UserAddResponse(201, "User Created Successfully"));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginSuccess>> LoginUser (LoginUser user)
        {
            var currentUser = await _userInterface.GetUserByEmail(user.Email);

            if(currentUser == null)
            {
                return BadRequest(new AuthResponse(400, "Invalid Credentials"));
            }

            var valid = BCrypt.Net.BCrypt.Verify(user.Password, currentUser.Password);
            if(!valid)
            {
                return BadRequest(new AuthResponse(400, "Invalid Credentials"));
            }

            if (currentUser.VerifiedAt == null)
            {
                return BadRequest("Please Verify First");
            }

            var token = CreateToken(currentUser);
            return Ok(new LoginSuccess("User Logged in !", token, 200));

        }

        [HttpPost("verify")]

        public async Task<ActionResult<AuthResponse>> VerifyUser( string token)
        {
            var user = await _userInterface.GetUserByTokenAsync(token);

            if(user == null)
            {
                return BadRequest( new AuthResponse(400, "user Not Found" ));
            }

            if(user.VerifiedAt != null)
            {
                return Ok(new AuthResponse(204, "You already Verified"));
            }

            user.VerifiedAt =DateTime.Now;
            await _userInterface.SaveChangesAsync();


            return Ok( new AuthResponse(200, "user successfully Verified"));
        }
        [HttpPost("forgot")]

        public async Task<ActionResult<AuthResponse>> forgotPassword (ForgotRequest request )
        {
            var user =await _userInterface.GetUserByEmail(request.Email);
            var resetToken = CreateRandomToken();
            if (user == null)
            {
                return BadRequest(new AuthResponse(400, "user Not Found"));
            }
            var forgot = new ForgotPassword(user.Name, resetToken);
            var emailToSent = new EmailDto(user.Email,forgot.getTemplate(),"Password Reset" );
            _emailInterface.sendEmail(emailToSent);

         

            user.PasswordResetToken = resetToken;
            user.ResetTokenExpires= DateTime.Now.AddHours(3);   
            await _userInterface.SaveChangesAsync();

           
            return Ok(new AuthResponse(200, "User password Reset"));

        }

        [HttpPost("reset")]

        public async Task<ActionResult<AuthResponse>> resetPassword(string resetToken, ResetPassword resetPassword)
        {
            var user = await _userInterface.GetUserByResetTokenAsync(resetToken);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest(new AuthResponse(400, "user Not Found"));
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(resetPassword.Password);
            user.PasswordResetToken = null;
            user.ResetTokenExpires=null;
            await _userInterface.SaveChangesAsync();
            return Ok(new AuthResponse(200, "Password Updated Successfully"));


        }
        private string CreateToken(User user)
        {   

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Name", user.Name));
            claims.Add(new Claim("Roles", user.Role));
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

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

    }
}
