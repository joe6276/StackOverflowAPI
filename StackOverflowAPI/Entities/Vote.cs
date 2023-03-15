using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowAPI.Entities
{
    public class Vote
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User userss { get; set; } 

        public int UserId { get; set; }

        [ForeignKey("AnswerId")]
        public virtual Answer answer { get; set; }

        public int AnswerId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Count { get; set; } = 0;
    }
}
