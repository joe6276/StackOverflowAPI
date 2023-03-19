using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Comments
{
    public class UpdateComment
    {

        [Required]
        public string Description { get; set; }
    }
}
