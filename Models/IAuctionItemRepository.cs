using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace tezt.Models
{
    public interface IAuctionItemRepository
    {
        IEnumerable<AuctionItem> AllAuctionItems { get; }
        
    }
}
