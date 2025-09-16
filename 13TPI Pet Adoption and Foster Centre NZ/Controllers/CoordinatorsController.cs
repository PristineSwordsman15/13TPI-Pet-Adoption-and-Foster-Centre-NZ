using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class CoordinatorsController : Controller
    {
        private readonly Context _context;

        public CoordinatorsController(Context context)
        {
            _context = context;
        }

        // GET: Coordinators
        public async Task<IActionResult> Index()
        {
            var context = _context.Coordinator.Include(c => c.Franchise).Include(c => c.PetGroup);
            return View(await context.ToListAsync());
        }

        // GET: Coordinators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinator
                .Include(c => c.Franchise)
                .Include(c => c.PetGroup)
                .FirstOrDefaultAsync(m => m.CoordinatorID == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        // GET: Coordinators/Create
        public IActionResult Create()
        {
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID");
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID");
            return View();
        }

        // POST: Coordinators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoordinatorID,FirstName,LastName,FranchiseID,PetGroupID")] Coordinator coordinator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coordinator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", coordinator.FranchiseID);
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", coordinator.PetGroupID);
            return View(coordinator);
        }

        // GET: Coordinators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinator.FindAsync(id);
            if (coordinator == null)
            {
                return NotFound();
            }
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", coordinator.FranchiseID);
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", coordinator.PetGroupID);
            return View(coordinator);
        }

        // POST: Coordinators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoordinatorID,FirstName,LastName,FranchiseID,PetGroupID")] Coordinator coordinator)
        {
            if (id != coordinator.CoordinatorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coordinator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordinatorExists(coordinator.CoordinatorID))
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
            ViewData["FranchiseID"] = new SelectList(_context.Franchise, "FranchiseID", "FranchiseID", coordinator.FranchiseID);
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", coordinator.PetGroupID);
            return View(coordinator);
        }

        // GET: Coordinators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await _context.Coordinator
                .Include(c => c.Franchise)
                .Include(c => c.PetGroup)
                .FirstOrDefaultAsync(m => m.CoordinatorID == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        // POST: Coordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordinator = await _context.Coordinator.FindAsync(id);
            if (coordinator != null)
            {
                _context.Coordinator.Remove(coordinator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordinatorExists(int id)
        {
            return _context.Coordinator.Any(e => e.CoordinatorID == id);
        }
    }
}
