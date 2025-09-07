using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class AdminOfficeController : Controller
    {
        private readonly Context _context;
        private const int PageSize = 5;

        public AdminOfficeController(Context context)
        {
            _context = context;
        }

        // GET: AdminOffice
        public async Task<IActionResult> Index(string searchString, int? accessLevelId, string sortOrder, int page = 1)
        {
            ViewData["CurrentSearch"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["AccessLevelFilter"] = accessLevelId;

            var admins = _context.AdminOffice
                .Include(a => a.AccessLevel)
                .Include(a => a.TitleID)
                .AsQueryable();

            // 🔎 Search by name/email
            if (!string.IsNullOrEmpty(searchString))
            {
                admins = admins.Where(a =>
                    a.FirstName.Contains(searchString) ||
                    a.LastName.Contains(searchString) ||
                    a.EmailAddress.Contains(searchString));
            }

            // 🎯 Filter by access level
            if (accessLevelId.HasValue)
            {
                admins = admins.Where(a => a.AccessLevelID == accessLevelId);
            }

            // ↕ Sorting
            admins = sortOrder switch
            {
                "name_desc" => admins.OrderByDescending(a => a.LastName),
                "email" => admins.OrderBy(a => a.EmailAddress),
                "email_desc" => admins.OrderByDescending(a => a.EmailAddress),
                "date" => admins.OrderBy(a => a.DateHired),
                "date_desc" => admins.OrderByDescending(a => a.DateHired),
                _ => admins.OrderBy(a => a.LastName),
            };

            // 📄 Pagination
            var count = await admins.CountAsync();
            var items = await admins.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();

            ViewData["TotalPages"] = (int)Math.Ceiling(count / (double)PageSize);
            ViewData["CurrentPage"] = page;

            return View(items);
        }

        // GET: AdminOffice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var admin = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .Include(a => a.TitleID)
                .FirstOrDefaultAsync(m => m.AdminID == id);

            if (admin == null) return NotFound();

            return View(admin);
        }

        // GET: AdminOffice/Create
        public IActionResult Create()
        {
            ViewData["AccessLevels"] = _context.AccessLevel.ToList();
            ViewData["Titles"] = _context.Title.ToList();
            return View();
        }

        // POST: AdminOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminOffice adminOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminOffice);
        }

        // GET: AdminOffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var admin = await _context.AdminOffice.FindAsync(id);
            if (admin == null) return NotFound();

            ViewData["AccessLevels"] = _context.AccessLevel.ToList();
            ViewData["Titles"] = _context.Title.ToList();
            return View(admin);
        }

        // POST: AdminOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdminOffice adminOffice)
        {
            if (id != adminOffice.AdminID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.AdminOffice.Any(e => e.AdminID == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adminOffice);
        }

        // GET: AdminOffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var admin = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .Include(a => a.TitleID)
                .FirstOrDefaultAsync(m => m.AdminID == id);

            if (admin == null) return NotFound();

            return View(admin);
        }

        // POST: AdminOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.AdminOffice.FindAsync(id);
            if (admin != null)
            {
                _context.AdminOffice.Remove(admin);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
