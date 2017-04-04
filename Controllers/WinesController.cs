using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineShop.Data;
using WineShop.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;

namespace WineShop.Controllers
{
    public class WinesController : Controller
    {
        private ApplicationDbContext _context;
        private IHostingEnvironment _env;

        public WinesController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Wines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wine.Include(w => w.Winery);
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
                var uploads = Path.Combine(_env.WebRootPath, "images/uploads");

                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    wine.ImagePath = file.FileName;

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

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

            var uploads = Path.Combine(_env.WebRootPath, "images/uploads");

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                wine.ImagePath = file.FileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
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
