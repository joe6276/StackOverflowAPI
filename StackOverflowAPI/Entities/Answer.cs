using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowAPI.Entities
{
    public class Answer
    {

        public int Id { get; set; }
        
        public string Description { get; set; }= string.Empty;

        [ForeignKey("AuthorId")]

        [Required]
        public virtual User users { get; set; }
        public int  AuthorId { get; set; }

        [ForeignKey("QuestionId")]

        [Required]
        public Question Questions { get; set; }
        public int ? QuestionId { get; set; }

        public bool setPreferred { get; set; }=false;
        
        public List<Comment> comments { get; set; } 
        public List<Vote> Votes { get; set; } = new List<Vote>();
    }
}
