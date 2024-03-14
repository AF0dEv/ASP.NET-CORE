using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C25_QuantasEquipasMembroAbel : Controller
    {

        ApplicationDbContext dbp;
        public C25_QuantasEquipasMembroAbel(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {

            var contagem = dbp.Tequipas.Where(e => e.Membros.Any(m => m.NomeMembro.Equals("Abel"))).Count();
            ViewBag.CONTAGEM = contagem;
            return View();
        }
    }
}
