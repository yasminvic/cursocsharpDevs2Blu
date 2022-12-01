using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models;
using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ProjetosAula.CSharpMVCRevisao.Controllers
{
    [Route("cards")]
    public class CardApiController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServiceAPI service;

        public CardApiController(ILogger<HomeController> logger)
        {
            _logger = logger;
            service = new ServiceAPI();
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("loadcards")]
        public async Task<PartialViewResult> LoadListCards()
        {
            var result = await service.GetListCards();
            //take define quantos coisas tu quer pega da api, por exemplo 20 cartas
            var listCards = result.Take(5).ToList();
            return PartialView(listCards);
        }

    }
}