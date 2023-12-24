using HS12_BlogProject.Presentation.Models.ViewModels.AuthorVM;
using HS12_BlogProject.Presentation.Models.ViewModels.GenreVM;
using Microsoft.AspNetCore.Mvc;

namespace HS12_BlogProject.Presentation.Controllers
{
    public class AuthorController : Controller
    {
        private readonly string _baseAddress = "https://localhost:44382";
        // GET: GenreController
        public ActionResult Index()
        {
            List<AuthorVM> authorVMs;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var response = client.GetAsync("api/Author/GetAuthor");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadFromJsonAsync<List<AuthorVM>>();
                    read.Wait();
                    authorVMs = read.Result;
                    return View(authorVMs);
                }
                else
                {
                    return NotFound();
                }

            }

        }

    }
}
