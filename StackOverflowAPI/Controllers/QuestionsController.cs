using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request.Question;
using StackOverflowAPI.Response.Questions;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly questionInterface _questionInterface;

        public QuestionsController(IMapper mapper, questionInterface question)
        {
            _mapper = mapper;
            _questionInterface = question;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> getAllQuestions()
        {
            var questions = await _questionInterface.GetQuestionsAsync();
            if (questions == null)
            {
                return NotFound("No Questions Found");
            }
            return Ok(questions);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionsSuccessResponse>> addQuestion(AddQuestion question)
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;

            var quiz = _mapper.Map<Question>(question);
            quiz.Author = int.Parse(id);

            _questionInterface.AddQuestion(quiz);
            await _questionInterface.saveQuestionAsync();

            return Ok(new QuestionsSuccessResponse(201, "Question Added Successfully"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> getAQuestion(int id)
        {

            var question = await _questionInterface.GetQuestionAsync(id);

            if (question == null)
            {
                return NotFound("Question Not Found");
            }

            return Ok(question);
        }

        [HttpGet("currentUser")]
        public async Task<ActionResult<IEnumerable<Question>>> GetCurrentUserQuestions() 
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            var question = await _questionInterface.getUserQuestions(int.Parse(id));

            if (question == null)
            {
                return NotFound("User has No questions");
            }

            return Ok(question);
        }

        [HttpPut("{id}")]
         public async Task<ActionResult<QuestionsSuccessResponse>> updateQuestion(int id, AddQuestion question)
        {
            var currentquestion = await _questionInterface.GetQuestionAsync(id);

            if (currentquestion == null)
            {
                return NotFound("Question Not Found");
            }
            _mapper.Map(question, currentquestion);
            await _questionInterface.saveQuestionAsync();

            return Accepted(new QuestionsSuccessResponse(204, "Question Updated Successfully"));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionsSuccessResponse>> deleteQuestion(int id)
        {
            var currentquestion = await _questionInterface.GetQuestionAsync(id);
            var userid = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            var userIdint = int.Parse(userid);
            if (currentquestion == null || currentquestion.Author !=userIdint)
            {
                return NotFound("Not Allowed");
            }
            _questionInterface.deleteQuestion(currentquestion);
            await _questionInterface.saveQuestionAsync();

            return Accepted(new QuestionsSuccessResponse(204, "Question Deleted Successfully"));

        }
    }
}
