﻿using ME.S04.Core.DomainModel.Addresses;
using ME.S04.Core.DomainModel.Customers;
using ME.S04.Core.DomainModel.General;
using System;
using System.Collections.Generic;

namespace ME.S04.Core.DomainModel.Invoices
{
    public class Invoice: IBaseEntity
    {
        public int InvoiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
        /// <summary>
        /// owned type
        /// <see langword="see::: " cref="ME.S04.Dal.EF.Invoices.Configure.InvoiceConfiguration.OwnedType"/>
        /// </summary>
        public Address ShippingAddress { get; set; }
    }
}
