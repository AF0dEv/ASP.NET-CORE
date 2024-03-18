using ExCliX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExCliX.Controllers
{
    public class CD2 : Controller
    {
        ApplicationDbContext dbp;
        public CD2(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index(string? txtNome)
        {
            if (txtNome != null)
            {
                ViewBag.LISTACLIENTES = new SelectList(dbp.Tclientes.Where(c => c.Nome.Contains(txtNome)), "Id", "Nome");
            }
            else
            {
                ViewBag.LISTACLIENTES = new SelectList(dbp.Tclientes, "Id", "Nome");
            }
            return View();
        }
    }
}
