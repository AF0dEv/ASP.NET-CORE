using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C27_ListaOrdenadaMembrosMaxiFalcoes : Controller
    {
        ApplicationDbContext dbp;
        public C27_ListaOrdenadaMembrosMaxiFalcoes(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            ViewBag.NOMES = dbp.Tmembros.Join(dbp.Tequipas, m => m.EquipaId, e => e.Id,
                               (m, e) => new { m, e })
                .Where(m => m.e.NomeEquipa.Equals("Maximinense") || m.e.NomeEquipa.Equals("Falcões do Picoto"))
                .OrderBy(m => m.m.NomeMembro)
                .Select(m => m.m.NomeMembro);
            return View();
        }
    }
}
