using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaProject.Controllers
{
    public class Pizza : Controller
    {
        public IActionResult Index(bool chkPimento, bool chkCebola, bool chkTomate, string cbxPizza, string txtQuantidade, string txtQuantidadeExtra, int opcao )
        {
            List<string> pizzas = new List<string>();
            pizzas.Add("Pepperoni");
            pizzas.Add("Hawaiian");
            pizzas.Add("Meat Lovers");
            ViewBag.PIZZA = new SelectList(pizzas);

            int Pepperoni = 10;
            int Hawaiian = 15;
            int MeatLovers = 20;
            int Pimento = 2;
            int Cebola = 1;
            int Tomate = 1;
            int totalPizza = 0;
            int totalExtra = 0;
            int total = 0;

            if(cbxPizza == "Pepperoni")
            {
                totalPizza = Pepperoni * Convert.ToInt32(txtQuantidade);
                @ViewBag.TOTALPIZZA = totalPizza;
            }
            else if(cbxPizza == "Hawaiian")
            {
                totalPizza = Hawaiian * Convert.ToInt32(txtQuantidade);
                @ViewBag.TOTALPIZZA = totalPizza;
            }
            else if(cbxPizza == "Meat Lovers")
            {
                totalPizza = MeatLovers * Convert.ToInt32(txtQuantidade);
                @ViewBag.TOTALPIZZA = totalPizza;
            }

            if (chkCebola)
            {
                totalExtra = totalExtra + (Cebola * Convert.ToInt32(txtQuantidadeExtra));
            }else if(chkPimento)
            {
                totalExtra = totalExtra + (Pimento * Convert.ToInt32(txtQuantidadeExtra));
            }
            else if (chkTomate)
            {
                totalExtra = totalExtra + (Tomate * Convert.ToInt32(txtQuantidadeExtra));
            }

            total = totalPizza + totalExtra;

            if (opcao == 1)
            {
                total = total + (total * 10 / 100);
            }

            @ViewBag.TOTALEXTRA = totalExtra.ToString();
            @ViewBag.TOTAL = total.ToString();

            return View();
        }
    }
}
