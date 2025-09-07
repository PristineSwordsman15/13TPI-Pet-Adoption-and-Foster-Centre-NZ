using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOfficeController : Controller
    {
        private readonly Context _context;

        public AdminOfficeController(Context context)
        {
            _context = context;
            
        }

        // GET: AdminOffice
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1)
        {
            int pageSize = 6;
            var offices = _context.AdminOffice.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                offices = offices.Where(o =>
                    o.FirstName.Contains(searchString) ||
                    o.LevelName.Contains(searchString));
            }

            ViewData["SearchString"] = searchString;

            return View(await PaginatedList<AdminOffice>.CreateAsync(
                offices.AsNoTracking(), pageNumber, pageSize));
        }

        // GET: AdminOffice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var office = await _context.AdminOffice.FirstOrDefaultAsync(m => m.AdminID == id);
            if (office == null) return NotFound();

            return View(office);
        }

        // GET: AdminOffice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminOfficeID,OfficeName,Street,City,Phone")] AdminOffice office)
        {
            if (ModelState.IsValid)
            {
                _context.Add(office);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: AdminOffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var office = await _context.AdminOffice.FindAsync(id);
            if (office == null) return NotFound();

            return View(office);
        }

        // POST: AdminOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminOfficeID,OfficeName,Street,City,Phone")] AdminOffice office)
        {
            if (id != office.AdminID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(office);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminOfficeExists(office.AdminID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: AdminOffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var office = await _context.AdminOffice.FirstOrDefaultAsync(m => m.AdminID == id);
            if (office == null) return NotFound();

            return View(office);
        }

        // POST: AdminOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var office = await _context.AdminOffice.FindAsync(id);
            if (office != null)
            {
                _context.AdminOffice.Remove(office);
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
