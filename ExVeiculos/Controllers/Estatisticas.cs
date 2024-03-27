using ExVeiculos.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExVeiculos.Controllers
{
    public class Estatisticas : Controller
    {
        private readonly ApplicationDbContext _context;

        public Estatisticas(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TotalVeiculos = _context.Tveiculos.Count();
            ViewBag.TotalCategorias = _context.Tcategorias.Count();
            if (_context.Tveiculos.Where(v => v.Ano > 2017).Count() > 0)
            {
                ViewBag.ExistemVeiculosRecentes = "Existe";
            }
            else
            {
                ViewBag.ExistemVeiculosRecentes = "Nao";
            }
            return View();
        }
    }
}
