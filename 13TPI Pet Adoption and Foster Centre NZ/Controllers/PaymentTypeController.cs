using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PaymentTypeController : Controller
{
    private readonly Context _context;
    public PaymentTypeController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var types = _context.PaymentType.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            types = types.Where(p => p.Name.Contains(searchString));

        types = sortOrder == "name_desc" ? types.OrderByDescending(p => p.Name) : types.OrderBy(p => p.Name);

        return View(await PaginatedList<PaymentType>.CreateAsync(types.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaymentType type)
    {
        if (ModelState.IsValid) { _context.Add(type); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(type);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var type = await _context.PaymentType.FindAsync(id);
        if (type == null) return NotFound();
        return View(type);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PaymentType type)
    {
        if (id != type.PaymentTypeID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(type); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.PaymentType.Any(e => e.PaymentTypeID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(type);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var type = await _context.PaymentType.FirstOrDefaultAsync(p => p.PaymentTypeID == id);
        if (type == null) return NotFound();
        return View(type);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var type = await _context.PaymentType.FirstOrDefaultAsync(p => p.PaymentTypeID == id);
        if (type == null) return NotFound();
        return View(type);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var type = await _context.PaymentType.FindAsync(id);
        _context.PaymentType.Remove(type);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
