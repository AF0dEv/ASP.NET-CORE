using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C3_PrecoQtd : Controller
    {
        public IActionResult Index(string quantidade, string preco)
        {
            int total = 0;
            int qtd = Convert.ToInt32(quantidade);
            int p = Convert.ToInt32(preco);
            total = qtd * p;

            

            if (total == 0)
            {
                ViewBag.TOTAL = "";
            }
            else
            {
                ViewBag.TOTAL = total;
            }
            return View();
        }
    }
}
