using Devs2Blu.AgendaContato.ProjetoMVC.Models.DTO;
using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoService _service;
        public ContatosController(IContatoService service)
        {
            _service = service;
        }

        // GET: ContatosController
        public async Task<ActionResult> Index()
        {
            var listCont = await _service.ListarContatos();
            return View(listCont);
        }

        // GET: ContatosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, Telefone, Email")] Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(contato);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
            }

            return View(contato);
        }

        // GET: ContatosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var contato = await _service.FindById(id);
            return View(new ContatoViewModel () {id = contato.Id, nome = contato.Nome, telefone = contato.Telefone, email = contato.Email });
        }

        // POST: ContatosController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult<string>> ExecuteDelete([Bind("id, nome, telefone, email")] ContatoViewModel contato)
        {
            try
            {
                var resp = await _service.Delete(contato.ToEntity());
                return new ActionResult<string>("OK");
            }
            catch(Exception ex)
            {
                return new ActionResult<string>(ex.Message);
            }
        }
    }
}
