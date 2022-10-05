using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace tezt.Models
{
    public class AuctionItem
    {


        [Required]
        [StringLength(9)]
        [Display(Name = "Auction item ID")]
        [DataType(DataType.Text)]
        [RegularExpression("^[A-Z]{3}[0-9]{6}$",
            ErrorMessage = "The Auction item Id is not entered in a correct format, follow the instructions and try again")]
        public string AuctionItemId { get; set; }
        [Required(ErrorMessage = "Please enter a name for the item")]
        [StringLength(30)]
        [Display(Name = "Item name")]
        public string AuctionItemName { get; set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "Item description")]
        public string AuctionItemDescription { get; set;}
        [Required(ErrorMessage = "Please enter in which decade the item was created")]
        [StringLength(30)]
        [Display(Name = "Decade of the item")]
        public string Decade { get; set; }
        [Required(ErrorMessage = "Please enter a selling price for the item")]
        [Display(Name = "Item price")]
        public decimal Price { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }



    }
}
