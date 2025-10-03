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
    // All controller actions and members must be within these braces
    public class AdminOfficeController : Controller
    {
        private readonly Context _context;

        // Define a constant for pagination
        private const int PageSize = 10; // You can choose your desired page size

        public AdminOfficeController(Context context)
        {
            _context = context;
        }

        // GET: AdminOffices
        // Index with search, sort, and paging
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            // Sort order toggles
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "lname" ? "lname_desc" : "lname";
            ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var admins = from a in _context.AdminOffice
                         select a;

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                admins = admins.Where(a =>
                    a.FirstName.Contains(searchString) ||
                    a.LastName.Contains(searchString) ||
                    a.EmailAddress.Contains(searchString) ||
                    a.ContactNo.Contains(searchString));
            }

            // Sorting
            admins = sortOrder switch
            {
                "fname_desc" => admins.OrderByDescending(a => a.FirstName),
                "lname" => admins.OrderBy(a => a.LastName),
                "lname_desc" => admins.OrderByDescending(a => a.LastName),
                "email" => admins.OrderBy(a => a.EmailAddress),
                "email_desc" => admins.OrderByDescending(a => a.EmailAddress),
                "date" => admins.OrderBy(a => a.DateHired),
                "date_desc" => admins.OrderByDescending(a => a.DateHired),
                _ => admins.OrderBy(a => a.FirstName),
            };

            int currentPage = pageNumber ?? 1;
            // NOTE: PaginatedList<T> is assumed to be defined elsewhere in your project
            return View(await PaginatedList<AdminOffice>.CreateAsync(admins.AsNoTracking(), currentPage, PageSize));
        }

        // GET: AdminOffices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminOffice == null)
            {
                return NotFound();
            }

            return View(adminOffice);
        }

        // GET: AdminOffices/Create
        public IActionResult Create()
        {
            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName");
            return View();
        }

        // POST: AdminOffices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminID,UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevelID,LevelName,TitleName,TitleID,ImageName")] AdminOffice adminOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            return View(adminOffice);
        }

        // GET: AdminOffices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice == null)
            {
                return NotFound();
            }
            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            return View(adminOffice);
        }

        // POST: AdminOffices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminID,UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevelID,LevelName,TitleName,TitleID,ImageName")] AdminOffice adminOffice)
        {
            if (id != adminOffice.AdminID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminOfficeExists(adminOffice.AdminID))
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
            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            return View(adminOffice);
        }

        // GET: AdminOffices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminOffice == null)
            {
                return NotFound();
            }

            return View(adminOffice);
        }

        // POST: AdminOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice != null)
            {
                _context.AdminOffice.Remove(adminOffice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminOfficeExists(int id)
        {
            return _context.AdminOffice.Any(e => e.AdminID == id);
        }
    }
}