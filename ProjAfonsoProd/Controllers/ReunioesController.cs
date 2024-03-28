using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjAfonsoProd.Data;
using ProjAfonsoProd.Models;

namespace ProjAfonsoProd.Controllers
{
    public class ReunioesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReunioesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reunioes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Treunioes.Include(r => r.Cliente).Include(r => r.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reunioes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniao = await _context.Treunioes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return View(reuniao);
        }

        // GET: Reunioes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id");
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id");
            return View();
        }

        // POST: Reunioes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,duracao,Resumo,FuncionarioId,ClienteId")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reuniao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reunioes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniao = await _context.Treunioes.FindAsync(id);
            if (reuniao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // POST: Reunioes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,duracao,Resumo,FuncionarioId,ClienteId")] Reuniao reuniao)
        {
            if (id != reuniao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reuniao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReuniaoExists(reuniao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id", reuniao.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id", reuniao.FuncionarioId);
            return View(reuniao);
        }

        // GET: Reunioes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniao = await _context.Treunioes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reuniao == null)
            {
                return NotFound();
            }

            return View(reuniao);
        }

        // POST: Reunioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reuniao = await _context.Treunioes.FindAsync(id);
            if (reuniao != null)
            {
                _context.Treunioes.Remove(reuniao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReuniaoExists(int id)
        {
            return _context.Treunioes.Any(e => e.Id == id);
        }
    }
}
