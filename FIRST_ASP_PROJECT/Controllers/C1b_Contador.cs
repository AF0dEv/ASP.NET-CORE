using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C1b_Contador : Controller
    {
        public IActionResult Index()
        {
            int soma = 0;
            for (int i = 0; i <= 100; i++)
            {
                soma = soma + i;
            }

            // Enviar ViewBag para View
            ViewBag.soma = soma;

            return View();
        }
    }
}
