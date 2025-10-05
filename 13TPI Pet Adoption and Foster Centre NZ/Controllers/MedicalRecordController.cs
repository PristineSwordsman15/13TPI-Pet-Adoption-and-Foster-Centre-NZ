using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class MedicalRecordController : Controller
{
    private readonly Context _context;
    public MedicalRecordController(Context context) => _context = context;

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var records = _context.MedicalRecord
            .Include(r => r.Pet)
            .Include(r => r.VaccinationStatus)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            records = records.Where(r => r.Notes.Contains(searchString) || r.Pet.Name.Contains(searchString));

        records = sortOrder == "date_desc" ? records.OrderByDescending(r => r.Date) : records.OrderBy(r => r.Date);

        return View(await PaginatedList<MedicalRecord>.CreateAsync(records.AsNoTracking(), pageNumber, 6));
    }

    public IActionResult Create()
    {
        ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name");
        ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName");
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MedicalRecord record)
    {
        if (ModelState.IsValid)
        {
            _context.Add(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", record.PetID);
        ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", record.VaccinationStatusID);
        return View(record);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var record = await _context.MedicalRecord.FindAsync(id);
        if (record == null) return NotFound();
        ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", record.PetID);
        ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", record.VaccinationStatusID);
        return View(record);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MedicalRecord record)
    {
        if (id != record.MedicalRecordID) return NotFound();
        if (ModelState.IsValid)
        {
            try { _context.Update(record); await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.MedicalRecord.Any(e => e.MedicalRecordID == id)) return NotFound(); else throw; }
            return RedirectToAction(nameof(Index));
        }
        ViewData["PetID"] = new SelectList(_context.Pet, "PetID", "Name", record.PetID);
        ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", record.VaccinationStatusID);
        return View(record);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var record = await _context.MedicalRecord
            .Include(r => r.Pet)
            .Include(r => r.VaccinationStatus)
            .FirstOrDefaultAsync(r => r.MedicalRecordID == id);
        if (record == null) return NotFound();
        return View(record);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var record = await _context.MedicalRecord
            .Include(r => r.Pet)
            .Include(r => r.VaccinationStatus)
            .FirstOrDefaultAsync(r => r.MedicalRecordID == id);
        if (record == null) return NotFound();
        return View(record);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var record = await _context.MedicalRecord.FindAsync(id);
        _context.MedicalRecord.Remove(record);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
