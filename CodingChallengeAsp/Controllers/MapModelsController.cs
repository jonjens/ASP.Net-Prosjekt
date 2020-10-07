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
    public class MapModelsController : Controller
    {
        private readonly FootballContext _context;

        public MapModelsController(FootballContext context)
        {
            _context = context;
        }

        // GET: MapModels
        public IActionResult Index()
        {
            return View();
        }

        // GET: MapModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapModel = await _context.MapModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapModel == null)
            {
                return NotFound();
            }

            return View(mapModel);
        }

        // GET: MapModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MapModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] MapModel mapModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapModel);
        }

        // GET: MapModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapModel = await _context.MapModel.FindAsync(id);
            if (mapModel == null)
            {
                return NotFound();
            }
            return View(mapModel);
        }

        // POST: MapModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] MapModel mapModel)
        {
            if (id != mapModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapModelExists(mapModel.Id))
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
            return View(mapModel);
        }

        // GET: MapModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapModel = await _context.MapModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapModel == null)
            {
                return NotFound();
            }

            return View(mapModel);
        }

        // POST: MapModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapModel = await _context.MapModel.FindAsync(id);
            _context.MapModel.Remove(mapModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapModelExists(int id)
        {
            return _context.MapModel.Any(e => e.Id == id);
        }
    }
}
