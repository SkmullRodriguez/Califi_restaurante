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
    public class DatosController : Controller
    {
        private readonly RestaurantContext _context;

        public DatosController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Datos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datos.ToListAsync());
        }

        // GET: Datos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Datos = await _context.Datos
                .FirstOrDefaultAsync(m => m.Id_dato == id);
            if (tbl_Datos == null)
            {
                return NotFound();
            }

            return View(tbl_Datos);
        }

        // GET: Datos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_dato,Nombre,Apellido,Direccion,Eliminacion")] tbl_Datos tbl_Datos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Datos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Datos);
        }

        // GET: Datos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Datos = await _context.Datos.FindAsync(id);
            if (tbl_Datos == null)
            {
                return NotFound();
            }
            return View(tbl_Datos);
        }

        // POST: Datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_dato,Nombre,Apellido,Direccion,Eliminacion")] tbl_Datos tbl_Datos)
        {
            if (id != tbl_Datos.Id_dato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Datos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_DatosExists(tbl_Datos.Id_dato))
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
            return View(tbl_Datos);
        }

        // GET: Datos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Datos = await _context.Datos
                .FirstOrDefaultAsync(m => m.Id_dato == id);
            if (tbl_Datos == null)
            {
                return NotFound();
            }

            return View(tbl_Datos);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Datos = await _context.Datos.FindAsync(id);
            _context.Datos.Remove(tbl_Datos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_DatosExists(int id)
        {
            return _context.Datos.Any(e => e.Id_dato == id);
        }
    }
}
