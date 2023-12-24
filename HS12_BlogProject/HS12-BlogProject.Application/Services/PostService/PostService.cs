using AutoMapper;
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

namespace HS12_BlogProject.Application.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository; 
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

		public PostService(IPostRepository postRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task Create(CreatePostDTO model)
        {
            Post post= _mapper.Map<Post>(model);
            
			if (model.UploadPath != null)
            {
                Image image = Image.Load(model.UploadPath.OpenReadStream());

                image.Mutate(x => x.Resize(600, 560)); 

                Guid guid = new Guid();

                image.Save($"wwwroot/images/{guid}.jpg");

                post.ImagePath = $"/images/{guid}.jpg"; 
            }
            else
                post.ImagePath = $"/images/defaultpost.jpg"; 


            await _postRepository.Create(post);
        }
        public async Task<CreatePostDTO> CreatePost()
        {
            CreatePostDTO model = new CreatePostDTO()
            {
                Genres = await _genreRepository.GetFilteredList(
                    select: x => new GenreVM
                    {
                        Id = x.ID,
                        Name = x.Name
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderBy(x => x.Name)
                    ),

                Authors = await _authorRepository.GetFilteredList(
                    select: x => new AuthorVM
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderBy(x => x.FirstName)
                    )


            };
            return model;
        }

        public async Task Delete(int id)
        {
			Post post = await _postRepository.GetDefault(x => x.ID == id); 
			post.DeleteDate = DateTime.Now;
			post.Status = Status.Passive;

			await _postRepository.Delete(post); 
		}

        public async Task<UpdatePostDTO> GetById(int id)
        {

            Post post = await _postRepository.GetDefault(x => x.ID == id); 
			var model= _mapper.Map<UpdatePostDTO>(post); 
            {
                model.Authors = await _authorRepository.GetFilteredList(
                    select: x => new AuthorVM()
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderBy(x => x.FirstName)
                ); 


                model.Genres = await _genreRepository.GetFilteredList(
                    select: x => new GenreVM()
                    {
                        Id = x.ID,
                        Name = x.Name

                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderBy(x => x.Name)
                    );
                return model;

            };

		}
		public async Task<PostDetailsVM> GetPostDetails(int id)
		{
            var post = await _postRepository.GetFilteredFirstOrDefault( 
                select: x => new PostDetailsVM 
                {
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName,
                    AuthorImagePath = x.Author.ImagePath,
                    Content = x.Content,
                    CreateDate = x.CreateDate,
                    ImagePath = x.ImagePath,
                    Title = x.Title,

                },
                where: (x => x.ID == id),

                orderBy: null,
                include: x => x.Include(x => x.Author) 


                ) ;
            return post;
		}
		public async Task<List<PostVM>> GetPosts()
        {
            return await _postRepository.GetFilteredList(
                select: x=> new PostVM
                {
                    AuthorFirstName=x.Author.FirstName,
                    AuthorLastName=x.Author.LastName,
                    Id = x.ID,
                    Title=x.Title,
                    GenreName=x.Genre.Name,
                },
				where: x => x.Status != Status.Passive, 
				orderBy: x => x.OrderByDescending(x => x.CreateDate), 
                include: x=>x.Include(x=>x.Genre)
                             .Include(x=>x.Author)
                
                );
        }
		public async Task Update(UpdatePostDTO model)
        {
            Post post = new Post()
            {
                AuthorID = model.AuthorId,
                Content = model.Content,
                GenreID = model.GenreId,
                ImagePath=model.ImagePath,
                Title = model.Title,
                UpdateDate = model.UpdateDate,
            };

			if (model.UploadPath != null)
			{

				Image image = Image.Load(model.UploadPath.OpenReadStream());

				image.Mutate(x => x.Resize(600, 560)); 

				Guid guid = new Guid();

				image.Save($"wwwroot/images/{guid}.jpg");

				post.ImagePath = $"/images/{guid}.jpg"; 
			}
			else
				post.ImagePath = $"/images/defaultpost.jpg"; 


			await _postRepository.Update(post);

		}
	}
}
