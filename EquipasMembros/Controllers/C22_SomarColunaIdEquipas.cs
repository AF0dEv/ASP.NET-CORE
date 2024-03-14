using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C22_SomarColunaIdEquipas : Controller
    {

        ApplicationDbContext dbp;
        public C22_SomarColunaIdEquipas(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var contagem = dbp.Tequipas.Sum(m => m.Id);
            ViewBag.CONTAGEM = contagem;
            return View();
        }
    }
}
