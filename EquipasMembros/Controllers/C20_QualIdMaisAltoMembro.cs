using EquipasMembros.Data;
using Microsoft.AspNetCore.Mvc;

namespace EquipasMembros.Controllers
{
    public class C20_QualIdMaisAltoMembro : Controller
    {

        ApplicationDbContext dbp;
        public C20_QualIdMaisAltoMembro(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            var membro = dbp.Tmembros.OrderByDescending(m => m.Id).FirstOrDefault();
            ViewBag.MEMBROID = membro.Id;
            return View();
        }
    }
}
