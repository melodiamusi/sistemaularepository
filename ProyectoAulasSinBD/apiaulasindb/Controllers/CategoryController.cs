using Microsoft.AspNetCore.Mvc;

namespace apiaulasindb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
