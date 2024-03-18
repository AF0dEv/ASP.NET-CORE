using ExCliX.Data;
using ExCliX.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExCliX.Controllers
{
    public class CD3 : Controller
    {
        ApplicationDbContext dbp;
        public CD3(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string txtNome, string txtReferencia)
        {
            if (txtNome != null && txtReferencia != null)
            {
                Cliente c = new Cliente();
                c.Nome = txtNome;
                c.Referencia = txtReferencia;
                dbp.Tclientes.Add(c);
                dbp.SaveChanges();
            }
            return View();
        }
    }
}
