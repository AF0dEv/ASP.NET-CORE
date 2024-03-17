using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C29_MostarEquipasMembrosLado : Controller
    {
        ApplicationDbContext dbp;
        public C29_MostarEquipasMembrosLado(ApplicationDbContext context)
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
