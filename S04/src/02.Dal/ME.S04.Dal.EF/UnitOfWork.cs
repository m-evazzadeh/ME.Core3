using ME.S04.Core.Contract;
using ME.S04.Core.Contract.Customers;
using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.Contract.products;
using ME.S04.Dal.EF.Customers;
using ME.S04.Dal.EF.Invoices;
using ME.S04.Dal.EF.products;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ME.S04.Dal.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextS04 DbContextS04;

        public ICustomerRepo CustomerRepo { get => new CustomerRepo(DbContextS04); set => throw new NotImplementedException(); }
        public IInvoiceRepo InvoiceRepo { get => new InvoiceRepo(DbContextS04); set => throw new NotImplementedException(); }
        public IProductRepo ProductRepo { get => new ProductRepo(DbContextS04); set => throw new NotImplementedException(); }

        public UnitOfWork(DbContextS04 dbContextS04)
        {
            DbContextS04 = dbContextS04;
        }
        //لازم به ذکر است باید تمامی اورلود ها نوشته شود 
        public int SaveChage()
        {
            return DbContextS04.SaveChanges();
        }
        //لازم به ذکر است باید تمامی اورلود ها نوشته شود 
        public async Task<int> SaveChangesAsync()
        {
            return await DbContextS04.SaveChangesAsync();
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //SaveChage();
            }

            disposed = true;
        }
    }
}
