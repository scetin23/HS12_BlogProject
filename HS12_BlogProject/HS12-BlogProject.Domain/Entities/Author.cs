﻿using HS12_BlogProject.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Domain.Entities
{
    public class Author : IBaseEntity
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; } 

        [NotMapped] 
        public IFormFile UploadPath { get; set; } 

        //IBaseEntity
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

		//Navigation
		public List<Post> Posts { get; set; } 


    }
}
