using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C19_ContagemMembrosArcenalDaDebeza : Controller
    {
        ApplicationDbContext dbp;
        public C19_ContagemMembrosArcenalDaDebeza(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var equipa = dbp.Tequipas.Where(m => m.NomeEquipa.Equals("Arcenal da Debesa")).FirstOrDefault(); // onde o nome da equipa é igual a "Arsenal da Devesa", e coloca numa lista
            if (equipa != null)
            {
                int contagem = dbp.Tmembros.Count(m => m.EquipaId == equipa.Id);
                ViewBag.CONTAGEM = contagem;
            }
            else
            {
                ViewBag.CONTAGEM = "Não existe Equipa com Esse Nome!";
            }
            return View();
        }
    }
}
