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
    public class PlayersPositionsController : Controller
    {
        private readonly MContext _context;

        public PlayersPositionsController(MContext context)
        {
            _context = context;
        }

        // GET: PlayersPositions
        public async Task<IActionResult> Index()
        {
            var mContext = _context.PlayersPositions.Include(p => p.Players).Include(p => p.Positions);
            return View(await mContext.ToListAsync());
        }

        // GET: PlayersPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersPositions = await _context.PlayersPositions
                .Include(p => p.Players)
                .Include(p => p.Positions)
                .FirstOrDefaultAsync(m => m.PlayersId == id);
            if (playersPositions == null)
            {
                return NotFound();
            }

            return View(playersPositions);
        }

        // GET: PlayersPositions/Create
        public IActionResult Create()
        {
            ViewData["PlayersId"] = new SelectList(_context.Players, "PlayersId", "PlayersId");
            ViewData["PositionsId"] = new SelectList(_context.Positions, "PositionsId", "PositionsId");
            return View();
        }

        // POST: PlayersPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayersId,PositionsId")] PlayersPositions playersPositions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playersPositions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayersId"] = new SelectList(_context.Players, "PlayersId", "PlayersId", playersPositions.PlayersId);
            ViewData["PositionsId"] = new SelectList(_context.Positions, "PositionsId", "PositionsId", playersPositions.PositionsId);
            return View(playersPositions);
        }

        // GET: PlayersPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersPositions = await _context.PlayersPositions.FindAsync(id);
            if (playersPositions == null)
            {
                return NotFound();
            }
            ViewData["PlayersId"] = new SelectList(_context.Players, "PlayersId", "PlayersId", playersPositions.PlayersId);
            ViewData["PositionsId"] = new SelectList(_context.Positions, "PositionsId", "PositionsId", playersPositions.PositionsId);
            return View(playersPositions);
        }

        // POST: PlayersPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayersId,PositionsId")] PlayersPositions playersPositions)
        {
            if (id != playersPositions.PlayersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playersPositions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayersPositionsExists(playersPositions.PlayersId))
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
            ViewData["PlayersId"] = new SelectList(_context.Players, "PlayersId", "PlayersId", playersPositions.PlayersId);
            ViewData["PositionsId"] = new SelectList(_context.Positions, "PositionsId", "PositionsId", playersPositions.PositionsId);
            return View(playersPositions);
        }

        // GET: PlayersPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playersPositions = await _context.PlayersPositions
                .Include(p => p.Players)
                .Include(p => p.Positions)
                .FirstOrDefaultAsync(m => m.PlayersId == id);
            if (playersPositions == null)
            {
                return NotFound();
            }

            return View(playersPositions);
        }

        // POST: PlayersPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playersPositions = await _context.PlayersPositions.FindAsync(id);
            _context.PlayersPositions.Remove(playersPositions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayersPositionsExists(int id)
        {
            return _context.PlayersPositions.Any(e => e.PlayersId == id);
        }
    }
}
