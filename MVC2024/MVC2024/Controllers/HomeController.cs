using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _context;

        public HomeController(Contexto context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.Marcas != null ? 
                          View(await _context.Marcas.ToListAsync()) :
                          Problem("Entity set 'Contexto.Marcas'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModelo = await _context.Marcas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaModelo == null)
            {
                return NotFound();
            }

            return View(marcaModelo);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom_Marca")] MarcaModelo marcaModelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaModelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaModelo);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModelo = await _context.Marcas.FindAsync(id);
            if (marcaModelo == null)
            {
                return NotFound();
            }
            return View(marcaModelo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom_Marca")] MarcaModelo marcaModelo)
        {
            if (id != marcaModelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaModeloExists(marcaModelo.Id))
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
            return View(marcaModelo);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModelo = await _context.Marcas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaModelo == null)
            {
                return NotFound();
            }

            return View(marcaModelo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marcas == null)
            {
                return Problem("Entity set 'Contexto.Marcas'  is null.");
            }
            var marcaModelo = await _context.Marcas.FindAsync(id);
            if (marcaModelo != null)
            {
                _context.Marcas.Remove(marcaModelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaModeloExists(int id)
        {
          return (_context.Marcas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
