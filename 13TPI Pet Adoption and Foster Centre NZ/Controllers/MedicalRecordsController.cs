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
    public class MedicalRecordsController : Controller
    {
        private readonly Context _context;

        public MedicalRecordsController(Context context)
        {
            _context = context;
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index()
        {
            var context = _context.MedicalRecord.Include(m => m.Pet).Include(m => m.VaccinationStatus);
            return View(await context.ToListAsync());
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Pet)
                .Include(m => m.VaccinationStatus)
                .FirstOrDefaultAsync(m => m.MedicalRecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create()
        {
            ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name");
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName");
            return View();
        }

        // POST: MedicalRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalRecordID,Date,Notes,PetID,VaccinationStatusID")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", medicalRecord.PetID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", medicalRecord.VaccinationStatusID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", medicalRecord.PetID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", medicalRecord.VaccinationStatusID);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalRecordID,Date,Notes,PetID,VaccinationStatusID")] MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.MedicalRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.MedicalRecordID))
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
            ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", medicalRecord.PetID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", medicalRecord.VaccinationStatusID);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Pet)
                .Include(m => m.VaccinationStatus)
                .FirstOrDefaultAsync(m => m.MedicalRecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            if (medicalRecord != null)
            {
                _context.MedicalRecord.Remove(medicalRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecord.Any(e => e.MedicalRecordID == id);
        }
    }
}
