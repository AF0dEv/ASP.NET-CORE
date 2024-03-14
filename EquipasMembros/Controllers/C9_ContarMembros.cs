using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C9_ContarMembros : Controller
    {
        ApplicationDbContext dbp;
        public C9_ContarMembros(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.CONTAGEMMEMBROS = dbp.Tmembros.Count();
            return View();
        }
    }
}
