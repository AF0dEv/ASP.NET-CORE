using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C13_QualEquipaN5 : Controller
    {
        ApplicationDbContext dbp;
        public C13_QualEquipaN5(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            int id = 5;
            var equipa = dbp.Tequipas.Find(id);
            ViewBag.EQUIPA = equipa.NomeEquipa;
            return View();
        }
    }
}
