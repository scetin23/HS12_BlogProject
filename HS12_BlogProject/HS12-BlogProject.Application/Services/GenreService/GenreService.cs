using AutoMapper;
using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Domain.Entities;
using HS12_BlogProject.Domain.Enums;
using HS12_BlogProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Services.GenreService
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public GenreService(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task Create(GenreDTO model)
		{
			Genre genre = _mapper.Map<Genre>(model); 
			genre.CreateDate = DateTime.Now;
			genre.Status = Status.Active;
			await _genreRepository.Create(genre); 
		}

		public async Task<GenreDTO> Create()
		{
			return new GenreDTO(); 
		}

		public async Task Delete(int id)
		{
			Genre genre = await _genreRepository.GetDefault(x => x.ID == id); 
			genre.DeleteDate = DateTime.Now; 
			genre.Status = Status.Passive; 

			await _genreRepository.Delete(genre);

		}

		public async Task<GenreDTO> GetById(int id)
		{
			Genre genre = await _genreRepository.GetDefault(x => x.ID == id); 

            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genre);

			return genreDTO;
		}

		public async Task<List<GenreDTO>> GetGenres()
		{
			var genre = await _genreRepository.GetFilteredList(
				select: x => new GenreDTO 
				{
					ID = x.ID, 
					Name = x.Name 
				},
				where: x => x.Status != Status.Passive, 
				orderBy: x => x.OrderBy(x => x.Name) 

				);
			return genre; 
		}

		public async Task Update(GenreDTO model) 
		{
			Genre genre = await _genreRepository.GetDefault(x => x.ID == model.ID);
			if (genre is not null)
			{
				genre.Name = model.Name; 
				genre.UpdateDate = DateTime.Now;
				genre.Status = Status.Modified;

				await _genreRepository.Update(genre);

			}

		}
    }
}
