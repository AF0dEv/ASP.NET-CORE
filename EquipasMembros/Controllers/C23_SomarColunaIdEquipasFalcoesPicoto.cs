using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C23_SomarColunaIdEquipasFalcoesPicoto : Controller
    {

        ApplicationDbContext dbp;
        public C23_SomarColunaIdEquipasFalcoesPicoto(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var equipa = dbp.Tequipas.Where(m => m.NomeEquipa.Equals("Falcões do Picoto")).Sum(o => o.Id);
            ViewBag.SOMA = equipa;
            return View();
        }
    }
}
