using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class FranchisesController : Controller
{
    private readonly Context _context;
    public FranchisesController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var franchises = _context.Franchise.Include(f => f.Location).AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            franchises = franchises.Where(f => f.FranchiseName.Contains(searchString));

        franchises = sortOrder == "name_desc" ? franchises.OrderByDescending(f => f.FranchiseName) : franchises.OrderBy(f => f.FranchiseName);

        return View(await PaginatedList<Franchise>.CreateAsync(franchises.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create()
    {
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Franchise franchise)
    {
        if (ModelState.IsValid)
        {
            _context.Add(franchise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", franchise.LocationID);
        return View(franchise);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var franchise = await _context.Franchise.FindAsync(id);
        if (franchise == null) return NotFound();
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", franchise.LocationID);
        return View(franchise);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Franchise franchise)
    {
        if (id != franchise.FranchiseID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(franchise); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Franchise.Any(e => e.FranchiseID == id)) return NotFound(); else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Address", franchise.LocationID);
        return View(franchise);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var franchise = await _context.Franchise.Include(f => f.Location).FirstOrDefaultAsync(f => f.FranchiseID == id);
        if (franchise == null) return NotFound();
        return View(franchise);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var franchise = await _context.Franchise.Include(f => f.Location).FirstOrDefaultAsync(f => f.FranchiseID == id);
        if (franchise == null) return NotFound();
        return View(franchise);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var franchise = await _context.Franchise.FindAsync(id);
        _context.Franchise.Remove(franchise);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
