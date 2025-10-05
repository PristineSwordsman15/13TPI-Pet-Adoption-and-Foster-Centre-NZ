using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PetGroupController : Controller
{
    private readonly Context _context;
    public PetGroupController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var groups = _context.PetGroup.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            groups = groups.Where(g => g.PetGroupName.Contains(searchString));

        groups = sortOrder == "name_desc" ? groups.OrderByDescending(g => g.PetGroupName) : groups.OrderBy(g => g.PetGroupName);

        return View(await PaginatedList<PetGroup>.CreateAsync(groups.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PetGroup group)
    {
        if (ModelState.IsValid) { _context.Add(group); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(group);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var group = await _context.PetGroup.FindAsync(id);
        if (group == null) return NotFound();
        return View(group);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PetGroup group)
    {
        if (id != group.PetGroupID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(group); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.PetGroup.Any(e => e.PetGroupID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(group);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var group = await _context.PetGroup.FirstOrDefaultAsync(g => g.PetGroupID == id);
        if (group == null) return NotFound();
        return View(group);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var group = await _context.PetGroup.FirstOrDefaultAsync(g => g.PetGroupID == id);
        if (group == null) return NotFound();
        return View(group);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var group = await _context.PetGroup.FindAsync(id);
        _context.PetGroup.Remove(group);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
