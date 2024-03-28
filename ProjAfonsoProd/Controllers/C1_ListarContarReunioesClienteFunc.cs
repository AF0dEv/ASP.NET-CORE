using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjAfonsoProd.Data;

namespace ProjAfonsoProd.Controllers
{
    public class C1_ListarContarReunioesClienteFunc : Controller
    {
        private readonly ApplicationDbContext _context;

        public C1_ListarContarReunioesClienteFunc(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? cbxFunc, int? cbxCliente)
        {
            ViewBag.Funcionarios = new SelectList(_context.Tfuncionarios.OrderBy(f => f.Id), "Id", "Nome");
            ViewBag.Clientes = new SelectList(_context.Tclientes.OrderBy(c => c.Id), "Id", "Nome");

            if (cbxFunc != null && cbxCliente != null)
            {
                ViewBag.Reunioes = _context.Treunioes.Where(r => r.FuncionarioId == cbxFunc && r.ClienteId == cbxCliente)
                    .Include(r => r.Cliente)
                    .Include(r => r.Funcionario)
                    .ToList();
                ViewBag.Contagem = _context.Treunioes.Where(r => r.FuncionarioId == cbxFunc && r.ClienteId == cbxCliente).Count();
                return View();
            }
            else
            {
                ViewBag.Reunioes = "vazio";
                return View();
            }
        }
    }
}
