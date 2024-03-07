using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipasMembros.Controllers
{
    public class C4_DropsEquipasMembros : Controller
    {
        ApplicationDbContext dbp;
        public C4_DropsEquipasMembros(ApplicationDbContext context)
        {
            dbp = context;
        }

        public IActionResult Index()
        {
            var equipas = dbp.Tequipas.Select(m => new { m.Id, m.NomeEquipa }).ToList();

            @ViewBag.EQUIPAS = new SelectList(equipas, "Id", "NomeEquipa");

            var membros = dbp.Tmembros.Select(m => new { m.Id, m.NomeMembro }).ToList();

            @ViewBag.MEMBROS =new SelectList(membros, "Id", "NomeMembro");


            return View();
        }
    }
}
