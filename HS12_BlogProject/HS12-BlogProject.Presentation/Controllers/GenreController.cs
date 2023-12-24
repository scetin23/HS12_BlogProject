 
using HS12_BlogProject.Presentation.Models.ViewModels.GenreVM;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace HS12_BlogProject.Presentation.Controllers
{
    public class GenreController : Controller
    {
        private readonly string _baseAddress = "https://localhost:44382"; 

        public ActionResult Index()
        {
            List<GenreVM> genreVMs; 

            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(_baseAddress); 

                var response = client.GetAsync("api/Genre");
                response.Wait();
              
                var result = response.Result; 
                if (result.IsSuccessStatusCode) 
                {
                    var read = result.Content.ReadFromJsonAsync<List<GenreVM>>();
                    read.Wait(); 
                    genreVMs = read.Result; 
                    return View(genreVMs);
                }
                else
                {
                    return NotFound();
                }

            }

        }
    }
}
