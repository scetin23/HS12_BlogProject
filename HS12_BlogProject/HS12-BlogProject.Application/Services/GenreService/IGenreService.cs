using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Services.GenreService
{
    public interface IGenreService
    {
		Task<GenreDTO> Create();
		Task Create(GenreDTO model);
        Task Update(GenreDTO model);
        Task Delete(int id); 
        Task<GenreDTO> GetById(int id);
		Task<List<GenreDTO>> GetGenres();


	}
}
