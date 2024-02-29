using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class classTest : Controller
    {
        public IActionResult Index()
        {
            ViewBag.NOME = "REI DO GADO";
            return View();
        }
    }
}
