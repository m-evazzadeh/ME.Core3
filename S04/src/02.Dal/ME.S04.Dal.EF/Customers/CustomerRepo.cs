using ME.S04.Core.Contract.Customers;
using ME.S04.Core.DomainModel.Customers.DTO;
using ME.S04.Core.DomainModel.Customers;
using ME.S04.Core.DomainModel.General;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ME.S04.Dal.EF.Customers
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly DbContextS04 ctx;

        public CustomerRepo(DbContextS04 dbContextS04)
        {
            ctx = dbContextS04;
        }

        public CustomerDTO Add(CustomerDTO customerInput)
        {
            var result = ctx.Customers.Add(new Customer 
            {
                FName = customerInput.FName,
                LName = customerInput.LName
            });
            customerInput.CustomerId = result.Entity.CustomerId;
            return customerInput;
        }

        /// <summary>
        /// shadow property
        ///<see langword="see::: " cref="ME.S04.Dal.EF.Customers.CustomerConfiguration"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CreateBy(int id)
        {
            var customer = ctx.Customers.FirstOrDefault(x => x.CustomerId == id);
            var retval = ctx.Entry(customer).Property("CreateBy").CurrentValue.ToString();
            
            //condition on shadow Property
            //ctx.Customers.Where(x => EF.Property<DateTime>(x, "LastUpdated"));
            
            //for set 
            //ctx.Entry(customer).Property("CreateBy").CurrentValue = object;
            
            return  int.Parse(retval);
        }

        public CustomerDTO Get(int id)
        {
            var customer = ctx.Customers.Find(id);
            
            if (customer == null)
                return null;
            
            return new CustomerDTO { 
            CustomerId = customer.CustomerId
            ,FName = customer.FName
            ,LName = customer.LName
            };
        }

        public async Task<IEnumerable<KeyValueType>> LoadCombo()
        {
            var query = QueryHelper.KeyValueTypeQueryGenerator<Customer>(ctx,nameof(Customer.CustomerId), new List<string> { nameof(Customer.FName) , nameof(Customer.LName) });

            return await ctx
                .KeyValueType
                //قابل توجه می باشد برای اجرای این نوع کوئری دیگر لازم نیست 
                //در دیبیکانتکس به عنوان دیبیکوئری معرفی شود
                //چون برای ویو ها باید از این کانفیگ استفاده کرد
                .FromSqlRaw<KeyValueType>(query)
                .ToListAsync();
        }
    }
}
