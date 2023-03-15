using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request;
using StackOverflowAPI.Response.User;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private IMapper _mapper;
        private UserInterface _userInterface;
        public userController(IMapper mapper, UserInterface userInterface)
        {
                      _mapper= mapper;
                       _userInterface= userInterface;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> getUsers()
        {
            var users = await _userInterface.GetUsersAsync();
            return Ok(users);
            
        
        }
        [HttpGet("id")]
        public async Task<ActionResult<User>> getUser(int id )
        {
            var currentUser = await _userInterface.GetUserAsync(id);
            if (currentUser == null)
            {
                return BadRequest(new UserUpdateResponse(404, "Not found"));
            }

            return Ok(currentUser);


        }




        [HttpPut("id")]

        public async Task <ActionResult<UserUpdateResponse>> updateUsers(UserUpdateRequest user, int id)
        {
            var currentUser= await _userInterface.GetUserAsync(id);
            if(currentUser == null)
            {
                return BadRequest(new UserUpdateResponse(404, "Not found"));
            }
            _mapper.Map(user ,currentUser);
            await _userInterface.SaveChangesAsync();
            return Ok(new UserUpdateResponse(204, "User Updated Successfully"));
        }


        [HttpDelete("id")]
        public async Task<ActionResult<UserDeleteResponse>> deleteUser(int id)
        {
            var currentUser = await _userInterface.GetUserAsync(id);
            if (currentUser == null)
            {
                return BadRequest(new UserDeleteResponse(404, "Not found"));
            }

            _userInterface.RemoveUserAsync(currentUser);
            await _userInterface.SaveChangesAsync();    
            return Ok(new UserDeleteResponse(204, "User Deleted Successfully"));
        }
    }
}
