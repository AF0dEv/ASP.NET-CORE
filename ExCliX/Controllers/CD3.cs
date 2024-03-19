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
            ViewBag.CLIENTES = dbp.Tclientes.ToList();
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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Cliente c = dbp.Tclientes.FirstOrDefault(m => m.Id == id);

            if(c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Cliente c = dbp.Tclientes.Find(id);
            if(c != null)
            {
                dbp.Tclientes.Remove(c);
            }

            dbp.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Cliente c = dbp.Tclientes.FirstOrDefault(m => m.Id == id);

            if(c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(int id, string txtNome, string txtReferencia)
        {
            Cliente c = dbp.Tclientes.Find(id);
            if(c != null)
            {
                c.Nome = txtNome;
                c.Referencia = txtReferencia;
            }

            dbp.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
