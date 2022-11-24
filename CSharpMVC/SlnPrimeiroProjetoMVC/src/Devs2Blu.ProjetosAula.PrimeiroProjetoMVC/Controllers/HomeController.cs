using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    //[Route("")] //rota
    //[Route("home")]
    //quando carregar e estiver em branco, vai carregar a home
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Teste"); //chamando o arq teste.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("home/cadastro")]
        [Route("cadastre-se")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}