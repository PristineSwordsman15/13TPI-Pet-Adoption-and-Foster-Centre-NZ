using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;

using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class PetsController : Controller
{
    private readonly Context _context;

    public PetsController( Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var pets = _context.Pet
            .Include(p => p.PetGroup)
            .Include(p => p.PetStatus)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            pets = pets.Where(p => p.Name.Contains(searchString));

        pets = sortOrder == "name_desc" ? pets.OrderByDescending(p => p.Name) : pets.OrderBy(p => p.Name);

        int pageSize = 6;
        return View(await PaginatedList<Pet>.CreateAsync(pets.AsNoTracking(), pageNumber, pageSize));
    }

    public IActionResult Create()
    {
        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName");
        ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Pet pet)
    {
        if (ModelState.IsValid)
        {
            if (pet.ImageFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(pet.ImageFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await pet.ImageFile.CopyToAsync(stream);
                pet.ImageName = fileName;
            }

            _context.Add(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", pet.PetGroupID);
        ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
        return View(pet);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var pet = await _context.Pet.FindAsync(id);
        if (pet == null) return NotFound();

        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", pet.PetGroupID);
        ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
        return View(pet);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Pet pet)
    {
        if (id != pet.PetID) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                if (pet.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(pet.ImageFile.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pet.ImageFile.CopyToAsync(stream);
                    pet.ImageName = fileName;
                }

                _context.Update(pet);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pet.Any(e => e.PetID == id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", pet.PetGroupID);
        ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "StatusName", pet.PetStatusID);
        return View(pet);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var pet = await _context.Pet
            .Include(p => p.PetGroup)
            .Include(p => p.PetStatus)
            .FirstOrDefaultAsync(p => p.PetID == id);
        if (pet == null) return NotFound();
        return View(pet);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var pet = await _context.Pet
            .Include(p => p.PetGroup)
            .Include(p => p.PetStatus)
            .FirstOrDefaultAsync(p => p.PetID == id);
        if (pet == null) return NotFound();
        return View(pet);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pet = await _context.Pet.FindAsync(id);
        _context.Pet.Remove(pet);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
