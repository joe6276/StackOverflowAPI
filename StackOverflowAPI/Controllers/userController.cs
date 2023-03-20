using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request;
using StackOverflowAPI.Response.User;
using System.Text.Json;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {


        private IMapper _mapper;
        private UserInterface _userInterface;
        private int maxusersPerPage = 25;
        public userController(IMapper mapper, UserInterface userInterface)
        {
                      _mapper= mapper;
                       _userInterface= userInterface;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> getUsers(int pageNumber=1 , int pageSize=5)
        {
            var (users, pagination) = await _userInterface.GetUsersAsync(pageNumber, pageSize);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
            return Ok(users);
            
        
        }

 

        [HttpGet("{id}")]

        public async Task<ActionResult<User>> getUser(int id )
        {
            var currentUser = await _userInterface.GetUserAsync(id);
            if (currentUser == null)
            {
                return BadRequest(new UserUpdateResponse(404, "Not found"));
            }

            return Ok(currentUser);


        }


        [HttpPut("{id}")]


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




        [HttpDelete("{id}")]

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
