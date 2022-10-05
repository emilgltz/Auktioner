using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tezt.Data;
namespace tezt.Models
{
    public class AuctionItemRepository: IAuctionItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuctionItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<AuctionItem> AllAuctionItems
        {
            get
            {
                return _applicationDbContext.AuctionItems.Include(c => c.Category);
            }
        }

       

    }
}
