using Microsoft.AspNetCore.Mvc;

namespace Login23.Controllers
{
    public class AdministradoresController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("ADMINISTRADOR") == "" || HttpContext.Session.GetString("ADMINISTRADOR") == null || HttpContext.Session.GetString("UTILIZADOR") == "" || HttpContext.Session.GetString("UTILIZADOR") == null)
            {
                HttpContext.Session.SetString("CONTROLADOR", "Administradores");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }

            
        }
    }
}
