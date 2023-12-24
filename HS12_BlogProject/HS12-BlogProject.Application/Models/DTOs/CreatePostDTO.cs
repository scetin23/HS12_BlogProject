using HS12_BlogProject.Application.Extensions;
using HS12_BlogProject.Application.Models.VMs;
using HS12_BlogProject.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Models.DTOs
{
    public class CreatePostDTO
	{
		[Required(ErrorMessage ="Must type Title")]
        [MinLength(3,ErrorMessage = "Minimum lenght 3")] 
        public string Title { get; set; }

        [Required(ErrorMessage = "Must type Content")] 
        [MinLength(3, ErrorMessage = "Minimum lenght 3")]
        public string Content { get; set; }

        public string ImagePath { get; set; }

        [PictureFileExtension] 
        public IFormFile? UploadPath { get; set; } 
		public DateTime CreateDate => DateTime.Now; 
        public Status Status => Status.Active;  

        [Required(ErrorMessage = "Must to type Author")] 
        public int AuthorId { get; set; } 
        [Required(ErrorMessage = "Must to type Genre")]
        public int GenreId { get; set; }
        public List<GenreVM> Genres { get; set; } 
        public List<AuthorVM> Authors { get; set; } 
    }
}
