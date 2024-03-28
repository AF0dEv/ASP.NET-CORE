using Microsoft.AspNetCore.Mvc;

namespace Login23.Controllers
{
    public class PrivadaController : Controller
    {
        //[Authorize]

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UTILIZADOR") == "" || HttpContext.Session.GetString("UTILIZADOR") == null)
            {
                HttpContext.Session.SetString("CONTROLADOR", "Privada");
                return RedirectToAction("Index", "C5_Login");
            }
            else
            {
                return View();
            }
        }
    }
}
