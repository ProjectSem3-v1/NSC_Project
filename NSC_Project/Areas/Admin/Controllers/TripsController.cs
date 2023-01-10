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
    public class TripsController : Controller
    {
        private readonly NSC_ProjectContext _context;

        public TripsController(NSC_ProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Trips
        public async Task<IActionResult> Index()
        {
            var nSC_ProjectContext = _context.Trip.Include(t => t.AirlineCompany).Include(t => t.FlightRoute).Include(t => t.Plane);
            return View(await nSC_ProjectContext.ToListAsync());
        }

        // GET: Admin/Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.AirlineCompany)
                .Include(t => t.FlightRoute)
                .Include(t => t.Plane)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Admin/Trips/Create
        public IActionResult Create()
        {
            ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompany, "Id", "Id");
            ViewData["FlightRouteId"] = new SelectList(_context.FlightRoute, "Id", "Id");
            ViewData["PlaneId"] = new SelectList(_context.Plane, "Id", "Id");
            return View();
        }

        // POST: Admin/Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,FinishDate,FlightTime,Status,PlaneId,FlightRouteId,AirlineCompanyId")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompany, "Id", "Id", trip.AirlineCompanyId);
            ViewData["FlightRouteId"] = new SelectList(_context.FlightRoute, "Id", "Id", trip.FlightRouteId);
            ViewData["PlaneId"] = new SelectList(_context.Plane, "Id", "Id", trip.PlaneId);
            return View(trip);
        }

        // GET: Admin/Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompany, "Id", "Id", trip.AirlineCompanyId);
            ViewData["FlightRouteId"] = new SelectList(_context.FlightRoute, "Id", "Id", trip.FlightRouteId);
            ViewData["PlaneId"] = new SelectList(_context.Plane, "Id", "Id", trip.PlaneId);
            return View(trip);
        }

        // POST: Admin/Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,FinishDate,FlightTime,Status,PlaneId,FlightRouteId,AirlineCompanyId")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
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
            ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompany, "Id", "Id", trip.AirlineCompanyId);
            ViewData["FlightRouteId"] = new SelectList(_context.FlightRoute, "Id", "Id", trip.FlightRouteId);
            ViewData["PlaneId"] = new SelectList(_context.Plane, "Id", "Id", trip.PlaneId);
            return View(trip);
        }

        // GET: Admin/Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trip == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.AirlineCompany)
                .Include(t => t.FlightRoute)
                .Include(t => t.Plane)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Admin/Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trip == null)
            {
                return Problem("Entity set 'NSC_ProjectContext.Trip'  is null.");
            }
            var trip = await _context.Trip.FindAsync(id);
            if (trip != null)
            {
                _context.Trip.Remove(trip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
          return (_context.Trip?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
