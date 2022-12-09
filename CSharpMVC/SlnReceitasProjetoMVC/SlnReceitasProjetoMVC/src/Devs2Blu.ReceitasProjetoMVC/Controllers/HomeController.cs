using Devs2Blu.ReceitasProjetoMVC.Models;
using Devs2Blu.ReceitasProjetoMVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ReceitasProjetoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServiceApi service;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            service = new ServiceApi();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("banner")]
        public async Task<PartialViewResult> Banner()
        {
            var result = await service.GetRandomRecipe();
            var listRecipe = result.Take(3).ToList();
            return PartialView(listRecipe);
        }
    }
}