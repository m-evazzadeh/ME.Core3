﻿using ME.S04.Core.Contract;
using ME.S04.Core.DomainModel.Customers;
using ME.S04.Core.DomainModel.Invoices;
using ME.S04.Core.DomainModel.products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ME.S04.Dal.EF
{
    /// <summary>
    /// agar bekhahim ba migration 1 DB besazim bayad in interface ra impliment bekonim
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContextS04>
    {
        public DbContextS04 CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DbContextS04> optionsBuilder = new DbContextOptionsBuilder<DbContextS04>();
            //البته می شود این کانکشن را از فایل کانفیگ گرفت
            optionsBuilder.UseSqlServer("Server=.; initial Catalog=S04; integrated security=true;");
            return new DbContextS04(optionsBuilder.Options);
        }
    }

    public class DbContextS04 : DbContext, IDbContextS04
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        //چون نمی خواهیم به صورت مستقیم در دسترس باشد و میخواهیم از طریف پدرش در دسترس باشد یعنی خود فاکتور
        //public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbContextS04(DbContextOptions<DbContextS04> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}