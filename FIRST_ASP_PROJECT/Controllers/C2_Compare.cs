using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C2_Compare : Controller
    {
        public IActionResult Index(string chave)
        {
            int key = 123;
            int c = Convert.ToInt32(chave);
            if (chave == null )
            {
                ViewBag.RESPOSTA = null;
            }
            else if (key == c)
            {
                ViewBag.RESPOSTA = "Correto!";
            }
            else
            {
                ViewBag.RESPOSTA = "Errado!";
            }

            return View();
        }
    }
}
