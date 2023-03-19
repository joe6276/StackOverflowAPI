using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request.Vote;
using StackOverflowAPI.Response.Votes;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VotesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly VoteInterface _voteInterface;
        public VotesController(VoteInterface voteInterface, IMapper mapper)
        {
                _voteInterface= voteInterface;
                 _mapper= mapper;
        }


        [HttpPost]
   
        public async Task <ActionResult<VoteSuccess>> upvote(AddVote vote)
        {
            var votes = await _voteInterface.getVotesByAnswerIdAsync(vote.AnswerId);
            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            var existingVotes = await _voteInterface.getVotesByAnswerId(vote.AnswerId);
            if (id == null)
            {
                return BadRequest();
            }
            var updatedvotes = _mapper.Map<Vote>(vote);
            updatedvotes.UserId = Int32.Parse(id);
            updatedvotes.AnswerId = vote.AnswerId;
            updatedvotes.Count = votes + 1;
            var ifvoted = await _voteInterface.CheckifVoted(int.Parse(id), vote.AnswerId);

            if(ifvoted != null)
            {
                return BadRequest("You cant Vote Twice");
            }
                _voteInterface.AddVote(updatedvotes);
                await  _voteInterface.SaveChangesAsync();    

            return Ok(new VoteSuccess(201,"Vote Added"));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VoteCount>> getAllVotes(int id)
        {
            var votes = await _voteInterface.getVotesByAnswerIdAsync(id);
            return Ok(new VoteCount(200,votes));
        }
        

        [HttpDelete("Down/{answerId}")]
        public async Task<ActionResult<VoteSuccess>> DownVote(int answerId)
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            var ifvoted = await _voteInterface.CheckifVoted(int.Parse(id),answerId);

            if (ifvoted == null)
            {
                return BadRequest("You cant Vote Twice");
            }
            _voteInterface.deleteVotes(ifvoted);
            await _voteInterface.SaveChangesAsync();

            return Ok(new VoteSuccess(204,"Vote Removed Successfully"));
        }

    }
}
