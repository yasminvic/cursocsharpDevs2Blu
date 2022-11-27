using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetoFriends.Controllers
{
    public class GaleriaController : Controller
    {
        [Route("galeria")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
