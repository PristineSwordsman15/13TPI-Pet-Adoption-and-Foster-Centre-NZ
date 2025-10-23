using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class SheltersController : Controller
    {
        private readonly Context _context;

        public SheltersController(Context context)
        {
            _context = context;
        }

        // GET: Shelters
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? locationFilter,
            int page = 1,
            int pageSize = 10)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["LocationFilter"] = locationFilter;

            var shelters = _context.Shelter.Include(s => s.Location).AsQueryable();

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                shelters = shelters.Where(s => s.ShelterName.Contains(searchString));
            }

            // Filtering
            if (locationFilter.HasValue)
            {
                shelters = shelters.Where(s => s.LocationID == locationFilter.Value);
            }

            // Sorting
            shelters = sortOrder switch
            {
                "name_desc" => shelters.OrderByDescending(s => s.ShelterName),
                _ => shelters.OrderBy(s => s.ShelterName),
            };

            // Pagination
            var pagedShelters = await PaginatedList<Shelter>.CreateAsync(shelters.AsNoTracking(), page, pageSize);

            ViewData["TotalPages"] = pagedShelters.TotalPages;
            ViewData["CurrentPage"] = page;
            ViewData["Locations"] = new SelectList(_context.Location.OrderBy(l => l.LocationName), "LocationID", "LocationName");

            return View(pagedShelters);
        }

        // GET: Shelters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var shelter = await _context.Shelter
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.ShelterID == id);

            if (shelter == null) return NotFound();

            return View(shelter);
        }

        // GET: Shelters/Create
        public IActionResult Create()
        {
            ViewData["Locations"] = new SelectList(_context.Location, "LocationID", "LocationName,ShelterID");
            return View();
        }

        // POST: Shelters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelterID,ShelterName,LocationID")] Shelter shelter)
        {
            if (!ModelState.IsValid)
            {
                //Check if any locations exist
                if (!_context.Location.Any())
                {
                    //Create a default location automatically
                    var defaultLocation = new Location
                    {
                        LocationName = "NorthWest Mall",
                        Street = "123 Pino Street",
                        City = "Dunedin",
                        State = "Otago",
                        ZipCode = "2916",
                        Country = "New Zealand"
                    };

                    _context.Location.Add(defaultLocation);
                    await _context.SaveChangesAsync();

                    //Assign the default location ID to the new shelter
                    shelter.LocationID = defaultLocation.LocationID;
                }

                // If user didn’t pick a location, use the first available one
                if (shelter.LocationID == 0)
                {
                    shelter.LocationID = _context.Location.First().LocationID;
                }

                _context.Add(shelter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationName", shelter.LocationID);
            return View(shelter);
        }



        // GET: Shelters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter == null) return NotFound();

            ViewData["Locations"] = new SelectList(_context.Location, "LocationID", "LocationName", shelter.LocationID);
            return View(shelter);
        }

        // POST: Shelters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShelterID,ShelterName,LocationID")] Shelter shelter)
        {
            if (id != shelter.ShelterID) return NotFound();

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Shelter.Any(e => e.ShelterID == shelter.ShelterID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Locations"] = new SelectList(_context.Location, "LocationID", "LocationName", shelter.LocationID);
            return View(shelter);
        }

        // GET: Shelters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var shelter = await _context.Shelter
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.ShelterID == id);
            if (shelter == null) return NotFound();

            return View(shelter);
        }

        // POST: Shelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter != null) _context.Shelter.Remove(shelter);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
