using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexPos.Models;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
namespace NexPos.Data
{
   

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=POSConnectionString")
        {
        }

        // DbSets
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<SubType> SubTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public DbSet<OtherPriceReason> OtherPriceReasons { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ItemType Configuration
            modelBuilder.Entity<ItemType>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ItemType>()
                .Property(i => i.BgColor)
                .HasMaxLength(50);

            // SubType Configuration
            modelBuilder.Entity<SubType>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Item Configuration
            modelBuilder.Entity<Item>()
                .Property(i => i.Code)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200);

            // ItemPrice Configuration
            modelBuilder.Entity<ItemPrice>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            // Relationships
            modelBuilder.Entity<Item>()
                .HasRequired(i => i.ItemType)
                .WithMany()
                .HasForeignKey(i => i.ItemTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasOptional(i => i.SubType)
                .WithMany()
                .HasForeignKey(i => i.SubTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasOptional(i => i.Printer)
                .WithMany()
                .HasForeignKey(i => i.PrinterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemPrice>()
                .HasRequired(p => p.Item)
                .WithMany(i => i.ItemPrices)
                .HasForeignKey(p => p.ItemId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
