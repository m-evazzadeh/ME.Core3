using ME.S04.Core.Contract;
using ME.S04.Core.Contract.Invoices;
using ME.S04.Core.DomainModel.Invoices.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.AppService.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public InvoicePersist Add(InvoicePersist invoiceInput)
        {
            return unitOfWork.InvoiceRepo.Add(invoiceInput);
        }
    }
}
