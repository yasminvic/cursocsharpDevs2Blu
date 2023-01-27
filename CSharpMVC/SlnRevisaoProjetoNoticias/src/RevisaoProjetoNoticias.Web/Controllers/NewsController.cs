using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.IServices;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _service;
        private readonly ICategoryService _categoryService;

        public NewsController(INewsService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var newsList = _service.FindAll();
            return View(newsList);
        }

        public async Task<IActionResult> Details(int id)
        {
            NewsDTO news = await _service.FindById(id);
            return View(news);
        }

        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(),"id", "name", "Selecione...");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsDTO news)
        {
            
            if (ModelState.IsValid)
            {
                news.createdOn = DateTime.Now;
                news.published = true;
                await _service.Save(news);
                return RedirectToAction(nameof(Index));
            }

            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", "Selecione...");
            return View(news);
            
      
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var news = await _service.FindById(id ?? 0);
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", "Selecione...");
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsDTO news)
        {
            if(!(id == news.id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                news.published = true;
                await _service.Save(news);
                return RedirectToAction(nameof(Index));
            }

            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", "Selecione...");
            return View(news);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var news = await _service.FindById(id);

            return View(news);
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(NewsDTO news)
        //{
        //    try
        //    {

        //        await _service.Delete(news);
        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch
        //    {
        //        return View("Index");
        //    }
        //}
    }
}
