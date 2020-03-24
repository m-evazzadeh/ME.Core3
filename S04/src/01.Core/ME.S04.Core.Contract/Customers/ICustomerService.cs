using ME.S04.Core.DomainModel.Customers.DTO;

namespace ME.S04.Core.Contract.Customers
{
    public interface ICustomerService : IService
    {
        CustomerDTO Add(CustomerDTO customerInput);
    }
}
