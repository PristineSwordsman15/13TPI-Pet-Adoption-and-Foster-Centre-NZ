using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private readonly Context _context;

        public PetsController(Context context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? breedFilter,
    int? shelterFilter,
    bool? adoptionFilter,
    int page = 1,
    int pageSize = 10)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["BreedSortParm"] = sortOrder == "Breed" ? "breed_desc" : "Breed";
            ViewData["ShelterSortParm"] = sortOrder == "Shelter" ? "shelter_desc" : "Shelter";
            ViewData["CurrentFilter"] = searchString;
            ViewData["BreedFilter"] = breedFilter;
            ViewData["ShelterFilter"] = shelterFilter;
            ViewData["AdoptionFilter"] = adoptionFilter;

            var pets = _context.Pet
                .Include(p => p.Breed)
                .Include(p => p.Shelter)
                .AsQueryable();

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                pets = pets.Where(p => p.PetName.Contains(searchString));
            }

            // Filtering
            if (breedFilter.HasValue)
            {
                pets = pets.Where(p => p.BreedID == breedFilter.Value);
            }
            if (shelterFilter.HasValue)
            {
                pets = pets.Where(p => p.ShelterID == shelterFilter.Value);
            }
            if (adoptionFilter.HasValue)
            {
                pets = pets.Where(p => p.Adoption == adoptionFilter.Value);
            }

            // Sorting
            pets = sortOrder switch
            {
                "name_desc" => pets.OrderByDescending(p => p.PetName),
                "Breed" => pets.OrderBy(p => p.Breed.BreedName),
                "breed_desc" => pets.OrderByDescending(p => p.Breed.BreedName),
                "Shelter" => pets.OrderBy(p => p.Shelter.ShelterName),
                "shelter_desc" => pets.OrderByDescending(p => p.Shelter.ShelterName),
                _ => pets.OrderBy(p => p.PetName),
            };

            // Pagination
            int totalItems = await pets.CountAsync();
            var pagedPets = await pets
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            // For dropdowns
            ViewData["Breeds"] = new SelectList(_context.Breed.OrderBy(b => b.BreedName), "BreedID", "BreedName");
            ViewData["Shelters"] = new SelectList(_context.Shelter.OrderBy(s => s.ShelterName), "ShelterID", "ShelterName");

            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewData["CurrentPage"] = page;

            return View(pagedPets);
        }
        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetID,PetName,ShelterID,BreedID,Colour")] Pet pet)
        {
            if (id != pet.PetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.PetID))
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
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            if (pet != null)
            {
                _context.Pet.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.PetID == id);
        }
    }
}
