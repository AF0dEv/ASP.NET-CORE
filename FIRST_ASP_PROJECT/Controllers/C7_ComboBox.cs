using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FIRST_ASP_PROJECT.Controllers
{
    public class C7_ComboBox : Controller
    {
        public IActionResult Index()
        {
            List<string> lista = new List<string>();
            lista.Add("Ciclismo");
            lista.Add("Futebol");
            lista.Add("Natacao");
            ViewBag.LISTA = new SelectList(lista);
            return View();
        }
    }
}
