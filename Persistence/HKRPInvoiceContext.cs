using EntityContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class HKRPInvoiceContext: DbContext
    {
        public HKRPInvoiceContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceItemMapping> InvoiceItemMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceItemMapping>()
                .HasKey(iim => new { iim.InvoiceNo, iim.ItemCode });

            modelBuilder.Entity<InvoiceItemMapping>()
                .HasOne(iim => iim.Invoice)
                .WithMany(i => i.InvoiceItemMappings)
                .HasForeignKey(iim => iim.InvoiceNo);

            modelBuilder.Entity<InvoiceItemMapping>()
                .HasOne(iim => iim.Item)
                .WithMany(item => item.InvoiceItemMappings)
                .HasForeignKey(iim => iim.ItemCode);

            modelBuilder.Entity<Invoice>()
            .HasMany(i => i.InvoiceItemMappings)
            .WithOne(iim => iim.Invoice)
            .HasForeignKey(iim => iim.InvoiceNo)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for InvoiceItemMappings

            modelBuilder.Entity<Item>()
                .HasMany(i => i.InvoiceItemMappings)
                .WithOne(iim => iim.Item)
                .HasForeignKey(iim => iim.ItemCode)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete for Item


            base.OnModelCreating(modelBuilder);
        }

    }
}
