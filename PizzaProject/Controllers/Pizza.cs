using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaProject.Controllers
{
    public class Pizza : Controller
    {
        public IActionResult Index(bool chkPimento, bool chkCebola, bool chkTomate, string cbxPizza, string txtQuantidade, string txtQuantidadeExtra, string opcao )
        {
            List<string> pizzas = new List<string>();
            pizzas.Add("Pepperoni 10€");
            pizzas.Add("Hawaiian 15€");
            pizzas.Add("Meat Lovers 20€");
            ViewBag.PIZZA = new SelectList(pizzas);

            int Pepperoni = 10;
            int Hawaiian = 15;
            int MeatLovers = 20;
            int Pimento = 3;
            int Cebola = 2;
            int Tomate = 1;
            double totalPizza = 0;
            double totalExtra = 0;
            double total = 0;

            if(cbxPizza == "Pepperoni")
            {
                totalPizza = Pepperoni;
            }
            else if(cbxPizza == "Hawaiian")
            {
                totalPizza = Hawaiian;
            }
            else if(cbxPizza == "Meat Lovers")
            {
                totalPizza = MeatLovers;
            }

            totalPizza = totalPizza * Convert.ToInt16(txtQuantidade);
            @ViewBag.TOTALPIZZA = totalPizza;


            if (chkCebola)
            {
                totalExtra = (totalExtra + Cebola);
            }
            if (chkPimento)
            {
                totalExtra = (totalExtra + Pimento);
            }
            if (chkTomate)
            {
                totalExtra = (totalExtra + Tomate);
            }
            totalExtra = totalExtra  * Convert.ToInt32(txtQuantidadeExtra);


            total = totalPizza + totalExtra;

            if (opcao == "temDesconto")
            {
                total = total - (total * 0.1);
            }

            @ViewBag.TOTALEXTRA = totalExtra.ToString();
            @ViewBag.TOTAL = total.ToString();

            return View();
        }
    }
}
