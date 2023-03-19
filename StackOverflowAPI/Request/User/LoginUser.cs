﻿using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request.User
{
    public class LoginUser
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

      
    }
}
