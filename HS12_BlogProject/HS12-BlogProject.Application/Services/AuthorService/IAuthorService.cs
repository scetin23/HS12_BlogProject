using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Services.AuthorService
{
	public interface IAuthorService
	{
		Task Create(CreateAuthorDTO model);
		Task Update(UpdateAuthorDTO model);
		Task Delete(int id);
		Task<UpdateAuthorDTO> GetById(int id);
		Task<List<AuthorVM>> GetAuthors();
		Task<CreateAuthorDTO> CreateAuthor(); 

	}
}
