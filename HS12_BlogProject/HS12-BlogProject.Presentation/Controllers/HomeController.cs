using HS12_BlogProject.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HS12_BlogProject.Presentation.Controllers
{ 
    public class HomeController : Controller
    {
		public async Task<IActionResult> Index()
		{

			return View(); 
        }

		public IActionResult Create()
		{
			return View();
		}


    }
}