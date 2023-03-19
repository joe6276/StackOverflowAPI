using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Vote
{
    public class UpdateVote
    {

        [Required]
        public int AnswerId { get; set; }

        [Required]
        public int Count { get; set; } = 0;
    }
}
