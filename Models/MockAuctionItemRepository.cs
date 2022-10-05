using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace tezt.Models
{
    public class MockAuctionItemRepository: IAuctionItemRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<AuctionItem> AllAuctionItems =>
            new List<AuctionItem>
            {
                new AuctionItem {AuctionItemId = "1", AuctionItemName="test", Price=10M},
                new AuctionItem {AuctionItemId = "2", AuctionItemName="test2", Price=10M},
                new AuctionItem {AuctionItemId = "3", AuctionItemName="test3", Price=10M},
                new AuctionItem {AuctionItemId = "4", AuctionItemName="test4", Price=10M}
            };

       

    }
}
