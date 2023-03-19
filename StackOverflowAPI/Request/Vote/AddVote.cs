using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Vote
{
    public class AddVote
    {

        [Required]
        public int AnswerId { get; set; }
    }
}
