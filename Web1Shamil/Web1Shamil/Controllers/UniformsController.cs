using System;
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
    public class UniformsController : Controller
    {
        private readonly MContext _context;

        public UniformsController(MContext context)
        {
            _context = context;
        }

        // GET: Uniforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uniforms.ToListAsync());
        }

        // GET: Uniforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniforms = await _context.Uniforms
                .FirstOrDefaultAsync(m => m.UniformsId == id);
            if (uniforms == null)
            {
                return NotFound();
            }

            return View(uniforms);
        }

        // GET: Uniforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uniforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniformsId,UniformsName,UniformsColor,TeamsId")] Uniforms uniforms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uniforms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uniforms);
        }

        // GET: Uniforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniforms = await _context.Uniforms.FindAsync(id);
            if (uniforms == null)
            {
                return NotFound();
            }
            return View(uniforms);
        }

        // POST: Uniforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniformsId,UniformsName,UniformsColor,TeamsId")] Uniforms uniforms)
        {
            if (id != uniforms.UniformsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uniforms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniformsExists(uniforms.UniformsId))
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
            return View(uniforms);
        }

        // GET: Uniforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uniforms = await _context.Uniforms
                .FirstOrDefaultAsync(m => m.UniformsId == id);
            if (uniforms == null)
            {
                return NotFound();
            }

            return View(uniforms);
        }

        // POST: Uniforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uniforms = await _context.Uniforms.FindAsync(id);
            _context.Uniforms.Remove(uniforms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniformsExists(int id)
        {
            return _context.Uniforms.Any(e => e.UniformsId == id);
        }
    }
}
