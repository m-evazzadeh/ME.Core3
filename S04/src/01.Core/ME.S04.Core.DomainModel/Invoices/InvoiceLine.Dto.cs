using ME.S04.Core.DomainModel.products;

namespace ME.S04.Core.DomainModel.Invoices.DTO
{
    public class InvoiceLinePersist
    {
        public int InvoiceLineId { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
    }

    public class InvoiceLineJustKey
    {
        public int InvoiceLineId { get; set; }
        public int ProductId { get; set; }
    }
}
