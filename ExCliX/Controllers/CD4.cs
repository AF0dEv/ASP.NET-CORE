using ExCliX.Data;
using ExCliX.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExCliX.Controllers
{
    public class CD4 : Controller
    {
        ApplicationDbContext _context;
        public CD4(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ClientesTiposItems cti = new ClientesTiposItems();
            cti.Clientes = _context.Tclientes.ToList();
            return View(cti);

        }

        // sem else ele corre o metodo abaixo mesmo o cbxClientes == 0, com else ele não corre o metodo abaixo mas sim o acima, Porque? porque o return RedirectToAction("Index"); é um redirecionamento para o metodo Index, e o return View(cti); é um redirecionamento para a view Index
        [HttpPost]
        public IActionResult Index(int cbxClientes)
        {
            @ViewBag.IDCLIENTESELECIONADO = cbxClientes;
            if (cbxClientes == 0)
            {
                return RedirectToAction("Index");
            }
            else
            { 
            ClientesTiposItems cti = new ClientesTiposItems();
            cti.Clientes = _context.Tclientes.ToList();
            cti.Tipos = _context.Ttipos.ToList();
            cti.Items = _context.Titems.Where(m => m.ClienteId == cbxClientes).ToList();
            return View(cti);
            }
        }

        public IActionResult Criar(int? Id) 
        {
            ViewBag.IDCLIENTESELECIONADO = Id;
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string Item1, string Item2, string Texto, int TipoId, int ClienteId)
        {
            _context.Titems.Add(new Item { Item1 = Item1, Item2 = Item2, Texto = Texto, TipoId = TipoId, ClienteId = ClienteId });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
