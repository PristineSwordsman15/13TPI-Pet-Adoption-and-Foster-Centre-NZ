using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

using System.Linq;
using System.Threading.Tasks;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class PetStatusController : Controller
    {
        private readonly Context _context;

        public PetStatusController(Context context)
        {
            _context = context;
        }

        // GET: PetStatus
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1)
        {
            int pageSize = 5;
            var statuses = _context.PetStatus.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                statuses = statuses.Where(s => s.StatusName.Contains(searchString));
            }

            ViewData["SearchString"] = searchString;
            return View(await PaginatedList<PetStatus>.CreateAsync(statuses.AsNoTracking(), pageNumber, pageSize));
        }

        // GET: PetStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var status = await _context.PetStatus.FirstOrDefaultAsync(m => m.PetStatusID == id);
            if (status == null) return NotFound();

            return View(status);
        }

        // GET: PetStatus/Create
        public IActionResult Create() => View();

        // POST: PetStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetStatus petStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petStatus);
        }

        // GET: PetStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var status = await _context.PetStatus.FindAsync(id);
            if (status == null) return NotFound();

            return View(status);
        }

        // POST: PetStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetStatus petStatus)
        {
            if (id != petStatus.PetStatusID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PetStatus.Any(e => e.PetStatusID == petStatus.PetStatusID))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(petStatus);
        }

        // GET: PetStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var status = await _context.PetStatus.FirstOrDefaultAsync(m => m.PetStatusID == id);
            if (status == null) return NotFound();

            return View(status);
        }

        // POST: PetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.PetStatus.FindAsync(id);
            if (status != null)
            {
                _context.PetStatus.Remove(status);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
