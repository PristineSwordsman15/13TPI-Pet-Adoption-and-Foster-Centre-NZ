using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly Context _context;

        public PetController(Context context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DobSortParm"] = sortOrder == "dob" ? "dob_desc" : "dob";

            if (searchString != null) pageNumber = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;

            var pets = _context.Pet.Include(p => p.PetGroup).Include(p => p.PetStatus).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
                pets = pets.Where(p => p.Name.Contains(searchString));

            pets = sortOrder switch
            {
                "name_desc" => pets.OrderByDescending(p => p.Name),
                "dob" => pets.OrderBy(p => p.DateOfBirth),
                "dob_desc" => pets.OrderByDescending(p => p.DateOfBirth),
                _ => pets.OrderBy(p => p.Name),
            };

            int pageSize = 5;
            return View(await PaginatedList<Pet>.CreateAsync(pets.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.PetGroup)
                .Include(p => p.PetStatus)
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
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID");
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetID,Name,DateOfBirth,PetGroupID,PetStatusID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
            return View(pet);
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
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetID,Name,DateOfBirth,PetGroupID,PetStatusID")] Pet pet)
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
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
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
                .Include(p => p.PetGroup)
                .Include(p => p.PetStatus)
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
