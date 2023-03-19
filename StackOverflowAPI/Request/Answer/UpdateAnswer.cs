using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Answer
{
    public class UpdateAnswer
    {


        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
