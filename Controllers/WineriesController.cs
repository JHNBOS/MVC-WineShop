using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WineShop.Models;
using WineShop.Data;

namespace WineShop.Controllers
{
    public class WineriesController : Controller
    {
        private ApplicationDbContext _context;

        public WineriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wineries
        public ActionResult Index()
        {
            List<Winery> wineriesList = _context.Winery.ToList();

            return View(wineriesList);
        }

        // GET: Wineries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Winery winery = _context.Winery.Single(w => w.ID == id);

            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }

        // GET: Wineries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wineries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Winery winery)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Winery.Add(winery);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(winery);
            }
        }

        // GET: Wineries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Winery winery = _context.Winery.Single(w => w.ID == id);

            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }

        // POST: Wineries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Winery winery)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Winery.Update(winery);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(winery);
            }
        }

        // GET: Wineries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Winery winery = _context.Winery.Single(w => w.ID == id);

            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }

        // POST: Wineries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Winery winery)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Winery.Remove(winery);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(winery);
            }
        }


    }
}