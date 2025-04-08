using Microsoft.AspNetCore.Mvc;

namespace Intro_ASP.NET_Core.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}