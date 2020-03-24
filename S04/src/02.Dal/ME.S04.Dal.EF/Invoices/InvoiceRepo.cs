using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.DomainModel.Invoices;
using ME.S04.Core.DomainModel.Invoices.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ME.S04.Dal.EF.Invoices
{
    class InvoiceRepo : IInvoiceRepo
    {
        private readonly DbContextS04 ctx;

        public InvoiceRepo(DbContextS04 dbContextS04)
        {
            ctx = dbContextS04;
        }

        public InvoicePersist Add(InvoicePersist invoiceInput)
        {
            Invoice invoiceModel = new Invoice
            {
                CustomerId = invoiceInput.CustomerId
                ,
                IssueDate = invoiceInput.IssueDate
            };
            invoiceModel.InvoiceLines.AddRange(invoiceInput
                .InvoiceLines
                .Select(x => new InvoiceLine
                {
                    Invoice = invoiceModel
                    ,
                    Price = x.Price
                    ,
                    Qty = x.Qty
                    ,
                    ProductId = x.ProductId
                }));

            var entry = ctx.Invoices.Add(invoiceModel);
            invoiceInput.InvoiceId = entry.Entity.InvoiceId;
            invoiceInput.InvoiceLines.Clear();
            invoiceInput.InvoiceLines.AddRange(entry
                .Entity
                .InvoiceLines
                .Select(x => new InvoiceLinePersist 
                {
                    InvoiceId = x.InvoiceId
                    ,InvoiceLineId = x.InvoiceLineId
                    ,Price = x.Price
                    ,ProductId = x.ProductId
                    ,Qty = x.Qty
                }));

            return invoiceInput;
        }
    }
}
