using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Califi_restaurante.Models;
using Califi_restaurante.Models.Data;

namespace Califi_restaurante.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly RestaurantContext _context;

        public RestaurantesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurantes.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Restaurantes = await _context.Restaurantes
                .FirstOrDefaultAsync(m => m.Id_restaurante == id);
            if (tbl_Restaurantes == null)
            {
                return NotFound();
            }

            return View(tbl_Restaurantes);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_restaurante,Nombre,Descripcion,Direccion,H_apertura,H_cierre,Logo,Imagen_item")] tbl_Restaurantes tbl_Restaurantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Restaurantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Restaurantes);
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Restaurantes = await _context.Restaurantes.FindAsync(id);
            if (tbl_Restaurantes == null)
            {
                return NotFound();
            }
            return View(tbl_Restaurantes);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_restaurante,Nombre,Descripcion,Direccion,H_apertura,H_cierre,Logo,Imagen_item")] tbl_Restaurantes tbl_Restaurantes)
        {
            if (id != tbl_Restaurantes.Id_restaurante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Restaurantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_RestaurantesExists(tbl_Restaurantes.Id_restaurante))
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
            return View(tbl_Restaurantes);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Restaurantes = await _context.Restaurantes
                .FirstOrDefaultAsync(m => m.Id_restaurante == id);
            if (tbl_Restaurantes == null)
            {
                return NotFound();
            }

            return View(tbl_Restaurantes);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Restaurantes = await _context.Restaurantes.FindAsync(id);
            _context.Restaurantes.Remove(tbl_Restaurantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_RestaurantesExists(int id)
        {
            return _context.Restaurantes.Any(e => e.Id_restaurante == id);
        }
    }
}
