using ExCliX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExCliX.Controllers
{
    public class CD1 : Controller
    {
        ApplicationDbContext dbp;
        public CD1(ApplicationDbContext context)
        {
            dbp = context;
        }

        public IActionResult Index(int? cbxClientes)
        {
            ViewBag.LISTACLIENTES = new SelectList(dbp.Tclientes.OrderBy(m => m.Nome), "Id", "Nome");

            if (cbxClientes != null)
            {
                ViewBag.CONTACTOS = dbp.Titems.Where(m => m.ClienteId == cbxClientes).ToList();
            }
            else
            {
                ViewBag.CONTACTOS = "vazio";
            }
            
            
            return View();
        }
    }
}
