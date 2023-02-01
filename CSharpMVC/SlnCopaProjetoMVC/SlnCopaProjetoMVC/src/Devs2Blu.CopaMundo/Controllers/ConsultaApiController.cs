using Devs2Blu.CopaMundo.Models;
using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.CopaMundo.Controllers
{
    public class ConsultaApiController : Controller
    {
        private readonly ILogger<ConsultaApiController> _logger;
        private readonly CopaAPIService service;

        public ConsultaApiController(ILogger<ConsultaApiController> logger)
        {
            _logger = logger;
            service = new CopaAPIService();
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("indexgroups")]
        public IActionResult IndexGroups()
        {
            return View();
        }

        [Route("matches")]
        public async Task<PartialViewResult> Matches()
        {
            var results = await service.GetMatches();
            return PartialView(results);
        }

        [Route("groups")]
        public async Task<PartialViewResult> Groups()
        {
            var results = await service.GetGroups();
            return PartialView(results);
        }
       
    }
}