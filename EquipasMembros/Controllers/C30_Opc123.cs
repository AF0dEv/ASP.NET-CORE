using EquipasMembros.Data;
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
            }
            else
            {
                ViewBag.MEMBROS = null;
            }
            return View();
        }

    }
}
