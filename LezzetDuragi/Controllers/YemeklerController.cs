using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LezzetDuragi.Data;
using LezzetDuragi.Models;

namespace LezzetDuragi.Controllers
{
    public class YemeklerController : Controller
    {
        private readonly UygulamaDbContext _context;

        public YemeklerController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Yemekler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yemekler.ToListAsync());
        }
        // Müşterilerin göreceği MENÜ sayfası (Sadece listeleme)
public async Task<IActionResult> Menu()
{
    return View(await _context.Yemekler.ToListAsync());
}

        // GET: Yemekler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemek = await _context.Yemekler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yemek == null)
            {
                return NotFound();
            }

            return View(yemek);
        }

        // GET: Yemekler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yemekler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Fiyat,Aciklama,EklenmeTarihi")] Yemek yemek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yemek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yemek);
        }

        // GET: Yemekler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemek = await _context.Yemekler.FindAsync(id);
            if (yemek == null)
            {
                return NotFound();
            }
            return View(yemek);
        }

        // POST: Yemekler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Fiyat,Aciklama,EklenmeTarihi")] Yemek yemek)
        {
            if (id != yemek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemekExists(yemek.Id))
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
            return View(yemek);
        }

        // GET: Yemekler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemek = await _context.Yemekler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yemek == null)
            {
                return NotFound();
            }

            return View(yemek);
        }

        // POST: Yemekler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yemek = await _context.Yemekler.FindAsync(id);
            if (yemek != null)
            {
                _context.Yemekler.Remove(yemek);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemekExists(int id)
        {
            return _context.Yemekler.Any(e => e.Id == id);
        }
    }
}
