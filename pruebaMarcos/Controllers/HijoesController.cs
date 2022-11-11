using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pruebaMarcos.Models;

namespace pruebaMarcos.Controllers
{
    public class HijoesController : Controller
    {
        private readonly PruebaNodosContext _context;

        public HijoesController(PruebaNodosContext context)
        {
            _context = context;
        }

        // GET: Hijoes
        public async Task<IActionResult> Index()
        {
            var pruebaNodosContext = _context.Hijos.Include(h => h.IdPadreNavigation);
            return View(await pruebaNodosContext.ToListAsync());
        }

        // GET: Hijoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .Include(h => h.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // GET: Hijoes/Create
        public IActionResult Create()
        {
            ViewData["IdPadre"] = new SelectList(_context.Padres, "Id", "Id");
            return View();
        }

        // POST: Hijoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estatus,IdPadre")] Hijo hijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPadre"] = new SelectList(_context.Padres, "Id", "Id", hijo.IdPadre);
            return View(hijo);
        }

        // GET: Hijoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos.FindAsync(id);
            if (hijo == null)
            {
                return NotFound();
            }
            ViewData["IdPadre"] = new SelectList(_context.Padres, "Id", "Id", hijo.IdPadre);
            return View(hijo);
        }

        // POST: Hijoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estatus,IdPadre")] Hijo hijo)
        {
            if (id != hijo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HijoExists(hijo.Id))
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
            ViewData["IdPadre"] = new SelectList(_context.Padres, "Id", "Id", hijo.IdPadre);
            return View(hijo);
        }

        // GET: Hijoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hijos == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .Include(h => h.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // POST: Hijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hijos == null)
            {
                return Problem("Entity set 'PruebaNodosContext.Hijos'  is null.");
            }
            var hijo = await _context.Hijos.FindAsync(id);
            if (hijo != null)
            {
                _context.Hijos.Remove(hijo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HijoExists(int id)
        {
          return _context.Hijos.Any(e => e.Id == id);
        }
    }
}
