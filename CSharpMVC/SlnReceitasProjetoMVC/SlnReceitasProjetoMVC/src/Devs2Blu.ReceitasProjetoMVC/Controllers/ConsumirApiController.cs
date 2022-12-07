using Devs2Blu.ReceitasProjetoMVC.Models;
using Devs2Blu.ReceitasProjetoMVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ReceitasProjetoMVC.Controllers
{
    public class ConsumirApiController : Controller
    {
        private readonly ILogger<ConsumirApiController> _logger;
        private readonly ServiceApi service;

        public ConsumirApiController(ILogger<ConsumirApiController> logger)
        {
            _logger = logger;
            service = new ServiceApi();
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("recipes")]
        public async Task<PartialViewResult> Recipe()
        {
            var result = await service.GetRecipes();
            return PartialView(result);
        }

        [Route("search/{receita}")]
        public async Task<PartialViewResult> Search(string receita)
        {
            var result = await service.GetRecipeByName(receita);
            return PartialView(result);
        }
    }
}