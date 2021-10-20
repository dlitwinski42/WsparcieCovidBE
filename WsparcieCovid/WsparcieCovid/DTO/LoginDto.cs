﻿using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}