using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C12_ListarEquipasOrdemDescendente : Controller
    {
        ApplicationDbContext dbp;
        public C12_ListarEquipasOrdemDescendente(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.EQUIPASDESCENDENTE = dbp.Tequipas.OrderByDescending(e => e.NomeEquipa).ToList();
            return View();
        }
    }
}
