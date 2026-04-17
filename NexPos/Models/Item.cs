using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPos.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Code { get; set; }     // الكود بتاع السكانر

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public decimal Price { get; set; }

        public int ItemTypeId { get; set; }

        public int? SubTypeId { get; set; }

        public int? IngredientId { get; set; }

        public string BgColor { get; set; }

        public string BgImage { get; set; }

        public bool UseBgImage { get; set; } = false;

        public bool HasMultiplePrices { get; set; } = false;

        public int? PrinterId { get; set; }

        public int? KitchenId { get; set; }

        public int? StoreId { get; set; }

        // Navigation Properties
        public ItemType ItemType { get; set; }
        public SubType SubType { get; set; }
        public Ingredient Ingredient { get; set; }
        public Printer Printer { get; set; }
        public Kitchen Kitchen { get; set; }
        public Store Store { get; set; }

        public ICollection<ItemPrice> ItemPrices { get; set; }
    }
}
