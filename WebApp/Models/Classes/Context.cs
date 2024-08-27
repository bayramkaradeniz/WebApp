using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp.Models.Classes
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TechnicalCategory> TechnicalCategories { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports { get; set; }


    }
}
