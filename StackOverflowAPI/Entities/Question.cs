using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowAPI.Entities
{
    public class Question
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string Tags { get; set; } = string.Empty;

        [ForeignKey("Author")]
        public User user { get; set; } 
        public int Author  {get;set;}

        List<Answer> Answers { get; set; }= new List<Answer>();
    }
}
