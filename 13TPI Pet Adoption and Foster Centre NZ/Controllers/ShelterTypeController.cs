using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class ShelterTypeController : Controller
{
    private readonly Context _context;
    public ShelterTypeController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var shelterTypes = _context.ShelterType.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            shelterTypes = shelterTypes.Where(s => s.Name.Contains(searchString));

        shelterTypes = sortOrder == "name_desc" ? shelterTypes.OrderByDescending(s => s.Name) : shelterTypes.OrderBy(s => s.Name);

        return View(await PaginatedList<ShelterType>.CreateAsync(shelterTypes.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ShelterType shelterType)
    {
        if (ModelState.IsValid) { _context.Add(shelterType); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(shelterType);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var shelterType = await _context.ShelterType.FindAsync(id);
        if (shelterType == null) return NotFound();
        return View(shelterType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ShelterType shelterType)
    {
        if (id != shelterType.ShelterTypeID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(shelterType); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.ShelterType.Any(e => e.ShelterTypeID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(shelterType);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var shelterType = await _context.ShelterType.FirstOrDefaultAsync(s => s.ShelterTypeID == id);
        if (shelterType == null) return NotFound();
        return View(shelterType);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var shelterType = await _context.ShelterType.FirstOrDefaultAsync(s => s.ShelterTypeID == id);
        if (shelterType == null) return NotFound();
        return View(shelterType);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var shelterType = await _context.ShelterType.FindAsync(id);
        _context.ShelterType.Remove(shelterType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
