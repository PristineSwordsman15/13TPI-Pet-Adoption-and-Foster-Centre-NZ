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
    public class PetGroupsController : Controller
    {
        private readonly Context _context;

        public PetGroupsController(Context context)
        {
            _context = context;
        }

        // GET: PetGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetGroup.ToListAsync());
        }

        // GET: PetGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petGroup = await _context.PetGroup
                .FirstOrDefaultAsync(m => m.PetGroupID == id);
            if (petGroup == null)
            {
                return NotFound();
            }

            return View(petGroup);
        }

        // GET: PetGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetGroupID,PetGroupName,PetGroupDescription,PetID,GroupID")] PetGroup petGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petGroup);
        }

        // GET: PetGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petGroup = await _context.PetGroup.FindAsync(id);
            if (petGroup == null)
            {
                return NotFound();
            }
            return View(petGroup);
        }

        // POST: PetGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetGroupID,PetGroupName,PetGroupDescription,PetID,GroupID")] PetGroup petGroup)
        {
            if (id != petGroup.PetGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetGroupExists(petGroup.PetGroupID))
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
            return View(petGroup);
        }

        // GET: PetGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petGroup = await _context.PetGroup
                .FirstOrDefaultAsync(m => m.PetGroupID == id);
            if (petGroup == null)
            {
                return NotFound();
            }

            return View(petGroup);
        }

        // POST: PetGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petGroup = await _context.PetGroup.FindAsync(id);
            if (petGroup != null)
            {
                _context.PetGroup.Remove(petGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetGroupExists(int id)
        {
            return _context.PetGroup.Any(e => e.PetGroupID == id);
        }
    }
}
