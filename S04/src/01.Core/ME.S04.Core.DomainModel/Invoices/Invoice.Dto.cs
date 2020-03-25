using ME.S04.Core.DomainModel.Customers;
using System;
using System.Collections.Generic;

namespace ME.S04.Core.DomainModel.Invoices.DTO
{
    public class InvoicePersist
    {
        public int InvoiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public int CustomerId { get; set; }
        public List<InvoiceLinePersist> InvoiceLines { get; set; }
    }


    public class InvoiceJustKey
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public List<InvoiceLineJustKey> InvoiceLines { get; set; }
    }
}
