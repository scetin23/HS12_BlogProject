using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Application.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS12_BlogProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get() 
        {

            return Ok(await _postService.GetPosts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) 
        {

            return Ok(await _postService.GetById(id));

        }

        [HttpGet]
        [Route("GetPostDetails/{id}")]
        public async Task<IActionResult> GetPostDetails(int id) 
        {

            return Ok(await _postService.GetPostDetails(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDTO model) 
        {
            await _postService.Create(model); 
            return Ok("İşlem baraşıyla kaydedilmiştir"); 
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UpdatePostDTO model) 
        {
            await _postService.Update(model); 
            return Ok("İşlem baraşıyla güncellendi."); 
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) 
        {
            await _postService.Delete(id);
            return Ok("Silme işlemi gerçekleşti!");
        }


    }
}
