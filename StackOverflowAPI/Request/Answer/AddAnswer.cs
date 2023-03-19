using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Answer
{
    public class AddAnswer
    {

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int QuestionId { get; set; }

    }
}
