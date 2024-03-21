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
            cti.Tipos = _context.Ttipos.ToList();
            cti.Items = _context.Titems.ToList();
            return View(cti);
        }

        public IActionResult Criar() 
        {
            return View();
        }
    }
}
