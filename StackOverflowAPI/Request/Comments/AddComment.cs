using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Comments
{
    public class AddComment
    {

        [Required]
        public int AnswerId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
