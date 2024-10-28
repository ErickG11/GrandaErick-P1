using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrandaErick_P1.Models;

namespace GrandaErick_P1.Controllers
{
    public class EGrandasController : Controller
    {
        private readonly GrandaErickContext _context;

        public EGrandasController(GrandaErickContext context)
        {
            _context = context;
        }

        // GET: EGrandas
        public async Task<IActionResult> Index()
        {
            var grandaErickContext = _context.EGranda.Include(e => e.Celular);
            return View(await grandaErickContext.ToListAsync());
        }

        // GET: EGrandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGranda = await _context.EGranda
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eGranda == null)
            {
                return NotFound();
            }

            return View(eGranda);
        }

        // GET: EGrandas/Create
        public IActionResult Create()
        {
            ViewData["IDCelular"] = new SelectList(_context.Set<Celular>(), "ID", "Modelo");
            return View();
        }

        // POST: EGrandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Ecuatoriano,Peso,Fecha,IDCelular")] EGranda eGranda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eGranda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCelular"] = new SelectList(_context.Set<Celular>(), "ID", "Modelo", eGranda.IDCelular);
            return View(eGranda);
        }

        // GET: EGrandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGranda = await _context.EGranda.FindAsync(id);
            if (eGranda == null)
            {
                return NotFound();
            }
            ViewData["IDCelular"] = new SelectList(_context.Set<Celular>(), "ID", "Modelo", eGranda.IDCelular);
            return View(eGranda);
        }

        // POST: EGrandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Ecuatoriano,Peso,Fecha,IDCelular")] EGranda eGranda)
        {
            if (id != eGranda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eGranda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EGrandaExists(eGranda.ID))
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
            ViewData["IDCelular"] = new SelectList(_context.Set<Celular>(), "ID", "Modelo", eGranda.IDCelular);
            return View(eGranda);
        }

        // GET: EGrandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGranda = await _context.EGranda
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eGranda == null)
            {
                return NotFound();
            }

            return View(eGranda);
        }

        // POST: EGrandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eGranda = await _context.EGranda.FindAsync(id);
            if (eGranda != null)
            {
                _context.EGranda.Remove(eGranda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EGrandaExists(int id)
        {
            return _context.EGranda.Any(e => e.ID == id);
        }
    }
}
