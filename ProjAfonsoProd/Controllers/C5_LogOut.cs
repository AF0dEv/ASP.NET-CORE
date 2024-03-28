using Microsoft.AspNetCore.Mvc;

namespace ProjAfonsoProd.Controllers
{
    public class C5_LogOut : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("UTILIZADOR", "");

            return RedirectToAction("Index", "C5_Login");
        }
    }
}
