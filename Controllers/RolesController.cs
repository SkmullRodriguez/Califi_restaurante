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
    public class RolesController : Controller
    {
        private readonly RestaurantContext _context;

        public RolesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id_rol == id);
            if (tbl_Roles == null)
            {
                return NotFound();
            }

            return View(tbl_Roles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_rol,Rol,Descripcion")] tbl_Roles tbl_Roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Roles = await _context.Roles.FindAsync(id);
            if (tbl_Roles == null)
            {
                return NotFound();
            }
            return View(tbl_Roles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_rol,Rol,Descripcion")] tbl_Roles tbl_Roles)
        {
            if (id != tbl_Roles.Id_rol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_RolesExists(tbl_Roles.Id_rol))
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
            return View(tbl_Roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Roles = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id_rol == id);
            if (tbl_Roles == null)
            {
                return NotFound();
            }

            return View(tbl_Roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Roles = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(tbl_Roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_RolesExists(int id)
        {
            return _context.Roles.Any(e => e.Id_rol == id);
        }
    }
}
