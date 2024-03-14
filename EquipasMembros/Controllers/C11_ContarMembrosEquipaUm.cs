using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C11_ContarMembrosEquipaUm : Controller
    {

        ApplicationDbContext dbp;
        public C11_ContarMembrosEquipaUm(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.COUNTMEMBROS = dbp.Tmembros.Where(m => m.EquipaId == 1).Count();
            return View();
        }
    }
}
