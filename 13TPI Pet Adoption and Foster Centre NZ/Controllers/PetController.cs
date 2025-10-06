using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class PetController : Controller
    {
        private readonly Context _context;

        public PetController(Context context)
        {
            _context = context;
        }

        // GET: Pet
        public async Task<IActionResult> Index(string searchString, int? petStatusId, int? vaccinationStatusId, int? shelterId,
                                              string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AgeSortParm"] = sortOrder == "Age" ? "age_desc" : "Age";

            var pets = _context.Pet
                .Include(p => p.PetStatus)
                .Include(p => p.VaccinationStatus)
                .Include(p => p.Shelter)
                .AsQueryable();

            // Searching
            if (!String.IsNullOrEmpty(searchString))
            {
                pets = pets.Where(p => p.Name.Contains(searchString) || p.Breed.Contains(searchString));
            }

            // Filtering
            if (petStatusId.HasValue)
                pets = pets.Where(p => p.PetStatusID == petStatusId.Value);
            if (vaccinationStatusId.HasValue)
                pets = pets.Where(p => p.VaccinationStatusID == vaccinationStatusId.Value);
            if (shelterId.HasValue)
                pets = pets.Where(p => p.ShelterID == shelterId.Value);

            // Sorting
            pets = sortOrder switch
            {
                "name_desc" => pets.OrderByDescending(p => p.Name),
                "Age" => pets.OrderBy(p => p.Age),
                "age_desc" => pets.OrderByDescending(p => p.Age),
                _ => pets.OrderBy(p => p.Name),
            };

            // Dropdowns for filters
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", petStatusId);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", vaccinationStatusId);
            ViewData["ShelterID"] = new SelectList(_context.Shelter, "ShelterID", "Name", shelterId);

            return View(await PaginatedList<Pet>.CreateAsync(pets.AsNoTracking(), pageNumber, pageSize));
        }

        // GET: Pet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _context.Pet
                .Include(p => p.PetStatus)
                .Include(p => p.VaccinationStatus)
                .Include(p => p.Shelter)
                .FirstOrDefaultAsync(m => m.PetID == id);

            if (pet == null) return NotFound();

            return View(pet);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName");
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName");
            ViewData["ShelterID"] = new SelectList(_context.Shelter, "ShelterID", "Name");
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", pet.VaccinationStatusID);
            ViewData["ShelterID"] = new SelectList(_context.Shelter, "ShelterID", "Name", pet.ShelterID);
            return View(pet);
        }

        // GET: Pet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null) return NotFound();

            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", pet.VaccinationStatusID);
            ViewData["ShelterID"] = new SelectList(_context.Shelter, "ShelterID", "Name", pet.ShelterID);
            return View(pet);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pet pet)
        {
            if (id != pet.PetID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pet.Any(e => e.PetID == pet.PetID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
            ViewData["VaccinationStatusID"] = new SelectList(_context.VaccinationStatus, "VaccinationStatusID", "StatusName", pet.VaccinationStatusID);
            ViewData["ShelterID"] = new SelectList(_context.Shelter, "ShelterID", "Name", pet.ShelterID);
            return View(pet);
        }

        // GET: Pet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _context.Pet
                .Include(p => p.PetStatus)
                .Include(p => p.VaccinationStatus)
                .Include(p => p.Shelter)
                .FirstOrDefaultAsync(m => m.PetID == id);

            if (pet == null) return NotFound();

            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            if (pet != null)
            {
                _context.Pet.Remove(pet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
