using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Response.Answer;
using StackOverflowAPI.Response.Comments;
using StackOverflowAPI.Response.Questions;
using StackOverflowAPI.Response.User;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="admin")]
    public class AdminController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        private readonly questionInterface _questionInterface;
        private readonly answerInterface _answerInterface;
        private readonly commentInterface _commentInterface;
        private readonly Mapper _mapper;


        public AdminController(UserInterface userInterface, questionInterface questionInterface, answerInterface answerInterface, commentInterface commentInterface)
        {
            _userInterface = userInterface;
            _questionInterface = questionInterface;
            _answerInterface = answerInterface;
            _commentInterface = commentInterface;
        }


        [HttpDelete("user/{id}")]

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


        [HttpDelete("question/{id}")]
        public async Task<ActionResult<QuestionsSuccessResponse>> deleteQuestion(int id)
        {
            var currentquestion = await _questionInterface.GetQuestionAsync(id);

            if (currentquestion == null)
            {
                return NotFound("Question Not Found");
            }
            _questionInterface.deleteQuestion(currentquestion);
            await _questionInterface.saveQuestionAsync();

            return Accepted(new QuestionsSuccessResponse(204, "Question Deleted Successfully"));

        }

        [HttpDelete("answer/{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> DeleteAnswer(int id)
        {
            var answer = await _answerInterface.getAnswer(id);

            if (answer == null)
            {
                return BadRequest();
            }
            _answerInterface.removeAnswer(answer);
            await _answerInterface.saveAnswerChangesAsync();
            return Ok(new AnswerSuccessResponse(204, "Answer Deleted"));
        }

        [HttpDelete("comment/{id}")]

        public async Task<ActionResult<CommentResponse>> deleteComments(int id)
        {
            var comment = await _commentInterface.GetCommentAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }

            _commentInterface.deleteCommentAsync(comment);
            await _commentInterface.saveChangesAsync();
            return Ok(new CommentResponse(201, "Comment Deleted  Successfully"));
        }
    }
}
