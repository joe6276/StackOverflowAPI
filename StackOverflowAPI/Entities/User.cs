using Microsoft.AspNetCore.Components;

namespace StackOverflowAPI.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? VerificationToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

         public string ? PasswordResetToken { get; set; }   

        public DateTime? ResetTokenExpires { get; set; }
        public string Role { get; set; } = "user";
        public List<Question> Questions { get; set; } = new List<Question>();

        
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
