using ME.S04.Core.Contract.Customers;
using ME.S04.Core.DomainModel.Customers.DTO;
using ME.S04.Core.DomainModel.Customers;

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
    }
}
