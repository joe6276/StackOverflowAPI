using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Question
{
    public class AddQuestion
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        public AddQuestion(string title, string description)
        {
            Title = title;
            Description= description;
        }
    }
}
