using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C16_ExisteEquipaArsenal : Controller
    {
        ApplicationDbContext dbp;
        public C16_ExisteEquipaArsenal(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var equipa = dbp.Tequipas.Where(m => m.NomeEquipa.Equals("Arsenal da Devesa")).ToList(); // onde o nome da equipa é igual a "Arsenal da Devesa", e coloca numa lista
            int contagem = equipa.Count();
            if (contagem > 0)
            {
                ViewBag.EXISTE = "Sim";
            }
            else
            {
                ViewBag.EXISTE = "Não";
            }
            return View();
        }
    }
}
