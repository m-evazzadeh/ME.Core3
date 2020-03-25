using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.DomainModel.General;
using ME.S04.Core.DomainModel.Invoices;
using ME.S04.Core.DomainModel.Invoices.DTO;
using Microsoft.EntityFrameworkCore;
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
                ,InvoiceLines = new List<InvoiceLine>()
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

        public InvoiceJustKey EagerLoading(int id)
        {
            return ctx
                .Invoices
                .Include(x => x.Customer)
                .Include(x => x.InvoiceLines)
                .ThenInclude(x => x.Product)
                .Select(x => new InvoiceJustKey
                {
                    InvoiceId = x.InvoiceId
                    ,CustomerId  = x.CustomerId
                    ,InvoiceLines = x.InvoiceLines.Select(l => new InvoiceLineJustKey 
                    { 
                        InvoiceLineId = l.InvoiceLineId
                        ,ProductId = l.ProductId
                    }).ToList()
                })
                .FirstOrDefault(x => x.InvoiceId == id);
        }

        public InvoiceJustKey ExplicitLoading(int id)
        {
            var invoice = ctx.Invoices.First(x => x.InvoiceId == id);
            //load all
            ctx.Entry(invoice).Collection(c => c.InvoiceLines).Load();
            //load with condition
            //ctx.Entry(invoice).Collection(c => c.InvoiceLines).Query().Where(x => x.Price > 100);
            ctx.Entry(invoice).Reference(c => c.Customer).Load();
            
            return new InvoiceJustKey 
            {
                InvoiceId = invoice.InvoiceId 
                ,CustomerId = invoice.CustomerId
                ,InvoiceLines =  invoice.InvoiceLines.Select(l => new InvoiceLineJustKey 
                {
                    InvoiceLineId = l.InvoiceLineId
                    ,ProductId = l.ProductId
                }).ToList()
            };
        }
    }
}
