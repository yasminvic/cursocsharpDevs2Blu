using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    [Route("admin")]
    public class ConsultaApiController : Controller
    {
        private readonly PokemonAPIService Service = new PokemonAPIService();
        public IActionResult Index()
        {
            var result = Service.GetPokemons();
            return View();
        }

        //rotas pra acessar as views desse controller    
        [Route("consulta")]    
        public IActionResult Indicadores()
        {
            return View();
        }

        //vai carregar só um pedaço do site, sem as estilizações e a pag layout
        [Route("pokemons")]
        public PartialViewResult Pokemons()
        {
            var result = ServiceCollection.GetList();
            return PartialView();
        }
    }
}
