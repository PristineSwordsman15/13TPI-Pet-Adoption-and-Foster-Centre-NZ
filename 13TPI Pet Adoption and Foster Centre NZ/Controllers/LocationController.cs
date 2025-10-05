using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class LocationController : Controller
{
    private readonly Context _context;
    public LocationController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["CitySortParm"] = string.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var locations = _context.Location.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            locations = locations.Where(l => l.City.Contains(searchString) || l.Surburb.Contains(searchString));

        locations = sortOrder == "city_desc" ? locations.OrderByDescending(l => l.City) : locations.OrderBy(l => l.City);

        return View(await PaginatedList<Location>.CreateAsync(locations.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Location location)
    {
        if (ModelState.IsValid) { _context.Add(location); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(location);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var location = await _context.Location.FindAsync(id);
        if (location == null) return NotFound();
        return View(location);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Location location)
    {
        if (id != location.LocationID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(location); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Location.Any(e => e.LocationID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(location);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var location = await _context.Location.FirstOrDefaultAsync(l => l.LocationID == id);
        if (location == null) return NotFound();
        return View(location);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var location = await _context.Location.FirstOrDefaultAsync(l => l.LocationID == id);
        if (location == null) return NotFound();
        return View(location);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var location = await _context.Location.FindAsync(id);
        _context.Location.Remove(location);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
