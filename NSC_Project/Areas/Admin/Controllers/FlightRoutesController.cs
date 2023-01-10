using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSC_Project.Data;
using NSC_Project.Models;

namespace NSC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class FlightRoutesController : Controller
    {
        private readonly NSC_ProjectContext _context;

        public FlightRoutesController(NSC_ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/FlightRoutes
        public async Task<IActionResult> Index()
        {
            var nSC_ProjectContext = _context.FlightRoute.Include(f => f.AirportFrom).Include(f => f.AirportTo);
            return View(await nSC_ProjectContext.ToListAsync());
        }

        // GET: Admin/FlightRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightRoute == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute
                .Include(f => f.AirportFrom)
                .Include(f => f.AirportTo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // GET: Admin/FlightRoutes/Create
        public IActionResult Create()
        {
            ViewData["AirportFromId"] = new SelectList(_context.AirportFrom, "Id", "Address");
            ViewData["AirportToId"] = new SelectList(_context.AirportTo, "Id", "Address");
            return View();
        }

        // POST: Admin/FlightRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirportFromId,AirportToId")] FlightRoute flightRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirportFromId"] = new SelectList(_context.AirportFrom, "Id", "Id", flightRoute.AirportFromId);
            ViewData["AirportToId"] = new SelectList(_context.AirportTo, "Id", "Id", flightRoute.AirportToId);
            return View(flightRoute);
        }

        // GET: Admin/FlightRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightRoute == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute.FindAsync(id);
            if (flightRoute == null)
            {
                return NotFound();
            }
            ViewData["AirportFromId"] = new SelectList(_context.AirportFrom, "Id", "Id", flightRoute.AirportFromId);
            ViewData["AirportToId"] = new SelectList(_context.AirportTo, "Id", "Id", flightRoute.AirportToId);
            return View(flightRoute);
        }

        // POST: Admin/FlightRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirportFromId,AirportToId")] FlightRoute flightRoute)
        {
            if (id != flightRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightRouteExists(flightRoute.Id))
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
            ViewData["AirportFromId"] = new SelectList(_context.AirportFrom, "Id", "Id", flightRoute.AirportFromId);
            ViewData["AirportToId"] = new SelectList(_context.AirportTo, "Id", "Id", flightRoute.AirportToId);
            return View(flightRoute);
        }

        // GET: Admin/FlightRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightRoute == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute
                .Include(f => f.AirportFrom)
                .Include(f => f.AirportTo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // POST: Admin/FlightRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightRoute == null)
            {
                return Problem("Entity set 'NSC_ProjectContext.FlightRoute'  is null.");
            }
            var flightRoute = await _context.FlightRoute.FindAsync(id);
            if (flightRoute != null)
            {
                _context.FlightRoute.Remove(flightRoute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightRouteExists(int id)
        {
          return (_context.FlightRoute?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
