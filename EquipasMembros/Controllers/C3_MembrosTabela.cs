using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EquipasMembros.Controllers
{
    public class C3_MembrosTabela : Controller
    {
        ApplicationDbContext dbp;
        public C3_MembrosTabela(ApplicationDbContext context)
        {
            dbp = context;
        }

        public IActionResult Index()
        {
            @ViewBag.MEMBROS = dbp.Tmembros.ToList();
            return View();
        }
    }
}
