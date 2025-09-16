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
    public class PetStatusController : Controller
    {
        private readonly Context _context;

        public PetStatusController(Context context)
        {
            _context = context;
        }

        // GET: PetStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetStatus.ToListAsync());
        }

        // GET: PetStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petStatus = await _context.PetStatus
                .FirstOrDefaultAsync(m => m.PetStatusID == id);
            if (petStatus == null)
            {
                return NotFound();
            }

            return View(petStatus);
        }

        // GET: PetStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetStatusID,Name")] PetStatus petStatus)
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
            if (id == null)
            {
                return NotFound();
            }

            var petStatus = await _context.PetStatus.FindAsync(id);
            if (petStatus == null)
            {
                return NotFound();
            }
            return View(petStatus);
        }

        // POST: PetStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetStatusID,Name")] PetStatus petStatus)
        {
            if (id != petStatus.PetStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetStatusExists(petStatus.PetStatusID))
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
            return View(petStatus);
        }

        // GET: PetStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petStatus = await _context.PetStatus
                .FirstOrDefaultAsync(m => m.PetStatusID == id);
            if (petStatus == null)
            {
                return NotFound();
            }

            return View(petStatus);
        }

        // POST: PetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petStatus = await _context.PetStatus.FindAsync(id);
            if (petStatus != null)
            {
                _context.PetStatus.Remove(petStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetStatusExists(int id)
        {
            return _context.PetStatus.Any(e => e.PetStatusID == id);
        }
    }
}
