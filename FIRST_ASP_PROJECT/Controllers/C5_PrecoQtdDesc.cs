using Microsoft.AspNetCore.Mvc;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C5_PrecoQtdDesc : Controller
    {
        public IActionResult Index(string quantidade, string preco, int opcao)
        {
            double total = 0;
            double q, p, d;
            d = 0.1;
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
           
            

            if (opcao == 1)
            {
                total = q * p;
            }
            else if (opcao == 2)
            {
                total = q * p;
                double desconto = total * d;
                total = total - desconto;
            }
            
            ViewBag.TOTAL = total;

            return View();
        }
    }
}
