using ME.S04.Core.DomainModel.Invoices.DTO;

namespace ME.S04.Core.Contract.Invoices
{
    public interface IInvoiceRepo : IRepo
    {
        InvoicePersist Add(InvoicePersist invoiceInput);
        InvoiceJustKey EagerLoading(int id);
        InvoiceJustKey ExplicitLoading(int id);
    }
}
