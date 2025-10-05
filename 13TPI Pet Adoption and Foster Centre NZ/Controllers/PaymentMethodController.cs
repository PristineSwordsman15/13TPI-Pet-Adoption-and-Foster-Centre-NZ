using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PaymentMethodController : Controller
{
    private readonly Context _context;
    public PaymentMethodController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var methods = _context.PaymentMethod.AsQueryable();
        if (!string.IsNullOrEmpty(searchString))
            methods = methods.Where(p => p.Name.Contains(searchString));

        methods = sortOrder == "name_desc" ? methods.OrderByDescending(p => p.Name) : methods.OrderBy(p => p.Name);
        return View(await PaginatedList<PaymentMethod>.CreateAsync(methods.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaymentMethod method)
    {
        if (ModelState.IsValid) { _context.Add(method); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        return View(method);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var method = await _context.PaymentMethod.FindAsync(id);
        if (method == null) return NotFound();
        return View(method);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PaymentMethod method)
    {
        if (id != method.PaymentMethodID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(method); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.PaymentMethod.Any(e => e.PaymentMethodID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        return View(method);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var method = await _context.PaymentMethod.FirstOrDefaultAsync(p => p.PaymentMethodID == id);
        if (method == null) return NotFound();
        return View(method);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var method = await _context.PaymentMethod.FirstOrDefaultAsync(p => p.PaymentMethodID == id);
        if (method == null) return NotFound();
        return View(method);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var method = await _context.PaymentMethod.FindAsync(id);
        _context.PaymentMethod.Remove(method);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
