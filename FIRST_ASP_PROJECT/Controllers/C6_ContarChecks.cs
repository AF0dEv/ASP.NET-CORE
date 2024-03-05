using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C6_ContarChecks : Controller
    {
        public IActionResult Index(bool Ciclismo, bool Futebol, bool Natacao)
        {
            int total = 0;
            if (Ciclismo) total++;
            if (Futebol) total++;
            if (Natacao) total++;

            ViewBag.Total = total;
            return View();
        }
    }
}
