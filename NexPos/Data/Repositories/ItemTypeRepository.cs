using NexPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPos.Data.Repositories
{
    public class ItemTypeRepository
    {
        public List<ItemType> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.ItemTypes.ToList();
            }
        }

        public void Add(ItemType itemType)
        {
            using (var context = new AppDbContext())
            {
                context.ItemTypes.Add(itemType);
                context.SaveChanges();
            }
        }

        public void Update(ItemType itemType)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.ItemTypes.Find(itemType.Id);
                if (existing != null)
                {
                    existing.Name = itemType.Name;
                    existing.BgColor = itemType.BgColor;
                    existing.BgImage = itemType.BgImage;
                    existing.UseBgImage = itemType.UseBgImage;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var itemType = context.ItemTypes.Find(id);
                if (itemType != null)
                {
                    context.ItemTypes.Remove(itemType);
                    context.SaveChanges();
                }
            }
        }
    }
}
