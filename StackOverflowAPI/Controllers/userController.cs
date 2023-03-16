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
<<<<<<< Updated upstream
        [HttpGet("id")]
=======
        [HttpGet("{id}")]
>>>>>>> Stashed changes
        public async Task<ActionResult<User>> getUser(int id )
        {
            var currentUser = await _userInterface.GetUserAsync(id);
            if (currentUser == null)
            {
                return BadRequest(new UserUpdateResponse(404, "Not found"));
            }

            return Ok(currentUser);


        }


<<<<<<< Updated upstream


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


<<<<<<< Updated upstream
        [HttpDelete("id")]
=======
        [HttpDelete("{id}")]
>>>>>>> Stashed changes
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
