using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba2.Models;

namespace prueba2.Controllers
{
    public class PrestamoesController : Controller
    {
        private readonly AhorrosPrestamosContext _context;

        public PrestamoesController(AhorrosPrestamosContext context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var ahorrosPrestamosContext = _context.Prestamos.Include(p => p.ClienteFiadorNavigation).Include(p => p.ClientePrestatarioNavigation).Include(p => p.IdGarantiaNavigation);
            return View(await ahorrosPrestamosContext.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.ClienteFiadorNavigation)
                .Include(p => p.ClientePrestatarioNavigation)
                .Include(p => p.IdGarantiaNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteFiador"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["ClientePrestatario"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdGarantia"] = new SelectList(_context.Garantia, "IdGarantia", "IdGarantia");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,ClientePrestatario,ClienteFiador,FechaSolicitudPrestamo,FechaAprobacion,FechaInicio,FechaTermino,MontoPrestamo,TasaInteres,TiempoAmortizacionMeses,Aprovado,Vigencia,IdGarantia")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteFiador"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClienteFiador);
            ViewData["ClientePrestatario"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClientePrestatario);
            ViewData["IdGarantia"] = new SelectList(_context.Garantia, "IdGarantia", "IdGarantia", prestamo.IdGarantia);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["ClienteFiador"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClienteFiador);
            ViewData["ClientePrestatario"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClientePrestatario);
            ViewData["IdGarantia"] = new SelectList(_context.Garantia, "IdGarantia", "IdGarantia", prestamo.IdGarantia);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,ClientePrestatario,ClienteFiador,FechaSolicitudPrestamo,FechaAprobacion,FechaInicio,FechaTermino,MontoPrestamo,TasaInteres,TiempoAmortizacionMeses,Aprovado,Vigencia,IdGarantia")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["ClienteFiador"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClienteFiador);
            ViewData["ClientePrestatario"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", prestamo.ClientePrestatario);
            ViewData["IdGarantia"] = new SelectList(_context.Garantia, "IdGarantia", "IdGarantia", prestamo.IdGarantia);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.ClienteFiadorNavigation)
                .Include(p => p.ClientePrestatarioNavigation)
                .Include(p => p.IdGarantiaNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prestamos == null)
            {
                return Problem("Entity set 'AhorrosPrestamosContext.Prestamos'  is null.");
            }
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
          return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }
    }
}
