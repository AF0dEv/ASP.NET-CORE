using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C4_ModificaC3 : Controller
    {
        public IActionResult Index(string quantidade, string preco)
        {
            double total = 0; 
            double q, p;

            try
            {
                p = Convert.ToDouble(preco);
            }
            catch (Exception)
            {
                p = 0;
            }
            try
            {
                q = Convert.ToDouble(quantidade);
            }
            catch (Exception)
            {
                q = 0;
            }

            total = q * p;
            ViewBag.TOTAL = total;
            

            return View();
        }
    }
}
