using Microsoft.AspNetCore.Mvc;

namespace Login23.Controllers
{
    public class PublicaController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("CONTROLADOR", "Publica");
            return View();
        }
    }
}
