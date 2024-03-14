using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C21_QualIdMaisBaixoEquipa : Controller
    {

        ApplicationDbContext dbp;
        public C21_QualIdMaisBaixoEquipa(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var id = dbp.Tequipas.Min(m => m.Id);
            ViewBag.ID = id;
            return View();
        }
    }
}
