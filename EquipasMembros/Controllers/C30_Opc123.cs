using EquipasMembros.Data;
using EquipasMembros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C30_Opc123 : Controller
    {
        ApplicationDbContext dbp;
        public C30_Opc123(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index(int alEquipas)
        {

            ViewBag.EQUIPAS = dbp.Tequipas.ToList();
            if (alEquipas != 0)
            {
                ViewBag.MEMBROS = dbp.Tmembros.Where(m => m.EquipaId == alEquipas).ToList();
                ViewBag.EQUIPACLICADA = alEquipas;
                var equipa = dbp.Tequipas.Find(alEquipas);
                ViewBag.EQUIPASELECIONADA = equipa.NomeEquipa;
                ViewBag.MEMBROSEQUIPA = dbp.Tmembros.Where(e => e.EquipaId == alEquipas).Count();
                ViewBag.COUNTMEMBROS = dbp.Tmembros.Count();
            }
            else
            {
                ViewBag.MEMBROS = null;
            }
            return View();
        }

    }
}
