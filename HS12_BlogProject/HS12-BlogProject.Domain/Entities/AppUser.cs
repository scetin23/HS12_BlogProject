﻿using HS12_BlogProject.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Domain.Entities
{
    public class AppUser : IdentityUser , IBaseEntity
    {

        public string ImagePath { get; set; }

        [NotMapped] 
        public IFormFile UploadPath { get; set; }

		//IBaseEntity
		public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

		//Navigation
		public List<Comment> Comments { get; set; } 
        public List<Like> Likes { get; set; } 

	}
}
