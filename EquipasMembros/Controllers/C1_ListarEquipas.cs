using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C1_ListarEquipas : Controller
    {
        ApplicationDbContext dbp;
        public C1_ListarEquipas(ApplicationDbContext context)
        {
            dbp = context;
        }

        public IActionResult Index()
        {
            @ViewBag.EQUIPAS = dbp.Tequipas.ToList();

            @ViewBag.MEMBROS = dbp.Tmembros.ToList();


            return View();
        }
    }
}
