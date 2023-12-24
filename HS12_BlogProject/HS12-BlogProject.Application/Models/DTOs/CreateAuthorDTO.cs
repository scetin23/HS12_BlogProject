using HS12_BlogProject.Application.Extensions;
using HS12_BlogProject.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Models.DTOs
{
	public class CreateAuthorDTO
	{

		public string FirstName { get; set; }

		public string LastName { get; set; }

        public string ImagePath { get; set; }

		[PictureFileExtension]
		public IFormFile? UploadPath { get; set; }

		public DateTime CreateDate => DateTime.Now;

		public Status Status => Status.Active;
	}
}
