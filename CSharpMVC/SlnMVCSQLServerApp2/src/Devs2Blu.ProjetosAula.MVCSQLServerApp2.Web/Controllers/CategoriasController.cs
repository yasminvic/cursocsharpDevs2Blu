using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _service;
        public CategoriasController(ICategoriasService service, ContextoDatabase context)
        {
            //contexto
            _service = service;
        }

        // GET: CategoriasController
        public async  Task<ActionResult> Index()
        {
            //retornando uma lista de categorias do banco (contexto) na index quando carregar
            var listCategorias = await _service.GetAllCategorias();
            return View(listCategorias);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //recebe form do html
        public async Task<IActionResult> Create([Bind("Id,Nome")] Categoria categoria)
        {
            try
            {
                //verifica se tá válido
                if (ModelState.IsValid)
                {
                    //vai pro service (é um metodo da interface que foi implementado na CategoriaService)
                    await _service.Save(categoria); 
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }

            return View(categoria);
        }


        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriasController/Edit/5
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

        // GET: CategoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriasController/Delete/5
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
