using Microsoft.AspNetCore.Mvc;
using ProjAfonsoProd.Data;
using ProjAfonsoProd.Models;

namespace ProjAfonsoProd.Controllers
{
    public class C4_InserirFuncionario : Controller
    {
        ApplicationDbContext _context;
        public C4_InserirFuncionario(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UTILIZADOR") == "" || HttpContext.Session.GetString("UTILIZADOR") == null)
            {
                HttpContext.Session.SetString("CONTROLADOR", "C4_InserirFuncionario");
                return RedirectToAction("Index", "C5_Login");

            }
            else
            {

                ViewBag.Funcionarios = _context.Tfuncionarios.ToList();
                return View();
            }
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(string txtNome)
        {
            Funcionario f = new Funcionario();
            f.Nome = txtNome;
            _context.Tfuncionarios.Add(f);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario f = _context.Tfuncionarios.FirstOrDefault(f => f.Id == id);
            if (f == null)
            {
                return NotFound();
            }
            return View(f);
        }
        [HttpPost]
        public IActionResult ConfirmarApagar(int id)
        {
            Funcionario f = _context.Tfuncionarios.Find(id);
            if (f != null)
            {
                _context.Tfuncionarios.Remove(f);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario f = _context.Tfuncionarios.FirstOrDefault(f => f.Id == id);
            if (f == null)
            {
                return NotFound();
            }
            return View(f);
        }
        [HttpPost]
        public IActionResult Editar(int id, string txtNome)
        {
            Funcionario f = _context.Tfuncionarios.Find(id);
            if (f != null)
            {
                f.Nome = txtNome;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
