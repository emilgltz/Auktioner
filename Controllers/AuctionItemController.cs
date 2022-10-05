using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using tezt.Data;
using tezt.Models;

namespace tezt.Controllers
{
    [Authorize]
    public class AuctionItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> EditItem()
        {
            var applicationDbContext = _context.AuctionItems.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        

        

        // GET: AuctionItem
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AuctionItems.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AuctionItem/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItems
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AuctionItemId == id);
            if (auctionItem == null)
            {
                return NotFound();
            }

            return View(auctionItem);
        }

        // GET: AuctionItem/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: AuctionItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuctionItemId,AuctionItemName,AuctionItemDescription,Decade,Price,CategoryId")] AuctionItem auctionItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auctionItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateItemComplete");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auctionItem.CategoryId);
            return View(auctionItem);
        }

        public IActionResult CreateItemComplete()
        {
            ViewBag.CreateItemCompleteMessage = "The auction item have been added successfully!";
            return View();
        }
        public IActionResult EditItemComplete()
        {
            ViewBag.EditItemCompleteMessage = "Your edit has been saved!";
            return View();
        }
        public IActionResult DeleteItemComplete()
        {
            ViewBag.DeleteItemCompleteMessage = "The auction item is now deleted!";
            return View();
        }
        // GET: AuctionItem/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItems.FindAsync(id);
            if (auctionItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auctionItem.CategoryId);
            return View(auctionItem);
        }

        // POST: AuctionItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AuctionItemId,AuctionItemName,AuctionItemDescription,Decade,Price,CategoryId")] AuctionItem auctionItem)
        {
            if (id != auctionItem.AuctionItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctionItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionItemExists(auctionItem.AuctionItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditItemComplete");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auctionItem.CategoryId);
            return View(auctionItem);
        }

        // GET: AuctionItem/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auctionItem = await _context.AuctionItems
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AuctionItemId == id);
            if (auctionItem == null)
            {
                return NotFound();
            }

            return View(auctionItem);
        }

        // POST: AuctionItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var auctionItem = await _context.AuctionItems.FindAsync(id);
            _context.AuctionItems.Remove(auctionItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("DeleteItemComplete");
        }

        private bool AuctionItemExists(string id)
        {
            return _context.AuctionItems.Any(e => e.AuctionItemId == id);
        }
    }
}
