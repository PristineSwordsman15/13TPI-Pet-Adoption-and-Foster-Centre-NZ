using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class TitleController : Controller
{
    private readonly Context _context;
    public TitleController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["TitleSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var titles = _context.Title.AsQueryable();
        if (!string.IsNullOrEmpty(searchString)) titles = titles.Where(t => t.TitleName.Contains(searchString));
        titles = sortOrder == "title_desc" ? titles.OrderByDescending(t => t.TitleName) : titles.OrderBy(t => t.TitleName);

        return View(await PaginatedList<Title>.CreateAsync(titles.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Title title)
    {
        if (ModelState.IsValid) { _context.Add(title); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(title);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var title = await _context.Title.FindAsync(id);
        if (title == null) return NotFound();
        return View(title);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Title title)
    {
        if (id != title.TitleID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(title); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Title.Any(e => e.TitleID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(title);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var title = await _context.Title.FirstOrDefaultAsync(t => t.TitleID == id);
        if (title == null) return NotFound();
        return View(title);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var title = await _context.Title.FirstOrDefaultAsync(t => t.TitleID == id);
        if (title == null) return NotFound();
        return View(title);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var title = await _context.Title.FindAsync(id);
        _context.Title.Remove(title);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
