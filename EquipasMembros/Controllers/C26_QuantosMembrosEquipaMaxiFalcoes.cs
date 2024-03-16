using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C26_QuantosMembrosEquipaMaxiFalcoes : Controller
    {

        ApplicationDbContext dbp;
        public C26_QuantosMembrosEquipaMaxiFalcoes(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var contagem = dbp.Tmembros.Join(dbp.Tequipas, m => m.EquipaId, e => e.Id,
                (m, e) => new { m, e })
                .Where(m => m.e.NomeEquipa.Equals("Maximinense") || m.e.NomeEquipa.Equals("Falcões do Picoto"))
                .Count(); // onde o nome da equipa é igual a "Maximinense" e "Falcões do Picoto", conta os membros
            ViewBag.CONTAGEM = contagem;
            return View();
        }
    }
}
