using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C24_SomarColunaIdMembrosFalcoesPicoto : Controller
    {

        ApplicationDbContext dbp;
        public C24_SomarColunaIdMembrosFalcoesPicoto(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var equipa = dbp.Tequipas.Where(e => e.NomeEquipa.Equals("Falcões do Picoto")).FirstOrDefault();
            int contagem = dbp.Tmembros.Where(m => m.EquipaId == equipa.Id).Sum(o => o.Id);
            ViewBag.CONTAGEM = contagem;
            return View();
        }
    }
}
