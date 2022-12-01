using Devs2Blu.CopaMundo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.CopaMundo.Controllers
{
    public class ConsultaApiController : Controller
    {
        private readonly ILogger<ConsultaApiController> _logger;

        public ConsultaApiController(ILogger<ConsultaApiController> logger)
        {
            _logger = logger;
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
    }
}