using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using Microsoft.AspNetCore.Authorization;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly Context _context;

        public PetController(Context context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            var context = _context.Pet.Include(p => p.PetGroup).Include(p => p.PetStatus);
            return View(await context.ToListAsync());
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.PetGroup)
                .Include(p => p.PetStatus)
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID");
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetID,Name,DateOfBirth,PetGroupID,PetStatusID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetID,Name,DateOfBirth,PetGroupID,PetStatusID")] Pet pet)
        {
            if (id != pet.PetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.PetID))
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
            ViewData["PetGroupID"] = new SelectList(_context.PetGroup, "PetGroupID", "PetGroupID", pet.PetGroupID);
            ViewData["PetStatusID"] = new SelectList(_context.PetStatus, "PetStatusID", "Name", pet.PetStatusID);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .Include(p => p.PetGroup)
                .Include(p => p.PetStatus)
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            if (pet != null)
            {
                _context.Pet.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.PetID == id);
        }
    }
}
