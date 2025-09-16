using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly Context _context;

        public PaymentsController(Context context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var context = _context.Payment.Include(p => p.PaymentMethod).Include(p => p.PaymentStatus).Include(p => p.PaymentType);
            return View(await context.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name");
            ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,Amount,Date,PaymentTypeID,PaymentMethodID,PaymentStatusID,UserID")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,Amount,Date,PaymentTypeID,PaymentMethodID,PaymentStatusID,UserID")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentMethodID"] = new SelectList(_context.PaymentMethod, "PaymentMethodID", "Name", payment.PaymentMethodID);
            ViewData["PaymentStatusID"] = new SelectList(_context.PaymentStatus, "PaymentStatusID", "StatusName", payment.PaymentStatusID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentType, "PaymentTypeID", "Name", payment.PaymentTypeID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.PaymentMethod)
                .Include(p => p.PaymentStatus)
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentID == id);
        }
    }
}
