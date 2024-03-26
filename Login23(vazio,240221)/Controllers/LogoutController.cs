using Microsoft.AspNetCore.Mvc;

namespace Login23.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("UTILIZADOR", "");

            return RedirectToAction("Index", "Login"); 
        }
    }
}
