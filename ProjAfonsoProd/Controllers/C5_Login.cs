using Microsoft.AspNetCore.Mvc;
using ProjAfonsoProd.Data;
using ProjAfonsoProd.Models;

namespace ProjAfonsoProd.Controllers
{
    public class C5_Login : Controller
    {
        private readonly ApplicationDbContext _context;

        public C5_Login(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? NomeUtilizador, string? senha)
        {
                Utilizador user = new Utilizador();
                user = _context.Tutilizadores.FirstOrDefault(u => u.NomeUtilizador == NomeUtilizador && u.Senha == senha);
                if (user == null)
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("UTILIZADOR", user.NomeUtilizador);
                    return Redirect(HttpContext.Session.GetString("CONTROLADOR") + "/Index");

                }
        }
    }
}
