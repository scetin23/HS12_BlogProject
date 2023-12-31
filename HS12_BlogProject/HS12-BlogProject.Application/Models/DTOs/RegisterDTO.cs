﻿using HS12_BlogProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Models.DTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; } 
        public string Email { get; set; }
        public DateTime CreateDate => DateTime.Now; 
        public Status Status => Status.Active; 


    }
}
