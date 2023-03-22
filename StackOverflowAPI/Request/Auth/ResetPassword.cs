using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.Auth
{
    public class ResetPassword
    {
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters!")]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
