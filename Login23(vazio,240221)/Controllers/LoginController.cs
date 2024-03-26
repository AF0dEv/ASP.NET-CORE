using Login23.Data;
using Login23.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login23.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext db;
        public LoginController(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string Username, string Password)
        {
            Utilizador user = new Utilizador();
            user = await db.TUtilizadores.FirstOrDefaultAsync(u => u.NomeUtilizador == Username && u.Senha == Password);
            if (user == null)
            {
                return View();
            }
            else if (user.Estado == true && user.Administrador == true)
            {
                HttpContext.Session.SetString("UTILIZADOR", user.NomeUtilizador);
                HttpContext.Session.SetString("ESTADO", "Ativo");
                HttpContext.Session.SetString("ADMINISTRADOR", "Sim");
                return Redirect(HttpContext.Session.GetString("CONTROLADOR") + "/Index");

            }
            else if (user.Estado == false)
            {
                return Redirect("/Login");
            }
            else if (user.Estado == true && user.Administrador == false)
            {
                HttpContext.Session.SetString("UTILIZADOR", user.NomeUtilizador);
                HttpContext.Session.SetString("ESTADO", "Ativo");
                HttpContext.Session.SetString("ADMINISTRADOR", "");
                return Redirect(HttpContext.Session.GetString("CONTROLADOR") + "/Index");
            }

            return View();

        }
    }
}
















//quer seja utilizador normal ou administrador, regressa à página que invocadora do login:
//   return Redirect("~/" + HttpContext.Session.GetString("CONTROLADOR") + "/Index");
