﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web1Shamil.Data;
using Web1Shamil.Models.Classes;

namespace Web1Shamil.Controllers
{
    public class RegionsController : Controller
    {
        private readonly MContext _context;

        public RegionsController(MContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions
                .FirstOrDefaultAsync(m => m.RegionsId == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionsId,RegionsName")] Regions regions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regions);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            return View(regions);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionsId,RegionsName")] Regions regions)
        {
            if (id != regions.RegionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionsExists(regions.RegionsId))
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
            return View(regions);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions
                .FirstOrDefaultAsync(m => m.RegionsId == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regions = await _context.Regions.FindAsync(id);
            _context.Regions.Remove(regions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionsExists(int id)
        {
            return _context.Regions.Any(e => e.RegionsId == id);
        }
    }
}
