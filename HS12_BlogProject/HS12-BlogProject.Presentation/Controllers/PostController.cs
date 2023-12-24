using HS12_BlogProject.Presentation.Models.ViewModels.AuthorVM;
using HS12_BlogProject.Presentation.Models.ViewModels.PostVM;
using Microsoft.AspNetCore.Mvc;

namespace HS12_BlogProject.Presentation.Controllers
{
    public class PostController : Controller
    {
        private readonly string _baseAddress = "https://localhost:44382";

        public ActionResult Index()
        {
            List<PostVM> postVMs;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var response = client.GetAsync("api/Post/Get");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadFromJsonAsync<List<PostVM>>();
                    read.Wait();
                    postVMs = read.Result;
                    return View(postVMs);
                }
                else
                {
                    return NotFound();
                }

            }

        }
    }
}
