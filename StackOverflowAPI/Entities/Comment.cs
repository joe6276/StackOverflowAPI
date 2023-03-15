using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowAPI.Entities
{
    public class Comment
    {

        public int Id { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; } =  string.Empty;

        [ForeignKey("AnswerId")]
        [Required]
        public Answer answers { get; set; }
        public int AnswerId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public virtual User users { get; set; }

        public int UserId { get; set; }

    }
}
