using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly Context _context;

        public LocationsController(Context context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int page = 1,
            int pageSize = 10)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["CurrentFilter"] = searchString;

            var locations = _context.Location.AsQueryable();

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(l => l.LocationName.Contains(searchString) || l.City.Contains(searchString));
            }

            // Sorting
            locations = sortOrder switch
            {
                "name_desc" => locations.OrderByDescending(l => l.LocationName),
                "City" => locations.OrderBy(l => l.City),
                "city_desc" => locations.OrderByDescending(l => l.City),
                _ => locations.OrderBy(l => l.LocationName),
            };

            // Pagination
            var pagedLocations = await PaginatedList<Location>.CreateAsync(locations.AsNoTracking(), page, pageSize);

            ViewData["TotalPages"] = pagedLocations.TotalPages;
            ViewData["CurrentPage"] = page;

            return View(pagedLocations);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var location = await _context.Location.FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null) return NotFound();

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,LocationName,Street,City,State,ZipCode,Country")] Location location)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var location = await _context.Location.FindAsync(id);
            if (location == null) return NotFound();

            return View(location);
        }

        // POST: Locations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,LocationName,Street,City,State,ZipCode,Country")] Location location)
        {
            if (id != location.LocationID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Location.Any(e => e.LocationID == location.LocationID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var location = await _context.Location.FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null) return NotFound();

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location != null) _context.Location.Remove(location);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
