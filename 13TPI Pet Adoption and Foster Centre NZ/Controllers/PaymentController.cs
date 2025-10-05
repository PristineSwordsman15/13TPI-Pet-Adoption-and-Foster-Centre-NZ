using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PaymentController : Controller
{
    private readonly Context _context;
    public PaymentController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["AmountSortParm"] = string.IsNullOrEmpty(sortOrder) ? "amount_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var payments = _context.Payment
            .Include(p => p.PaymentType)
            .Include(p => p.PaymentMethod)
            .Include(p => p.PaymentStatus)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            payments = payments.Where(p => p.UserID.Contains(searchString));

        payments = sortOrder == "amount_desc" ? payments.OrderByDescending(p => p.Amount) : payments.OrderBy(p => p.Amount);

        return View(await PaginatedList<Payment>.CreateAsync(payments.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create()
    {
        ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name");
        ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name");
        ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Payment payment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
        ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
        ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
        return View(payment);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var payment = await _context.Payment.FindAsync(id);
        if (payment == null) return NotFound();

        ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
        ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
        ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
        return View(payment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Payment payment)
    {
        if (id != payment.PaymentID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(payment); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Payment.Any(e => e.PaymentID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
        ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
        ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
        return View(payment);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var payment = await _context.Payment
            .Include(p => p.PaymentType)
            .Include(p => p.PaymentMethod)
            .Include(p => p.PaymentStatus)
            .FirstOrDefaultAsync(p => p.PaymentID == id);
        if (payment == null) return NotFound();
        return View(payment);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var payment = await _context.Payment
            .Include(p => p.PaymentType)
            .Include(p => p.PaymentMethod)
            .Include(p => p.PaymentStatus)
            .FirstOrDefaultAsync(p => p.PaymentID == id);
        if (payment == null) return NotFound();
        return View(payment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var payment = await _context.Payment.FindAsync(id);
        _context.Payment.Remove(payment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
