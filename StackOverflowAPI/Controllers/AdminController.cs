using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Response.Questions;
using StackOverflowAPI.Response.User;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="admin")]
    public class AdminController : ControllerBase
    {
        //private readonly UserInterface _userInterface;
        //private readonly questionInterface _questionInterface;
        //private readonly answerInterface _answerInterface;
        //private readonly commentInterface _commentInterface;
        //private readonly Mapper _mapper;


        //public AdminController(UserInterface userInterface, questionInterface questionInterface, answerInterface answerInterface, commentInterface commentInterface)
        //{
        //    _userInterface= userInterface;
        //    _questionInterface= questionInterface;
        //    _answerInterface= answerInterface;
        //    _commentInterface= commentInterface;
        //}


        //[HttpDelete("{id}")]

        //public async Task<ActionResult<UserDeleteResponse>> deleteUser(int id)
        //{
        //    var currentUser = await _userInterface.GetUserAsync(id);
        //    if (currentUser == null)
        //    {
        //        return BadRequest(new UserDeleteResponse(404, "Not found"));
        //    }

        //    _userInterface.RemoveUserAsync(currentUser);
        //    await _userInterface.SaveChangesAsync();
        //    return Ok(new UserDeleteResponse(204, "User Deleted Successfully"));
        //}


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<QuestionsSuccessResponse>> deleteQuestion(int id)
        //{
        //    var currentquestion = await _questionInterface.GetQuestionAsync(id);

        //    if (currentquestion == null)
        //    {
        //        return NotFound("Question Not Found");
        //    }
        //    _questionInterface.deleteQuestion(currentquestion);
        //    await _questionInterface.saveQuestionAsync();

        //    return Accepted(new QuestionsSuccessResponse(204, "Question Updated Successfully"));

        //}
    }
}
