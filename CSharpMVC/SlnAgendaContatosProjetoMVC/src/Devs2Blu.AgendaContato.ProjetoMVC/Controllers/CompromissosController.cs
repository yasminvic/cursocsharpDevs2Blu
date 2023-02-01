using Devs2Blu.AgendaContato.ProjetoMVC.Models;
using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Implements;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Controllers
{
    public class CompromissosController : Controller
    {
        private readonly ICompromissoService _service;

        public CompromissosController(ICompromissoService service, ContextoDatabase contexto)
        {
            _service = service;
        }

        // GET: CompromissosController
        public async Task<ActionResult> Index()
        {
            var listCompromissos = await _service.ListarCompromissos();
            return View(listCompromissos);
        }

        // GET: CompromissosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompromissosController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CompromissosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo, Descricao, ContatoId, CEP, Rua, Bairro, Num, Cidade, UF")] Compromisso compromisso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(compromisso);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
            }

            return View(compromisso);
        }

        // GET: CompromissosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompromissosController/Edit/5
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

        // GET: CompromissosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompromissosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
