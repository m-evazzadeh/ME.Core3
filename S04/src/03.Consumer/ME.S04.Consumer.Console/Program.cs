using ME.S04.Core.AppService.Customers;
using ME.S04.Core.AppService.Invoices;
using ME.S04.Core.AppService.products;
using ME.S04.Core.Contract;
using ME.S04.Core.Contract.Customers;
using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.Contract.products;
using ME.S04.Core.DomainModel.Customers.DTO;
using ME.S04.Core.DomainModel.General;
using ME.S04.Core.DomainModel.Invoices.DTO;
using ME.S04.Core.DomainModel.products.DTO;
using ME.S04.Dal.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ME.S04.Consumer.cls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi!");

            DbContextOptionsBuilder<DbContextS04> optionsBuilder = new DbContextOptionsBuilder<DbContextS04>();
            optionsBuilder.UseSqlServer("Server=.; initial Catalog=S04; integrated security=true;");
            DbContextS04 ctx = new DbContextS04(optionsBuilder.Options);

            //CreateDataBaseV2(ctx);
            using (IUnitOfWork uow = new UnitOfWork(ctx))
            {
                //AddCustomer(uow);
                //AddProduct(uow);
                //AddInvoice(uow);
                //var invoiceJustKey = InvoiceEagerLoading(uow);
                //var invoiceJustKey = InvoiceExplicitLoading(uow);
                LoadForComboWithQuryType(uow);
            }




        }

        /// <summary>
        /// load for combo box sample 
        /// </summary>
        /// <param name="uow"></param>
        private static void LoadForComboWithQuryType(IUnitOfWork uow)
        {
            var customerCombo = new CustomerService(uow).LoadCombo().Result;
        }

        private static InvoiceJustKey InvoiceExplicitLoading(IUnitOfWork uow)
        {
            return new InvoiceService(uow).ExplicitLoading(1);
        }
        private static InvoiceJustKey InvoiceEagerLoading(IUnitOfWork uow)
        {
            return new InvoiceService(uow).EagerLoading(1);
        }

        private static void AddInvoice(IUnitOfWork uow)
        {
            var customer = new CustomerService(uow).Get(1);
            var product1 = new ProductService(uow).Get(1);
            var product2 = new ProductService(uow).Get(2);
            var product3 = new ProductService(uow).Get(3);
            IInvoiceService invoiceService = new InvoiceService(uow);
            invoiceService.Add(new InvoicePersist
            {
                CustomerId = customer.CustomerId
                ,
                IssueDate = DateTime.Now
                ,
                InvoiceLines = new List<InvoiceLinePersist>
                    {
                        new InvoiceLinePersist{ Price = 100 , Qty = 2 , ProductId = product1.ProductId}
                        ,new InvoiceLinePersist{ Price = 200 , Qty = 2 , ProductId = product2.ProductId}
                        ,new InvoiceLinePersist{ Price = 200 , Qty = 2 , ProductId = product3.ProductId}
                    }
            });
            uow.SaveChage();
        }

        private static void AddProduct(IUnitOfWork uow)
        {
            IProductService productService = new ProductService(uow);
            productService.Add(new ProductDTO { Name = "خودکار" });
            uow.SaveChage();
        }

        private static void AddCustomer(IUnitOfWork uow)
        {
            ICustomerService customerService = new CustomerService(uow);
            customerService.Add(new CustomerDTO { FName = "mojtaba", LName = "Evazzadeh" });
            uow.SaveChage();
        }

        /// <summary>
        /// انواع روش های ایجاد دیتا بیس در سیستم
        /// </summary>
        /// <param name="ctx"></param>
        private static void CreateDataBaseV2(DbContextS04 ctx)
        {
            //روش اول ایجاد دیتابیس به صورت دستی میباشد

            //روش دوم بدون استفاده از مایگریشن و به صورت فورس کردن به روش زیر می باشد
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();


            //روش سوم استفاده از مایگریشن و آپدیت می باشد 
            //البته لازم به ذکر است در این روش اول 
            //dar dbcontext donbal 1 conextractor mibashad bedon vorodi agar peyda nashavad bad be donbal 
            //classi migardad ke az IDesignTimeDbContextFactory ers bari kardeh bashad
        }
    }
}
