using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.Models;

namespace PetFinder.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Owner/Dog
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dogs.Include(d => d.Breed).Include(d => d.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Owner/Dog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Breed)
                .Include(d => d.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // GET: Owner/Dog/Create
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Name");
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Address");
            return View();
        }

        // POST: Owner/Dog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ChipNumber,Age,Status,BreedId,OwnerId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Name", dog.BreedId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Address", dog.OwnerId);
            return View(dog);
        }

        // GET: Owner/Dog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Name", dog.BreedId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Address", dog.OwnerId);
            return View(dog);
        }

        // POST: Owner/Dog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ChipNumber,Age,Status,BreedId,OwnerId")] Dog dog)
        {
            if (id != dog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogExists(dog.Id))
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
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Name", dog.BreedId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Address", dog.OwnerId);
            return View(dog);
        }

        // GET: Owner/Dog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Breed)
                .Include(d => d.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: Owner/Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dogs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dogs'  is null.");
            }
            var dog = await _context.Dogs.FindAsync(id);
            if (dog != null)
            {
                _context.Dogs.Remove(dog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogExists(int id)
        {
          return (_context.Dogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
