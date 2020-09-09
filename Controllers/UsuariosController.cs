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
    public class UsuariosController : Controller
    {
        private readonly RestaurantContext _context;

        public UsuariosController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id_usuario == id);
            if (tbl_Usuarios == null)
            {
                return NotFound();
            }

            return View(tbl_Usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_usuario,Id_dato,Id_rol,Usuario,Clave,Estado")] tbl_Usuarios tbl_Usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Usuarios = await _context.Usuarios.FindAsync(id);
            if (tbl_Usuarios == null)
            {
                return NotFound();
            }
            return View(tbl_Usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_usuario,Id_dato,Id_rol,Usuario,Clave,Estado")] tbl_Usuarios tbl_Usuarios)
        {
            if (id != tbl_Usuarios.Id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_UsuariosExists(tbl_Usuarios.Id_usuario))
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
            return View(tbl_Usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id_usuario == id);
            if (tbl_Usuarios == null)
            {
                return NotFound();
            }

            return View(tbl_Usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(tbl_Usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id_usuario == id);
        }
    }
}
