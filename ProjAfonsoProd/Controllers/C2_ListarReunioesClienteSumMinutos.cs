using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAfonsoProd.Data;

namespace ProjAfonsoProd.Controllers
{
    public class C2_ListarReunioesClienteSumMinutos : Controller
    {
        private readonly ApplicationDbContext _context;

        public C2_ListarReunioesClienteSumMinutos(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? txtCliente)
        {
            if (txtCliente == null)
            {
                ViewBag.SumMinutos = "vazio"; 
                ViewBag.ReuinioesCliente = "vazio";
                return View();
            }
            else
            {
                var reunioes = _context.Treunioes
                                                 .Include(r => r.Cliente)
                                                 .Include(r => r.Funcionario)
                                                 .ToList();
                var reunioesCliente = reunioes.Where(r => r.Cliente.Nome == txtCliente);
                int sumMinutos = 0;
                foreach (var reuniao in reunioesCliente)
                {
                    sumMinutos += reuniao.duracao;
                }
                ViewBag.ReunioesCliente = reunioesCliente;
                ViewBag.SumMinutos = sumMinutos;
                return View();
            }
        }
    }
}
