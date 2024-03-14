using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C8_ContarEquipas : Controller
    {
        ApplicationDbContext dbp;
        public C8_ContarEquipas(ApplicationDbContext context)
        {
            dbp = context;
        }
       
        public IActionResult Index()
        {
            
            ViewBag.CONTAGEMEQUIPAS = dbp.Tequipas.Count();
            return View();
        }
    }
}
