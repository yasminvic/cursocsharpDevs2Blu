using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.IServices;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _service;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            //To list all categories
            //Get of CategoryService through DI (Injenção de dependencia) (ICategoryService)
            //no ICategoryService já passamos o tipo da classe, por isso nao precisa colocar aqui dnv
            var categoryList = _service.FindAll(); 
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var category = await _service.FindById(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(category);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var category = await _service.FindById(id ?? 0);//se id for nulo recebe 0
                                                   //é um operador binario, existe o terciário tbm
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,CategoryDTO category)
        {
            if(!(id == category.id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Save(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var category = await _service.FindById(id);

            return View(category);
        }

        //dando errado
        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            if (await _service.Delete(id ?? 0) <= 0)
            {
                retDel = new ReturnJsonDel
                {
                    status = "Error",
                    code = "400"
                };
            }
            return Json(retDel);
            


            //if (ModelState.IsValid)
            //{
            //    var resp = await _service.Delete(id);
            //    return RedirectToAction(nameof(Index));
            //}
        }
    }

    public class ReturnJsonDel
    {
        public string status { get; set; }
        public string code { get; set; }
    }
}
