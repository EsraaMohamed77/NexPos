using NexPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPos.Data.Repositories
{
    public class ItemRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Item> GetAllItems()
        {
            return _context.Items
                           .Include("ItemType")
                           .Include("SubType")
                           .ToList();
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}
