using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(await categoryList.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
