using ExCliX.Data;
using ExCliX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNet_ProjetoClix.Controllers;

public class CD5 : Controller
{
    private readonly ApplicationDbContext _context;

    public CD5(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string ordenarPor, string? nomeCliente)
    {
        ViewData["NomeCliente"] = nomeCliente;

        var query = _context.Tclientes.AsQueryable();

        if (!string.IsNullOrEmpty(nomeCliente))
        {
            query = query.Where(e => e.Nome.Contains(nomeCliente));
        }

        switch (ordenarPor)
        {
            case "Id":
                ViewData["OrdenarPor"] = "Id";
                query = query.OrderBy(e => e.Id);
                break;
            case "IdDesc":
                ViewData["OrdenarPor"] = "IdDesc";
                query = query.OrderByDescending(e => e.Id);
                break;
            case "Nome":
                ViewData["OrdenarPor"] = "Nome";
                query = query.OrderBy(e => e.Nome);
                break;
            case "NomeDesc":
                ViewData["OrdenarPor"] = "NomeDesc";
                query = query.OrderByDescending(e => e.Nome);
                break;
            case "Referencia":
                ViewData["OrdenarPor"] = "Referencia";
                query = query.OrderBy(e => e.Referencia);
                break;
            case "ReferenciaDesc":
                ViewData["OrdenarPor"] = "ReferenciaDesc";
                query = query.OrderByDescending(e => e.Referencia);
                break;
        }

        var clientes = await query.ToListAsync();

        return View(clientes);
    }

    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        _context.Add(cliente);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int id)
    {
        return View(await _context.Tclientes.FindAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Cliente cliente)
    {
        _context.Tclientes.Update(cliente);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Eliminar(int? id)
    {
        return View(await _context.Tclientes.FindAsync(id));
    }

    [HttpPost, ActionName("Eliminar")]
    public async Task<IActionResult> EliminarPost(int id)
    {
        var cliente = await _context.Tclientes.FindAsync(id);

        if (cliente != null)
        {
            _context.Tclientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}
