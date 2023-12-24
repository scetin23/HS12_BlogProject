using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Application.Models.VMs;
using HS12_BlogProject.Application.Services.GenreService;
using HS12_BlogProject.Domain.Entities;
using HS12_BlogProject.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HS12_BlogProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]  
    public class GenreController : Controller
    {

        private readonly IGenreService _genreService; 

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]

        public async Task<IActionResult> Get() 
        {
            return Ok(await _genreService.GetGenres());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) 
        {

            return Ok(await _genreService.GetById(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreDTO model) 
        {
            await _genreService.Create(model); 
            return Ok("İşlem baraşıyla kaydedilmiştir"); 
        }

        [HttpPut]
        public async Task<IActionResult> Edit(GenreDTO model) 
        {
            await _genreService.Update(model); 
            return Ok("İşlem baraşıyla güncellendi."); 
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) 
        {
            await _genreService.Delete(id);
            return Ok("Silme işlemi gerçekleşti!");
        }


    }
}
