﻿namespace HS12_BlogProject.Presentation.Models.ViewModels.PostVM
{
    public class PostVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string GenreName { get; set; } 
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; } 
        public string ImagePath { get; set; }
        public string FullName => $"{AuthorFirstName} {AuthorLastName}"; 

        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
}
