using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Application.Services.AuthorService;
using HS12_BlogProject.Application.Services.GenreService;
using HS12_BlogProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS12_BlogProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAuthor() 
        {
            return Ok(await _authorService.GetAuthors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByID(int id)
        {
            return Ok(await _authorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDTO model)
        {
            await _authorService.Create(model);
            return Ok("İşlem baraşıyla kaydedilmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UpdateAuthorDTO model)
        {
            await _authorService.Update(model);
            return Ok("İşlem baraşıyla güncellendi.");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return Ok("Silme işlemi gerçekleşti!");
        }

    }
}
