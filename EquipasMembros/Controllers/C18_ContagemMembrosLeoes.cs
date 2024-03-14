using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C18_ContagemMembrosLeoes : Controller
    {
        ApplicationDbContext dbp;
        public C18_ContagemMembrosLeoes(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var equipa = dbp.Tequipas.Where(e => e.NomeEquipa.Equals("Leões da Tecla")).FirstOrDefault();
            int contagem = dbp.Tmembros.Count(m => m.EquipaId == equipa.Id);
            ViewBag.CONTAGEM = contagem;
            return View();
        }
    }
}
