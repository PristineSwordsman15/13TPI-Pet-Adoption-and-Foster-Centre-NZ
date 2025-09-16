using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class SheltersController : Controller
    {
        private readonly Context _context;

        public SheltersController(Context context)
        {
            _context = context;
        }

        // GET: Shelters
        public async Task<IActionResult> Index()
        {
            var context = _context.Shelter.Include(s => s.Franchise).Include(s => s.Location).Include(s => s.ShelterType);
            return View(await context.ToListAsync());
        }

        // GET: Shelters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter
                .Include(s => s.Franchise)
                .Include(s => s.Location)
                .Include(s => s.ShelterType)
                .FirstOrDefaultAsync(m => m.ShelterID == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // GET: Shelters/Create
        public IActionResult Create()
        {
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID");
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address");
            ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name");
            return View();
        }

        // POST: Shelters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelterID,Name,FranchiseID,LocationID,ShelterTypeID")] Shelter shelter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shelter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", shelter.FranchiseID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
            ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
            return View(shelter);
        }

        // GET: Shelters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter == null)
            {
                return NotFound();
            }
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", shelter.FranchiseID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
            ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
            return View(shelter);
        }

        // POST: Shelters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShelterID,Name,FranchiseID,LocationID,ShelterTypeID")] Shelter shelter)
        {
            if (id != shelter.ShelterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelterExists(shelter.ShelterID))
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
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", shelter.FranchiseID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
            ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
            return View(shelter);
        }

        // GET: Shelters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelter
                .Include(s => s.Franchise)
                .Include(s => s.Location)
                .Include(s => s.ShelterType)
                .FirstOrDefaultAsync(m => m.ShelterID == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // POST: Shelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter != null)
            {
                _context.Shelter.Remove(shelter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelterExists(int id)
        {
            return _context.Shelter.Any(e => e.ShelterID == id);
        }
    }
}
