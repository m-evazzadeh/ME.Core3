using ME.S04.Core.DomainModel.Customers;
using System;
using System.Collections.Generic;

namespace ME.S04.Core.DomainModel.Invoices
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
