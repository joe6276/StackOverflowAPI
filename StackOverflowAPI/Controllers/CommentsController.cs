using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Request.Comments;
using StackOverflowAPI.Response.Comments;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly commentInterface _commentInterfaces;
        public CommentsController(IMapper mapper , commentInterface comment)
        {
            _mapper=mapper; 
            _commentInterfaces=comment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> getCommentsAsync()
        {
            var comments= await _commentInterfaces.GetCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> getCommentbyId(int id)
        {
            var comment = await _commentInterfaces.GetCommentAsync(id);
            
            if(comment==null)
            {
                return BadRequest();
            }

            return Ok(comment);
        }
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> addComment(AddComment comment)
        {
          var newComment=  _mapper.Map<Comment>(comment);

            var id = User.Claims.FirstOrDefault(c => c.Type == "Uid")?.Value;
            newComment.UserId=int.Parse(id);
            _commentInterfaces.AddComment(newComment);
            await _commentInterfaces.saveChangesAsync();
            return Ok(new CommentResponse(201, "Comment Created Successfully"));
          
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<CommentResponse>> updateComments(UpdateComment updatedComment , int id)
        {
            var comment = await _commentInterfaces.GetCommentAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }
             _mapper.Map(updatedComment, comment);
            await _commentInterfaces.saveChangesAsync();
            return Ok(new CommentResponse(201, "Comment Updated  Successfully"));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CommentResponse>> deleteComments(int id)
        {
            var comment = await _commentInterfaces.GetCommentAsync(id);

            if (comment == null)
            {
                return BadRequest();
            }
          
            _commentInterfaces.deleteCommentAsync(comment); 
            await _commentInterfaces.saveChangesAsync();
            return Ok(new CommentResponse(201, "Comment Deleted  Successfully"));
        }
    }
}
