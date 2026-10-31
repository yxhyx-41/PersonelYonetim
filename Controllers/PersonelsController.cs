using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetim.Data;
using PersonelYonetim.Models;

namespace PersonelYonetim.Controllers
{
    public class PersonelsController : Controller
    {
        private readonly PersonelDbContext _context;

        public PersonelsController(PersonelDbContext context)
        {
            _context = context;
        }

        // GET: Personels
        public async Task<IActionResult> Index()
        {
            var personeller = await _context.Personeller
                .Include(p => p.Departman)
                .ToListAsync();

            return View(personeller);
        }

        // GET: Personels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .FirstOrDefaultAsync(p => p.PersonelID == id);

            if (personel == null)
                return NotFound();

            return View(personel);
        }

        // GET: Personels/Create
        public IActionResult Create()
        {
            ViewBag.Departmanlar = _context.Departmanlar.ToList();
            return View();
        }

        // POST: Personels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Personeller.Add(personel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departmanlar = _context.Departmanlar.ToList();
            return View(personel);
        }

        // GET: Personels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var personel = await _context.Personeller.FindAsync(id);

            if (personel == null)
                return NotFound();

            ViewBag.Departmanlar = _context.Departmanlar.ToList();

            return View(personel);
        }

        // POST: Personels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Personel personel)
        {
            if (id != personel.PersonelID)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(personel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departmanlar = _context.Departmanlar.ToList();
            return View(personel);
        }

        // GET: Personels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .FirstOrDefaultAsync(p => p.PersonelID == id);

            if (personel == null)
                return NotFound();

            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);

            if (personel != null)
            {
                _context.Personeller.Remove(personel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}