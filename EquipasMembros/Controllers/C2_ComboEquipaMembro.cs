using EquipasMembros.Data;
using EquipasMembros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipasMembros.Controllers
{
    public class C2_ComboEquipaMembro : Controller
    {
        ApplicationDbContext dbp;
        public C2_ComboEquipaMembro(ApplicationDbContext context)
        {
            dbp = context;
        }

        public IActionResult Index()
        {
            var equipas = dbp.Tequipas.Select(m => new { m.Id, m.NomeEquipa }).ToList();

            @ViewBag.EQUIPAS = new SelectList(equipas, "Id", "NomeEquipa");

            @ViewBag.MEMBROS = dbp.Tmembros.ToList();


            return View();
        }
    }
}
