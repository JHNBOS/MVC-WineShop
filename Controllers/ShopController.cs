using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WineShop.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WineShop.Models;

namespace WineShop.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wine.Include(w => w.Winery);
            ViewBag.Wines = _context.Wine.ToList();

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.SingleOrDefaultAsync(m => m.ID == id);
            if (wine == null)
            {
                return NotFound();
            }

            ViewBag.Winery = _context.Winery.Single(w => w.ID == wine.WineryID);

            return View(wine);
        }

        // GET: Wines/Create
        public IActionResult Create()
        {
            ViewData["WineryID"] = new SelectList(_context.Winery, "ID", "Name");
            return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AlcoholPercentage,Description,ImagePath,Name,Price,WineType,WineryID,Year")] Wine wine, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Wine.Add(wine);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewData["WineryID"] = new SelectList(_context.Winery, "ID", "Name", wine.WineryID);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error message: " + ex);
            }

            return View(wine);
        }

        // GET: Wines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.SingleOrDefaultAsync(m => m.ID == id);
            if (wine == null)
            {
                return NotFound();
            }

            ViewBag.Winery = _context.Winery.Single(w => w.ID == wine.WineryID);
            ViewData["WineryID"] = new SelectList(_context.Winery, "ID", "Name", wine.WineryID);
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AlcoholPercentage,Description,ImagePath,Name,Price,WineType,WineryID,Year")] Wine wine, IFormFile file)
        {
            if (id != wine.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineExists(wine.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["WineryID"] = new SelectList(_context.Winery, "ID", "Name", wine.WineryID);
            return View(wine);
        }

        // GET: Wines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.SingleOrDefaultAsync(m => m.ID == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wine = await _context.Wine.SingleOrDefaultAsync(m => m.ID == id);
            _context.Wine.Remove(wine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WineExists(int id)
        {
            return _context.Wine.Any(e => e.ID == id);
        }
    }
}