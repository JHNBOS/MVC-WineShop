using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineShop.Data;
using WineShop.Models;

namespace WineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cart.Include(w => w.Wine).ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.ID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        /*
        public IActionResult Create()
        {
            return View();
        }
        */
        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind("ID,AddedOn,ClientID,StatusID,WineID")] Cart cart
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? clientID, int? productID)
        {
            Cart cart = new Cart();

            if (clientID != null && productID != null)
            {
                cart.ClientID = (int)clientID;
                cart.WineID = (int)productID;
                cart.Amount = 1;
                cart.AddedOn = DateTime.Now.Date;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.ID == id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AddedOn,ClientID,StatusID,WineID,Amount")] Cart cart)
        {
            if (id != cart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.ID))
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
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task Delete(int? id)
        {
            /*
            if (id == null)
            {
                //return NotFound();
            }

            //var cart = _context.Cart.SingleOrDefault(m => m.ID == id);
            if (cart == null)
            {
                //return NotFound();
            }
            */
            await DeleteConfirmed((int)id);
            //return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.ID == id);
        }
    }
}
