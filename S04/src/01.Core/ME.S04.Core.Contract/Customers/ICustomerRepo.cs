using ME.S04.Core.DomainModel.Customers.DTO;

namespace ME.S04.Core.Contract.Customers
{
    public interface ICustomerRepo : IRepo
    {
        CustomerDTO Add(CustomerDTO customerInput);
    }
}
