using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C5_MembrosPorEquipa : Controller
    {
        ApplicationDbContext dbp;
        public C5_MembrosPorEquipa(ApplicationDbContext context)
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
