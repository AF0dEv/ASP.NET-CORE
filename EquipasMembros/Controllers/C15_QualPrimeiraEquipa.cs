using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C15_QualPrimeiraEquipa : Controller
    {
        ApplicationDbContext dbp;
        public C15_QualPrimeiraEquipa(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            int id = 1;
            var equipa = dbp.Tequipas.Find(id);
            ViewBag.EQUIPA = equipa.NomeEquipa;
            return View();
        }
    }
}
