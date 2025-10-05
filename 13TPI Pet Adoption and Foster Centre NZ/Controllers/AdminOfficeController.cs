using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers;

public class AdminOfficesController : Controller
{
    private readonly Context _context;

    public AdminOfficesController(Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1)
    {
        ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CurrentFilter"] = searchString;

        var admins = _context.AdminOffice
            .Include(a => a.AccessLevel)
            .Include(a => a.TitleName)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
            admins = admins.Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString));

        admins = sortOrder == "name_desc" ? admins.OrderByDescending(a => a.FirstName) : admins.OrderBy(a => a.FirstName);

        int pageSize = 6;
        return View(await PaginatedList<AdminOffice>.CreateAsync(admins.AsNoTracking(), pageNumber, pageSize));
    }

    public IActionResult Create()
    {
        ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName");
        ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "TitleName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminOffice adminOffice)
    {
        if (ModelState.IsValid)
        {
            if (adminOffice.ImageFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(adminOffice.ImageFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await adminOffice.ImageFile.CopyToAsync(stream);
                adminOffice.ImageName = fileName;
            }

            _context.Add(adminOffice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
        ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "TitleName", adminOffice.TitleID);
        return View(adminOffice);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var admin = await _context.AdminOffice.FindAsync(id);
        if (admin == null) return NotFound();

        ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", admin.AccessLevelID);
        ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "TitleName", admin.TitleID);
        return View(admin);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AdminOffice adminOffice)
    {
        if (id != adminOffice.AdminID) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                if (adminOffice.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(adminOffice.ImageFile.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await adminOffice.ImageFile.CopyToAsync(stream);
                    adminOffice.ImageName = fileName;
                }

                _context.Update(adminOffice);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AdminOffice.Any(e => e.AdminID == id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
        ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "TitleName", adminOffice.TitleID);
        return View(adminOffice);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var admin = await _context.AdminOffice
            .Include(a => a.AccessLevel)
            .Include(a => a.TitleName)
            .FirstOrDefaultAsync(a => a.AdminID == id);
        if (admin == null) return NotFound();
        return View(admin);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var admin = await _context.AdminOffice
            .Include(a => a.AccessLevel)
            .Include(a => a.TitleName)
            .FirstOrDefaultAsync(a => a.AdminID == id);
        if (admin == null) return NotFound();
        return View(admin);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var admin = await _context.AdminOffice.FindAsync(id);
        _context.AdminOffice.Remove(admin);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
