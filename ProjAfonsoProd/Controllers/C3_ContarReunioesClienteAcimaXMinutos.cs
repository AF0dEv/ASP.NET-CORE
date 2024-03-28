using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAfonsoProd.Data;

namespace ProjAfonsoProd.Controllers
{
    public class C3_ContarReunioesClienteAcimaXMinutos : Controller
    {
        private readonly ApplicationDbContext _context;

        public C3_ContarReunioesClienteAcimaXMinutos(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? txtCliente, int? txtTempo)
        {
            HttpContext.Session.SetString("CONTROLADOR", "C3_ContarReunioesClienteAcimaXMinutos");
            if (txtCliente == null || txtTempo == null)
            {
                ViewBag.SumMinutos = "vazio";
                ViewBag.ReunioesCliente = "vazio";
                ViewBag.Contagem = "vazio";
                return View();
            }
            else
            {
                var idCliente = _context.Tclientes
                                        .Where(c => c.Nome == txtCliente)
                                        .Select(c => c.Id)
                                        .FirstOrDefault();
                var reunioesCliente = _context.Treunioes.Where(r => r.ClienteId == idCliente);
                var reunioesAcimaTempo = reunioesCliente.Where(r => r.duracao > txtTempo);
                int sumMinutos = 0;
                foreach (var reuniao in reunioesAcimaTempo)
                {
                    sumMinutos += reuniao.duracao;
                }
                ViewBag.ReunioesCliente = reunioesCliente;
                ViewBag.SumMinutos = sumMinutos;
                ViewBag.Contagem = reunioesAcimaTempo.Count();
                return View();
            }
        }
    }
}
