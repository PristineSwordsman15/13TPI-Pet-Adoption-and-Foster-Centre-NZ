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
    public class FranchiseController : Controller

    {
        private readonly Context _context;

        public FranchiseController(Context context)
        {
            _context = context;
        }

        // GET: Franchises
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["FranchiseNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["OperatingHoursSortParm"] = sortOrder == "OperatingHours" ? "OperatingHours;_desc" : "OperatingHours";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            var franchise = from s in _context.Franchise
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                franchise = franchise.Where(s => s.OperatingHours.Contains(searchString)
                                       || s.FranchiseName.Contains(searchString));

            }

            if (searchString == null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            switch (sortOrder)
            {   
                case "name_desc":
                    franchise = franchise.OrderByDescending(s => s.FranchiseName);
                    break;
                case "AccessLevel":
                    franchise = franchise.OrderBy(s => s.FranchiseName);
                    break;
                case "date_desc":
                    franchise = franchise.OrderByDescending(s => s.OperatingHours);
                    break;
                default:
                    franchise = franchise.OrderBy(s => s.OperatingHours);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Franchise>.CreateAsync(franchise.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .FirstOrDefaultAsync(m => m.FranchiseID == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseID,FranchiseName,ContactNo,LocationID,EmailAddress,OperatingHours,OwnerID")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return View(franchise);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FranchiseID,FranchiseName,ContactNo,LocationID,EmailAddress,OperatingHours,OwnerID")] Franchise franchise)
        {
            if (id != franchise.FranchiseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.FranchiseID))
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
            return View(franchise);
        }

        // GET: Franchises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .FirstOrDefaultAsync(m => m.FranchiseID == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchise.Remove(franchise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(e => e.FranchiseID == id);
        }
    }
}
