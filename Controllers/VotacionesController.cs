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
    public class VotacionesController : Controller
    {
        private readonly RestaurantContext _context;

        public VotacionesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Votaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Votaciones.ToListAsync());
        }

        // GET: Votaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Votaciones = await _context.Votaciones
                .FirstOrDefaultAsync(m => m.Id_votacion == id);
            if (tbl_Votaciones == null)
            {
                return NotFound();
            }

            return View(tbl_Votaciones);
        }

        // GET: Votaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Votaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_votacion,Id_restaurante,Id_dato,Votacion")] tbl_Votaciones tbl_Votaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Votaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Votaciones);
        }

        // GET: Votaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Votaciones = await _context.Votaciones.FindAsync(id);
            if (tbl_Votaciones == null)
            {
                return NotFound();
            }
            return View(tbl_Votaciones);
        }

        // POST: Votaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_votacion,Id_restaurante,Id_dato,Votacion")] tbl_Votaciones tbl_Votaciones)
        {
            if (id != tbl_Votaciones.Id_votacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Votaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_VotacionesExists(tbl_Votaciones.Id_votacion))
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
            return View(tbl_Votaciones);
        }

        // GET: Votaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Votaciones = await _context.Votaciones
                .FirstOrDefaultAsync(m => m.Id_votacion == id);
            if (tbl_Votaciones == null)
            {
                return NotFound();
            }

            return View(tbl_Votaciones);
        }

        // POST: Votaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Votaciones = await _context.Votaciones.FindAsync(id);
            _context.Votaciones.Remove(tbl_Votaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_VotacionesExists(int id)
        {
            return _context.Votaciones.Any(e => e.Id_votacion == id);
        }
    }
}
