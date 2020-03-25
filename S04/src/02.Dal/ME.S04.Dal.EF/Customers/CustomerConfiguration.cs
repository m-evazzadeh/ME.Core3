using ME.S04.Core.DomainModel.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Dal.EF.Customers
{
    /// <summary>
    /// در واقع برای کانفیگ موجودیت های استفاده می شود 
    /// جایگزین EntityTypeConfiguration شده است
    /// <seealso cref="ME.S04.Dal.EF.DbContextS04.OnModelCreating"/>
    /// <para>see:::  modelBuilder.ApplyConfiguration(new CustomerConfiguration());</para>
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            SetHasQueryFilter(builder);
            builder.Property(c => c.FName).HasMaxLength(40);
            builder.Property(c => c.LName).HasMaxLength(40);
            //builder.Ignore(x => x.FName);
            //builder.Property(c => c.LName).HasColumnType("nvarchar(100)");
            //builder.HasKey(x => x.CustomerId)
            ShadowProperty(builder);
        }

        /// <summary>
        /// set shadow propperty 
        /// </summary>
        /// <param name="builder"></param>
        private static void ShadowProperty(EntityTypeBuilder<Customer> builder)
        {
            builder.Property<int>("CreateBy");
            builder.Property<int>("ModifyBy");
            builder.Property<DateTime>("CreateDate");
            builder.Property<DateTime>("ModifyDate");
        }

        /// <summary>
        /// در واقع با این متد کلاس هایی که باید حذف منطقی آنها تنظبم کردد نوشته می شود
        /// در واقع دیگه رکورد هایی که حذف منطقی شده اند هیچ وقت نمایش داده نمی شود
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void SetHasQueryFilter(EntityTypeBuilder<Customer> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
            //در صورت نیاز برای درست کردن همه کلاس ها که نخواهیم آنها را به صورت استاتیک تعریف کنیم
            //var type = typeof(ISoftDelete);
            ////لیست کلاس هایی که باید آنها را برای کوئری بالا آماده کرد
            //var listOfClassInhertanceFromISoftDelete = typeof(ISoftDelete)
            //    .Assembly
            //    .GetTypes()
            //    .Where(x => type.IsAssignableFrom(x));
        }
    }
}
