using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tezt.Data;

namespace tezt.Controllers
{
    public class InventarieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventarieController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Inventarie()
        {
            var applicationDbContext = _context.AuctionItems.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> InventarieDetails(string id)
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



    }
}
