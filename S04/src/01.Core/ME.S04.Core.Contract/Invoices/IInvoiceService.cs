using ME.S04.Core.DomainModel.Invoices.DTO;

namespace ME.S04.Core.Contract.Invoices
{
    public interface IInvoiceService : IService
    {
        InvoicePersist Add(InvoicePersist invoiceInput);
    }
}
