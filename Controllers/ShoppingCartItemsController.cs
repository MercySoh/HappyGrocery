using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HappyGrocery.Data;
using HappyGrocery.Models;

namespace HappyGrocery.Controllers
{
    public class ShoppingCartItemsController : Controller
    {
        private readonly HappyGroceryContext _context;

        public ShoppingCartItemsController(HappyGroceryContext context)
        {
            _context = context;
        }

        // GET: ShoppingCartItems
        public async Task<IActionResult> Index()
        {
              return _context.ShoppingCartItem != null ? 
                          View(await _context.ShoppingCartItem.ToListAsync()) :
                          Problem("Entity set 'HappyGroceryContext.ShoppingCartItem'  is null.");
        }

        // GET: ShoppingCartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCartItem == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.ShoppingCartItem
                .FirstOrDefaultAsync(m => m.ShoppingCartItemId == id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingCartItemId,Amount,ShoppingCartId")] ShoppingCartItem shoppingCartItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingCartItem == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.ShoppingCartItem.FindAsync(id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }
            return View(shoppingCartItem);
        }

        // POST: ShoppingCartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingCartItemId,Amount,ShoppingCartId")] ShoppingCartItem shoppingCartItem)
        {
            if (id != shoppingCartItem.ShoppingCartItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartItemExists(shoppingCartItem.ShoppingCartItemId))
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
            return View(shoppingCartItem);
        }

        // GET: ShoppingCartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCartItem == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.ShoppingCartItem
                .FirstOrDefaultAsync(m => m.ShoppingCartItemId == id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // POST: ShoppingCartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCartItem == null)
            {
                return Problem("Entity set 'HappyGroceryContext.ShoppingCartItem'  is null.");
            }
            var shoppingCartItem = await _context.ShoppingCartItem.FindAsync(id);
            if (shoppingCartItem != null)
            {
                _context.ShoppingCartItem.Remove(shoppingCartItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartItemExists(int id)
        {
          return (_context.ShoppingCartItem?.Any(e => e.ShoppingCartItemId == id)).GetValueOrDefault();
        }
    }
}
