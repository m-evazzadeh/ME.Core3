using ME.S04.Core.Contract.Customers;
using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.Contract.products;
using System;
using System.Threading.Tasks;

namespace ME.S04.Core.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepo CustomerRepo { get; set; }
        IInvoiceRepo InvoiceRepo { get; set; }
        IProductRepo ProductRepo { get; set; }

        int SaveChage();
        Task<int> SaveChangesAsync();
    }
}
