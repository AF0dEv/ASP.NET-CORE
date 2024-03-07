using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Intrinsics.Arm;

namespace EquipasMembros.Controllers
{
    public class C7_DropMembrosPorEquipa : Controller
    {
        ApplicationDbContext dbp;
        public C7_DropMembrosPorEquipa(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index(int? comboE)
        {
            var equipas = dbp.Tequipas.Select(m => new { m.Id, m.NomeEquipa }).ToList();

            @ViewBag.EQUIPAS = new SelectList(equipas, "Id", "NomeEquipa");

            if (comboE != null)
            {
                @ViewBag.MEMBROS = dbp.Tmembros.Where(m => m.EquipaId == comboE).ToList();
            }
            else
            {
                ViewBag.MEMBROS = "vazio";
            }

            

            return View();
        }
    }
}
