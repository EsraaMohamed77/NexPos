using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPos.Models
{
    public class ItemPrice
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int? SubTypeId { get; set; }

        public int? SecondPriceId { get; set; }

        public int? OtherPriceReasonId { get; set; }

        public decimal Price { get; set; }

        // Navigation Properties
        public Item Item { get; set; }
        public SubType SubType { get; set; }
        public OtherPriceReason OtherPriceReason { get; set; }
    }
}
