using ME.S04.Core.DomainModel.Addresses;
using ME.S04.Core.DomainModel.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Dal.EF.Invoices
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .HasMany(x => x.InvoiceLines)
                .WithOne(x => x.Invoice)
                .IsRequired()
                ///در زمان حذف فاکتور چه اتفاقی برای کلاس هایی بیافتد که کلید خارجی دارند از این فاکتور
                .OnDelete(DeleteBehavior.Cascade);//چهار وضعیت دارد

            OwnedType(builder);

        }
        /// <summary>
        /// owned type
        /// <para>1: OwnsOne</para> 
        /// <para>2: OwnsMany</para> 
        /// </summary>
        /// <param name="builder"></param>
        private static void OwnedType(EntityTypeBuilder<Invoice> builder)
        {
            builder
                 .OwnsOne(typeof(Address), "ShippingAddress");
        }
    }

    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder
                .HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLines)
                .IsRequired();

        }
    }
}
