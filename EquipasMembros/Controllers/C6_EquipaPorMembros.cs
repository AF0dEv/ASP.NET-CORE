using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C6_EquipaPorMembros : Controller
    {
        ApplicationDbContext dbp;
        public C6_EquipaPorMembros(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            @ViewBag.MEMBROS = dbp.Tmembros.ToList();
            @ViewBag.EQUIPAS = dbp.Tequipas.ToList();
            return View();
        }
    }
}
