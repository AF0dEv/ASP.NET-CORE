using ExVeiculos.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExVeiculos.Controllers
{
    public class rbtVeiculos : Controller
    {
        private readonly ApplicationDbContext _context;

        public rbtVeiculos(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? rbtFiltro)
        {
            if (rbtFiltro == 1)
            {
                ViewBag.Veiculos = _context.Tveiculos.Where(v => v.Ano >= 2010 && v.Ano <= 2020).ToList();
            }
            else if(rbtFiltro == 2)
            {
                ViewBag.Veiculos = _context.Tveiculos.Where(v => v.Ano > 2020).ToList();
            }
            return View();
        }
    }
}
