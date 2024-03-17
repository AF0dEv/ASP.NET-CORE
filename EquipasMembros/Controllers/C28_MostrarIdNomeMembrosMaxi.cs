using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C28_MostrarIdNomeMembrosMaxi : Controller
    {
        ApplicationDbContext dbp;
        public C28_MostrarIdNomeMembrosMaxi(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.MEMBROS = dbp.Tmembros.Where(m => m.EquipaId == 5);
            return View();
        }
    }
}
