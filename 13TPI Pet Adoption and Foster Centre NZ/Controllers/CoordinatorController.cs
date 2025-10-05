using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class CoordinatorsController : Controller
{
    private readonly Context _context;

    public CoordinatorsController(Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var coordinators = _context.Coordinator
            .Include(c => c.Franchise)
            .Include(c => c.PetGroup)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            coordinators = coordinators.Where(c => c.FirstName.Contains(searchString) || c.LastName.Contains(searchString));

        coordinators = sortOrder == "name_desc" ? coordinators.OrderByDescending(c => c.FirstName) : coordinators.OrderBy(c => c.FirstName);

        int pageSize = 6;
        return View(await PaginatedList<Coordinator>.CreateAsync(coordinators.AsNoTracking(), pageNumber, pageSize));
    }

    public IActionResult Create()
    {
        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName");
        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Coordinator coordinator)
    {
        if (ModelState.IsValid)
        {
            if (coordinator.ImageFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(coordinator.ImageFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await coordinator.ImageFile.CopyToAsync(stream);
                coordinator.ImageName = fileName;
            }

            _context.Add(coordinator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", coordinator.FranchiseID);
        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", coordinator.PetGroupID);
        return View(coordinator);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var coordinator = await _context.Coordinator.FindAsync(id);
        if (coordinator == null) return NotFound();

        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", coordinator.FranchiseID);
        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", coordinator.PetGroupID);
        return View(coordinator);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Coordinator coordinator)
    {
        if (id != coordinator.CoordinatorID) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                if (coordinator.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(coordinator.ImageFile.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await coordinator.ImageFile.CopyToAsync(stream);
                    coordinator.ImageName = fileName;
                }

                _context.Update(coordinator);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Coordinator.Any(e => e.CoordinatorID == id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseName", coordinator.FranchiseID);
        ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupName", coordinator.PetGroupID);
        return View(coordinator);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var coordinator = await _context.Coordinator
            .Include(c => c.Franchise)
            .Include(c => c.PetGroup)
            .FirstOrDefaultAsync(c => c.CoordinatorID == id);
        if (coordinator == null) return NotFound();
        return View(coordinator);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var coordinator = await _context.Coordinator
            .Include(c => c.Franchise)
            .Include(c => c.PetGroup)
            .FirstOrDefaultAsync(c => c.CoordinatorID == id);
        if (coordinator == null) return NotFound();
        return View(coordinator);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var coordinator = await _context.Coordinator.FindAsync(id);
        _context.Coordinator.Remove(coordinator);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
