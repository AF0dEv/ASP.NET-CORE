using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C14_QualEquipaN88 : Controller
    {
        ApplicationDbContext dbp;
        public C14_QualEquipaN88(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            int id = 88;
            var equipa = dbp.Tequipas.Find(id);
            
            if (equipa != null)
            {
                ViewBag.EQUIPA = equipa.NomeEquipa;
            }
            else
            {
                ViewBag.EQUIPA = "Equipa não existe!";
            }
            return View();
        }
    }
}
