using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = new List<User>
            {
               new User{ Id = 1, Name = "Yasmin Victória", Login = "yasminvic" },
               new User{ Id = 2, Name = "Maria Clara de Souza", Login = "maria" },
               new User{ Id = 3, Name = "Luana Ferreira", Login = "luana" },
               new User{ Id = 4, Name = "Camilla Rosa", Login = "yasminvic" },
               new User{ Id = 5, Name = "Heloisa Loos Pasta", Login = "yasminvic" },
               new User{ Id = 6, Name = "Ana Amorim", Login = "yasminvic" },
            };
            return View(users);
        }

        //rotas pra acessar as views desse controller
        [Route("indicadores")]    
        [Route("numbers")]    
        public IActionResult Indicadores()
        {
            return View();
        }

        //vai carregar só um pedaço do site, sem as estilizações e a pag layout
        [Route("cards")]
        public PartialViewResult CardsResultados()
        {
            return PartialView();
        }
    }
}
