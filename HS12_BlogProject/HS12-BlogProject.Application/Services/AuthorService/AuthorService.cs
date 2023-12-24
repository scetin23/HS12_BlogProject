using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Application.Models.VMs;
using HS12_BlogProject.Domain.Entities;
using HS12_BlogProject.Domain.Enums;
using HS12_BlogProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Services.AuthorService
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepository _authorRepository;
		private readonly IGenreRepository _genreRepository;
		private readonly IPostRepository _postRepository;

		public AuthorService(IAuthorRepository authorRepository) 
		{
			_authorRepository = authorRepository;
		}

		public async Task Create(CreateAuthorDTO model)
		{
			Author author = new Author() 
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				ImagePath = model.ImagePath,
			};

			await _authorRepository.Create(author);


			if (model.UploadPath != null)
			{
				Image image = Image.Load(model.UploadPath.OpenReadStream());

				image.Mutate(x => x.Resize(500, 560)); 

				Guid guid = new Guid();

				image.Save($"wwwroot/images/{guid}.jpg");

				author.ImagePath = $"/images/{guid}.jpg"; 
			}
			else
				author.ImagePath = $"/images/defaultpost.jpg"; 

		}

		public async Task<CreateAuthorDTO> CreateAuthor()
		{
			
			return new CreateAuthorDTO();
		}

		public async Task Delete(int id)
		{
			Author author = await _authorRepository.GetDefault(x => x.ID == id); 
			author.DeleteDate = DateTime.Now; 
			author.Status = Status.Passive;

			await _authorRepository.Delete(author); 
		}
		public Task<List<AuthorVM>> GetAuthors()
		{
			return _authorRepository.GetFilteredList(
				select: x => new AuthorVM()
				{
					FirstName = x.FirstName,
					LastName = x.LastName,
					Id = x.ID
				},
				where: x => x.Status != Status.Passive, 
				orderBy: x => x.OrderBy(x => x.FirstName).ThenBy(x=>x.LastName)
				);
		}

		public async Task<UpdateAuthorDTO> GetById(int id)
		{
			Author author = await _authorRepository.GetDefault(x=> x.ID == id);

			return new UpdateAuthorDTO()
			{
				ID = id,
				FirstName = author.FirstName,
				LastName = author.LastName
			};
		}

		public async Task Update(UpdateAuthorDTO model)
		{
			Author author = new Author()
			{
				ID = model.ID,
				FirstName = model.FirstName,
				LastName = model.LastName
			};

			if (model.UploadPath != null)
			{
				Image image = Image.Load(model.UploadPath.OpenReadStream());

				image.Mutate(x => x.Resize(500, 560)); 

				Guid guid = new Guid();

				image.Save($"wwwroot/images/{guid}.jpg");

				author.ImagePath = $"/images/{guid}.jpg"; 
			}
			else
				author.ImagePath = $"/images/defaultpost.jpg"; 


			await _authorRepository.Update(author);
		}
	}
}
