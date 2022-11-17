﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaTres.Context;
using CooperativaTres.Models;

namespace CooperativaTres.Controllers
{
    public class AsientosXFuncionsController : Controller
    {
        private readonly CineDatabaseContext _context;

        public AsientosXFuncionsController(CineDatabaseContext context)
        {
            _context = context;
        }

        // GET: AsientosXFuncions
        public async Task<IActionResult> Index()
        {
            var cineDatabaseContext = _context.AsientosXFuncion.Include(a => a.Asiento).Include(a => a.Funcion);
            return View(await cineDatabaseContext.ToListAsync());
        }

        // GET: AsientosXFuncions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosXFuncion = await _context.AsientosXFuncion
                .Include(a => a.Asiento)
                .Include(a => a.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientosXFuncion == null)
            {
                return NotFound();
            }

            return View(asientosXFuncion);
        }

        // GET: AsientosXFuncions/Create
        public IActionResult Create()
        {
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Id");
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id");
            return View();
        }

        // POST: AsientosXFuncions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionId,AsientoId")] AsientosXFuncion asientosXFuncion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientosXFuncion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Id", asientosXFuncion.AsientoId);
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", asientosXFuncion.FuncionId);
            return View(asientosXFuncion);
        }

        // GET: AsientosXFuncions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosXFuncion = await _context.AsientosXFuncion.FindAsync(id);
            if (asientosXFuncion == null)
            {
                return NotFound();
            }
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Id", asientosXFuncion.AsientoId);
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", asientosXFuncion.FuncionId);
            return View(asientosXFuncion);
        }

        // POST: AsientosXFuncions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionId,AsientoId")] AsientosXFuncion asientosXFuncion)
        {
            if (id != asientosXFuncion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientosXFuncion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientosXFuncionExists(asientosXFuncion.Id))
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
            ViewData["AsientoId"] = new SelectList(_context.Asientos, "Id", "Id", asientosXFuncion.AsientoId);
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", asientosXFuncion.FuncionId);
            return View(asientosXFuncion);
        }

        // GET: AsientosXFuncions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosXFuncion = await _context.AsientosXFuncion
                .Include(a => a.Asiento)
                .Include(a => a.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientosXFuncion == null)
            {
                return NotFound();
            }

            return View(asientosXFuncion);
        }

        // POST: AsientosXFuncions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientosXFuncion = await _context.AsientosXFuncion.FindAsync(id);
            _context.AsientosXFuncion.Remove(asientosXFuncion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientosXFuncionExists(int id)
        {
            return _context.AsientosXFuncion.Any(e => e.Id == id);
        }
    }
}
