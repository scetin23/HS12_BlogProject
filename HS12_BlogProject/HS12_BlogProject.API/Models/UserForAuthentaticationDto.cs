﻿using System.ComponentModel.DataAnnotations;

namespace HS12_BlogProject.API.Models
{
    public class UserForAuthentaticationDto
    {
        [Required(ErrorMessage = "username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}
