using AutoMapper;
using ME.S04.Core.DomainModel.Customers.DTO;

namespace ME.S04.Core.DomainModel.Customers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
        }
    }
}
