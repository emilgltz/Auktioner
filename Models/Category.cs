using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tezt.Models
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<AuctionItem> AuctionItems { get; set; }
    }

   

}
