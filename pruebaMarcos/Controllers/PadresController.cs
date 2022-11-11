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
    public class PadresController : Controller
    {
        private readonly PruebaNodosContext _context;

        public PadresController(PruebaNodosContext context)
        {
            _context = context;
        }

        // GET: Padres
        public async Task<IActionResult> Index()
        {
              return View(await _context.Padres.ToListAsync());
        }

        // GET: Padres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Padres == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // GET: Padres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Padres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estatus")] Padre padre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padre);
        }

        // GET: Padres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Padres == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres.FindAsync(id);
            if (padre == null)
            {
                return NotFound();
            }
            return View(padre);
        }

        // POST: Padres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estatus")] Padre padre)
        {
            if (id != padre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadreExists(padre.Id))
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
            return View(padre);
        }

        // GET: Padres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Padres == null)
            {
                return NotFound();
            }

            var padre = await _context.Padres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // POST: Padres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Padres == null)
            {
                return Problem("Entity set 'PruebaNodosContext.Padres'  is null.");
            }
            var padre = await _context.Padres.FindAsync(id);
            if (padre != null)
            {
                _context.Padres.Remove(padre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadreExists(int id)
        {
          return _context.Padres.Any(e => e.Id == id);
        }
    }
}
