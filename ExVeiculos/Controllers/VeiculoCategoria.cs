using ExVeiculos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExVeiculos.Controllers
{
    public class VeiculoCategoria : Controller
    {
        ApplicationDbContext dbp;
        public VeiculoCategoria(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index(int? cbxCategorias)
        {
            ViewBag.LISTACATEGORIAS = new SelectList(dbp.Tcategorias, "Id", "Designacao");

            if (cbxCategorias == null)
            {
                ViewBag.LISTAVEICULOS = "vazio";
            }
            else
            {
                ViewBag.LISTAVEICULOS = dbp.Tveiculos.Where(v => v.CategoriaId == cbxCategorias).ToList();
            }
            return View();
        }
    }
}
