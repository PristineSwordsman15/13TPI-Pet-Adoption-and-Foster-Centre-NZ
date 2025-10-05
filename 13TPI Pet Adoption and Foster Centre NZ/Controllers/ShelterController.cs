using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class ShelterController : Controller
{
    private readonly Context _context;
    public ShelterController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var shelters = _context.Shelter
            .Include(s => s.Franchise)
            .Include(s => s.Location)
            .Include(s => s.ShelterType)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            shelters = shelters.Where(s => s.Name.Contains(searchString));

        shelters = sortOrder == "name_desc" ? shelters.OrderByDescending(s => s.Name) : shelters.OrderBy(s => s.Name);

        return View(await PaginatedList<Shelter>.CreateAsync(shelters.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create()
    {
        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName");
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address");
        ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Shelter shelter)
    {
        if (ModelState.IsValid)
        {
            _context.Add(shelter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", shelter.FranchiseID);
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
        ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
        return View(shelter);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var shelter = await _context.Shelter.FindAsync(id);
        if (shelter == null) return NotFound();

        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", shelter.FranchiseID);
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
        ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
        return View(shelter);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Shelter shelter)
    {
        if (id != shelter.ShelterID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(shelter); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Shelter.Any(e => e.ShelterID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", shelter.FranchiseID);
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", shelter.LocationID);
        ViewData["ShelterTypeID"] = new SelectList(_context.ShelterType, "ShelterTypeID", "Name", shelter.ShelterTypeID);
        return View(shelter);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var shelter = await _context.Shelter
            .Include(s => s.Franchise)
            .Include(s => s.Location)
            .Include(s => s.ShelterType)
            .FirstOrDefaultAsync(s => s.ShelterID == id);
        if (shelter == null) return NotFound();
        return View(shelter);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var shelter = await _context.Shelter
            .Include(s => s.Franchise)
            .Include(s => s.Location)
            .Include(s => s.ShelterType)
            .FirstOrDefaultAsync(s => s.ShelterID == id);
        if (shelter == null) return NotFound();
        return View(shelter);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var shelter = await _context.Shelter.FindAsync(id);
        _context.Shelter.Remove(shelter);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
