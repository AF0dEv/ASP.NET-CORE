using Microsoft.AspNetCore.Mvc;
using ProjAfonsoProd.Data;
using ProjAfonsoProd.Models;

namespace ProjAfonsoProd.Controllers
{
    public class C5_Registar : Controller
    {
        private readonly ApplicationDbContext _context;

        public C5_Registar(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? NomeUtilizador, string? senha)
        {
            if (NomeUtilizador != null && senha != null)
            {
                HttpContext.Session.SetString("CONTROLADOR", "C5_Registar");
                var user = new Utilizador { NomeUtilizador = NomeUtilizador, Senha = senha };
                _context.Tutilizadores.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "C5_Login");
            }
            return View();
        }
    }
}
