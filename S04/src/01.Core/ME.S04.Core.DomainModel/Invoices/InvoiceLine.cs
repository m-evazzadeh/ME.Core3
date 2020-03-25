using ME.S04.Core.DomainModel.General;
using ME.S04.Core.DomainModel.products;

namespace ME.S04.Core.DomainModel.Invoices
{
    public class InvoiceLine : IBaseEntity
    {
        public int InvoiceLineId { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}
