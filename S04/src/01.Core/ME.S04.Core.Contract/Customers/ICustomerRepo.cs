using ME.S04.Core.DomainModel.Customers.DTO;
using ME.S04.Core.DomainModel.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ME.S04.Core.Contract.Customers
{
    public interface ICustomerRepo : IRepo
    {
        CustomerDTO Add(CustomerDTO customerInput);
        CustomerDTO Get(int id);
        Task<IEnumerable<KeyValueType>> LoadCombo();
    
    }
}
