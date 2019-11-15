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
    public class TeamsController : Controller
    {
        private readonly MContext _context;

        public TeamsController(MContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var mContext = _context.Teams.Include(t => t.Regions).Include(t => t.Stages);
            return View(await mContext.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams
                .Include(t => t.Regions)
                .Include(t => t.Stages)
                .FirstOrDefaultAsync(m => m.TeamsId == id);
            if (teams == null)
            {
                return NotFound();
            }

            return View(teams);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["RegionsId"] = new SelectList(_context.Regions, "RegionsId", "RegionsName");
            ViewData["StageId"] = new SelectList(_context.Stages, "StageId", "StageName");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamsId,TeamsName,TeamsStadium,RegionsId,StageId")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionsId"] = new SelectList(_context.Regions, "RegionsId", "RegionsName", teams.RegionsId);
            ViewData["StageId"] = new SelectList(_context.Stages, "StageId", "StageName", teams.StageId);
            return View(teams);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams.FindAsync(id);
            if (teams == null)
            {
                return NotFound();
            }
            ViewData["RegionsId"] = new SelectList(_context.Regions, "RegionsId", "RegionsName", teams.RegionsId);
            ViewData["StageId"] = new SelectList(_context.Stages, "StageId", "StageName", teams.StageId);
            return View(teams);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamsId,TeamsName,TeamsStadium,RegionsId,StageId")] Teams teams)
        {
            if (id != teams.TeamsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamsExists(teams.TeamsId))
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
            ViewData["RegionsId"] = new SelectList(_context.Regions, "RegionsId", "RegionsName", teams.RegionsId);
            ViewData["StageId"] = new SelectList(_context.Stages, "StageId", "StageName", teams.StageId);
            return View(teams);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams
                .Include(t => t.Regions)
                .Include(t => t.Stages)
                .FirstOrDefaultAsync(m => m.TeamsId == id);
            if (teams == null)
            {
                return NotFound();
            }

            return View(teams);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teams = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(teams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamsExists(int id)
        {
            return _context.Teams.Any(e => e.TeamsId == id);
        }
    }
}
