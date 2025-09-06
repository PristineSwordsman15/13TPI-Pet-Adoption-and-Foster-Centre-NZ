using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class VaccinationStatusController : Controller
    {
        private readonly Context _context;

        public VaccinationStatusController(Context context)
        {
            _context = context;
        }

        // GET: VaccinationStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccinationStatus.ToListAsync());
        }

        // GET: VaccinationStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationStatus = await _context.VaccinationStatus
                .FirstOrDefaultAsync(m => m.VaccinationStatusID == id);
            if (vaccinationStatus == null)
            {
                return NotFound();
            }

            return View(vaccinationStatus);
        }

        // GET: VaccinationStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VaccinationStatusID,StatusName")] VaccinationStatus vaccinationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccinationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationStatus);
        }

        // GET: VaccinationStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationStatus = await _context.VaccinationStatus.FindAsync(id);
            if (vaccinationStatus == null)
            {
                return NotFound();
            }
            return View(vaccinationStatus);
        }

        // POST: VaccinationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccinationStatusID,StatusName")] VaccinationStatus vaccinationStatus)
        {
            if (id != vaccinationStatus.VaccinationStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccinationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationStatusExists(vaccinationStatus.VaccinationStatusID))
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
            return View(vaccinationStatus);
        }

        // GET: VaccinationStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationStatus = await _context.VaccinationStatus
                .FirstOrDefaultAsync(m => m.VaccinationStatusID == id);
            if (vaccinationStatus == null)
            {
                return NotFound();
            }

            return View(vaccinationStatus);
        }

        // POST: VaccinationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccinationStatus = await _context.VaccinationStatus.FindAsync(id);
            if (vaccinationStatus != null)
            {
                _context.VaccinationStatus.Remove(vaccinationStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationStatusExists(int id)
        {
            return _context.VaccinationStatus.Any(e => e.VaccinationStatusID == id);
        }
    }
}
