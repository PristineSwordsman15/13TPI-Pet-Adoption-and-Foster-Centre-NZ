using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;


namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class AdminOfficeController : Controller
    {
        private readonly Context _context;
        private const int PageSize = 5;

        public AdminOfficeController(Context context)
        {
            _context = context;
        }

        // GET: AdminOffice
        // GET: AdminOffice
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // Sorting params
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            // Search handling
            if (searchString != null)
            {
                page = 1; // reset to first page when searching
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            // Query
            var query = _context.AdminOffice
                .Include(a => a.AccessLevel)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(a =>
                    a.FirstName.Contains(searchString) ||
                    a.LastName.Contains(searchString) ||
                    a.EmailAddress.Contains(searchString) ||
                    a.ContactNo.Contains(searchString) ||
                    a.AccessLevel.LevelName.Contains(searchString) ||
                    a.TitleName.Contains(searchString));
            }

            // Sorting
            query = sortOrder switch
            {
                "name_desc" => query.OrderByDescending(a => a.LastName),
                "Date" => query.OrderBy(a => a.DateHired),
                "date_desc" => query.OrderByDescending(a => a.DateHired),
                _ => query.OrderBy(a => a.LastName),
            };

            // Pagination
            

            // ...

            int pageNumber = page ?? 1;

            // materialize the query first
            var list = await query.ToListAsync();

            // then paginate
            var pagedList = list.ToPagedList(pageNumber, PageSize);

            return View(pagedList);

        }


        // GET: AdminOffice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var adminOffice = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .Include(a => a.TitleName)
                .FirstOrDefaultAsync(m => m.AdminID == id);

            if (adminOffice == null) return NotFound();
            return View(adminOffice);
        }

        // GET: AdminOffice/Create
        public IActionResult Create()
        {
            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName");
            ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "TitleName");
            return View();
        }

        // POST: AdminOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevelID,TitleID,ImageName")] AdminOffice adminOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            ViewData["TitleID"] = new SelectList(_context.TitleName, "TitleID", "TitleName", adminOffice.TitleID);
            return View(adminOffice);
        }

        // GET: AdminOffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice == null) return NotFound();

            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            ViewData["TitleID"] = new SelectList(_context.TitleName, "TitleID", "TitleName", adminOffice.TitleID);
            return View(adminOffice);
        }

        // POST: AdminOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminID,UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevelID,TitleID,ImageName")] AdminOffice adminOffice)
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
                    if (!AdminOfficeExists(adminOffice.AdminID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AccessLevelID"] = new SelectList(_context.AccessLevel, "AccessLevelID", "LevelName", adminOffice.AccessLevelID);
            ViewData["TitleID"] = new SelectList(_context.TitleName, "TitleID", "TitleName", adminOffice.TitleID);
            return View(adminOffice);
        }

        // GET: AdminOffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var adminOffice = await _context.AdminOffice
                .Include(a => a.AccessLevel)
                .Include(a => a.TitleName)
                .FirstOrDefaultAsync(m => m.AdminID == id);

            if (adminOffice == null) return NotFound();
            return View(adminOffice);
        }

        // POST: AdminOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice != null)
            {
                _context.AdminOffice.Remove(adminOffice);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AdminOfficeExists(int id)
        {
            return _context.AdminOffice.Any(e => e.AdminID == id);
        }
    }
}
