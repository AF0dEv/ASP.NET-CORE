using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C10_ListarMembrosOrdemAlfabetica : Controller
    {
        ApplicationDbContext dbp;
        public C10_ListarMembrosOrdemAlfabetica(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.LISTAMEMBROS = dbp.Tmembros.OrderBy(m => m.NomeMembro).ToList();
            return View();
        }
    }
}
