﻿using System.ComponentModel.DataAnnotations;

namespace StackOverflowAPI.Request
{
    public class UserUpdateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
