using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request.Answer;
using StackOverflowAPI.Response.Answer;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly answerInterface _answerInterface;
        public AnswerController(answerInterface answerInterface, IMapper mapper)
        {
            _answerInterface = answerInterface;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> getAllAnswers()
        {
            var answers = await _answerInterface.getAnswers();

            return Ok(answers);
        }

        [HttpPost]
        public async Task<ActionResult<AnswerSuccessResponse>> getAllAnswers(AddAnswer newAnswer)
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            if (id == null)
            {
                return BadRequest();
            }
            var answer = _mapper.Map<Answer>(newAnswer);
            answer.AuthorId = int.Parse(id);
            _answerInterface.addAnswer(answer);
            await _answerInterface.saveAnswerChangesAsync();

            return Ok(new AnswerSuccessResponse(201, "Answer Added Successfully"));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> getAnAnswer(int id)
        {
            var answer = await _answerInterface.getAnswer(id);

            if (answer == null)
            {
                return BadRequest();
            }

            return Ok(answer);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> updateAnswer(int id, UpdateAnswer updatedAnswer)
        {
            var answer = await _answerInterface.getAnswer(id);

            if (answer == null)
            {
                return BadRequest();
            }

            _mapper.Map(updatedAnswer, answer);
            await _answerInterface.saveAnswerChangesAsync();
            return Ok(new AnswerSuccessResponse(204, "Answer Updated  Successfully"));
        }



        [HttpPut("preffered/{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> setPreferred(int id)
        {
            var answer = await _answerInterface.getAnswer(id);

            if (answer == null)
            {
                return BadRequest();
            }
            var updated = answer;
            updated.setPreferred = true;
            _mapper.Map(updated, answer);
            await _answerInterface.saveAnswerChangesAsync();
            return Ok(new AnswerSuccessResponse(204, "Answer ser preferred"));
        }


        [HttpPut("ResetPreferred/{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> ResetPreferred(int id)
        {
            var answer = await _answerInterface.getAnswer(id);

            if (answer == null)
            {
                return BadRequest();
            }
            var updated = answer;
            updated.setPreferred = false;
            _mapper.Map(updated, answer);
            await _answerInterface.saveAnswerChangesAsync();
            return Ok(new AnswerSuccessResponse(204, "Answer Reset"));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<AnswerSuccessResponse>> DeleteAnswer(int id)
        {
            var answer = await _answerInterface.getAnswer(id);
            var userid = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            var userIdint = int.Parse(userid);
            if (answer == null || answer.AuthorId!=userIdint)
            {
                return BadRequest("Not Allowed");
            }
            _answerInterface.removeAnswer(answer);
            await _answerInterface.saveAnswerChangesAsync();
            return Ok(new AnswerSuccessResponse(204, "Answer Deleted"));
        }



    }
}
