using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C17_ContagemMembrosEquipa4 : Controller
    {
        ApplicationDbContext dbp;
        public C17_ContagemMembrosEquipa4(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var membros = dbp.Tmembros.Count(m => m.EquipaId == 4);
            ViewBag.MEMBROS = membros;
            return View();
        }
    }
}
