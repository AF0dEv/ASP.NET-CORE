using ExCliX.Data;
using ExCliX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExCliX.Controllers
{
    public class CD4 : Controller
    {
        ApplicationDbContext _context;
        public CD4(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? cbxClientes, int? Id)
        {
            // Quando for passado um parâmetro pela cbxClientes
            if (cbxClientes != null && cbxClientes > 0)
            {
                @ViewBag.CLIENTES = new SelectList(_context.Tclientes, "Id", "Nome");
                @ViewBag.IDCLIENTESELECIONADO = cbxClientes;
                @ViewBag.CLIENTESELECIONADO = _context.Titems.Where(m => m.ClienteId == cbxClientes).ToList();
                cbxClientes = null;
                Id = null;
                return View();
            }
            // Quando for passado um parâmetro para Persistencia
            if (Id != null)
            {
                @ViewBag.CLIENTES = new SelectList(_context.Tclientes, "Id", "Nome", Id) ;
                @ViewBag.IDCLIENTESELECIONADO = Id;
                @ViewBag.CLIENTESELECIONADO = _context.Titems.Where(m => m.ClienteId == Id).ToList();
                cbxClientes = null;
                Id = null;
                return View();
            }
            // Quando não for passado nenhum parâmetro
            @ViewBag.CLIENTES = new SelectList(_context.Tclientes, "Id", "Nome");
            @ViewBag.IDCLIENTESELECIONADO = cbxClientes;
            return View();

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
            return RedirectToAction("Index" );
        }

        public IActionResult Editar(int? IdItem)
        {
            ViewBag.CLIENTESELECIONADO = _context.Titems.Find(IdItem);
            return View();
        }

        [HttpPost]
        public IActionResult Editar(int Id, string Item1, string Item2, string Texto, int TipoId, int ClienteId)
        {
            Item item = _context.Titems.Find(Id);
            item.Item1 = Item1;
            item.Item2 = Item2;
            item.Texto = Texto;
            item.TipoId = TipoId;
            item.ClienteId = ClienteId;
            _context.Titems.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index", new {Id = ClienteId});
        }
    }
}
