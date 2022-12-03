using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models;
using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models.DTOAPI;
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
            //colocarimos algo dentro do parenteses se o nome da view nao fosse igual ao nome do metodo
        }

        [Route("loadcards")]
        public async Task<PartialViewResult> LoadListCards()
        {
            var result = await service.GetListCards();
            //take define quantos coisas tu quer pega da api, por exemplo 20 cartas
            var listCards = result.Take(5).ToList();
            return PartialView(listCards);
        }

        [Route("search/{nameCard}")]//colocando o parametro nameCard na url
        public async Task<PartialViewResult> SearchCard(string nameCard)
        {
            //pesquisa o card pelo nome
            var card = await service.GetCardByName(nameCard);
            return PartialView(card);
            
        }

    }
}