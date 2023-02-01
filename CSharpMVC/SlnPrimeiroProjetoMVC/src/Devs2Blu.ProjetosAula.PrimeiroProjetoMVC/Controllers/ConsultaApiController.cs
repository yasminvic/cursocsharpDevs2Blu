using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    [Route("consulta")]
    public class ConsultaApiController : Controller
    {
        private readonly PokemonAPIService Service = new PokemonAPIService();
        public async Task<IActionResult> Index()
        {
            var result = await Service.GetPokemons();
            return View();
        }

        //vai carregar só um pedaço do site, sem as estilizações e a pag layout
        [Route("pokemons")]
        public PartialViewResult Pokemons()
        {
            var result = Service.GetPokemons();
            return PartialView();
        }
    }
}
