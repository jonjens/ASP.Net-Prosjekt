using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingChallengeAsp.Data;
using CodingChallengeAsp.Models;

namespace CodingChallengeAsp.Controllers
{
    public class PlayerSponsorsController : Controller
    {
        private readonly FootballContext _context;

        public PlayerSponsorsController(FootballContext context)
        {
            _context = context;
        }

        // GET: PlayerSponsors
        public async Task<IActionResult> Index()
        {
            var footballContext = _context.PlayerSponsor.Include(p => p.Player).Include(p => p.Sponsor);
            return View(await footballContext.ToListAsync());
        }

        // GET: PlayerSponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSponsor = await _context.PlayerSponsor
                .Include(p => p.Player)
                .Include(p => p.Sponsor)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerSponsor == null)
            {
                return NotFound();
            }

            return View(playerSponsor);
        }

        // GET: PlayerSponsors/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "PlayerId");
            ViewData["SponsorId"] = new SelectList(_context.Sponsor, "SponsorId", "SponsorId");
            return View();
        }

        // POST: PlayerSponsors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,SponsorId")] PlayerSponsor playerSponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerSponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "PlayerId", playerSponsor.PlayerId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsor, "SponsorId", "SponsorId", playerSponsor.SponsorId);
            return View(playerSponsor);
        }

        // GET: PlayerSponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSponsor = await _context.PlayerSponsor.FindAsync(id);
            if (playerSponsor == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "PlayerId", playerSponsor.PlayerId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsor, "SponsorId", "SponsorId", playerSponsor.SponsorId);
            return View(playerSponsor);
        }

        // POST: PlayerSponsors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,SponsorId")] PlayerSponsor playerSponsor)
        {
            if (id != playerSponsor.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerSponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerSponsorExists(playerSponsor.PlayerId))
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
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "PlayerId", playerSponsor.PlayerId);
            ViewData["SponsorId"] = new SelectList(_context.Sponsor, "SponsorId", "SponsorId", playerSponsor.SponsorId);
            return View(playerSponsor);
        }

        // GET: PlayerSponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSponsor = await _context.PlayerSponsor
                .Include(p => p.Player)
                .Include(p => p.Sponsor)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerSponsor == null)
            {
                return NotFound();
            }

            return View(playerSponsor);
        }

        // POST: PlayerSponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerSponsor = await _context.PlayerSponsor.FindAsync(id);
            _context.PlayerSponsor.Remove(playerSponsor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerSponsorExists(int id)
        {
            return _context.PlayerSponsor.Any(e => e.PlayerId == id);
        }
    }
}
