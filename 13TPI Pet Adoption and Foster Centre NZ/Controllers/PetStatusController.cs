using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PetStatusController : Controller
{
    private readonly Context _context;
    public PetStatusController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["StatusSortParm"] = string.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var statuses = _context.PetStatus.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            statuses = statuses.Where(s => s.StatusName.Contains(searchString));

        statuses = sortOrder == "status_desc" ? statuses.OrderByDescending(s => s.StatusName) : statuses.OrderBy(s => s.StatusName);

        return View(await PaginatedList<PetStatus>.CreateAsync(statuses.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PetStatus status)
    {
        if (ModelState.IsValid) { _context.Add(status); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(status);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var status = await _context.PetStatus.FindAsync(id);
        if (status == null) return NotFound();
        return View(status);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PetStatus status)
    {
        if (id != status.PetStatusID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(status); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.PetStatus.Any(e => e.PetStatusID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(status);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var status = await _context.PetStatus.FirstOrDefaultAsync(s => s.PetStatusID == id);
        if (status == null) return NotFound();
        return View(status);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var status = await _context.PetStatus.FirstOrDefaultAsync(s => s.PetStatusID == id);
        if (status == null) return NotFound();
        return View(status);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var status = await _context.PetStatus.FindAsync(id);
        _context.PetStatus.Remove(status);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
