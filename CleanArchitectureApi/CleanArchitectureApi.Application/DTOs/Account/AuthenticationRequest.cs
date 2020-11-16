using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureApi.Application.DTOs.Account
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Password { get; set; }
    }
}
