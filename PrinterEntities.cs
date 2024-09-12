using PrinterDemo.DB;
using System;
using System.Data.Entity; // Ensure you have the correct namespace for Entity Framework

namespace YourNamespaceName.Models
{
    public partial class PrinterEntities : DbContext
    {
        internal object Users;

        public DbSet<SalesBill> SalesBills { get; set; }
        public DbSet<SalesBillItem> SalesBillItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
