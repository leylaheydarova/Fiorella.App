using Microsoft.AspNetCore.Mvc;

namespace Fiorella.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
