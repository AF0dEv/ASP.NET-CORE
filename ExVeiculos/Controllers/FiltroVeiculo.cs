using ExVeiculos.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExVeiculos.Controllers
{
    public class FiltroVeiculo : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiltroVeiculo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? txtFiltro)
        {
            if (txtFiltro == null)
            {
                ViewBag.Veiculos = "vazio";
            }
            else
            {
                ViewBag.Veiculos = _context.Tveiculos.Where(v => v.Ano == Convert.ToInt16(txtFiltro)).ToList();
            }
            return View();
        }
    }
}
