using ExCliX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExCliX.Controllers
{
    public class PROD1 : Controller
    {
        ApplicationDbContext dbp;
        public PROD1(ApplicationDbContext context)
        {
            dbp = context;
        }

        public int getIdTipo(string nomeTipo)
        {
            if (nomeTipo == null)
            {
                   return -1;
            }
            else
            {
                var tipo = dbp.Ttipos.Where(t => t.Designacao == nomeTipo).FirstOrDefault();
                if (tipo != null)
                {
                    return tipo.Id;
                }
            }
            return -1;
        }
        public IActionResult Index(string txtTipo, int cbxClientes)
        {
            // Exercicio 1
            ViewBag.CLIENTES = dbp.Tclientes.ToArray();

            //Exercicio 2
            ViewBag.ITEMS = dbp.Tclientes
                .Join(dbp.Titems, m => m.Id, i => i.ClienteId, (m, i) => new
                { m.Nome,
                  i.Item1,
                  i.Item2,
                  i.Texto,
                }).ToList();

            //Exercicio 3
            ViewBag.LISTACLIENTES = new SelectList(dbp.Tclientes, "Id", "Nome");
            int TipoId = getIdTipo(txtTipo);
            ViewBag.INFOTIPO = dbp.Titems.Where(i => i.TipoId == TipoId && i.ClienteId == cbxClientes).ToList();

            return View();
        }
    }
}
