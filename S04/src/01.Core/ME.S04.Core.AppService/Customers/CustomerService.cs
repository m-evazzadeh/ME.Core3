using ME.S04.Core.Contract;
using ME.S04.Core.Contract.Customers;
using ME.S04.Core.DomainModel.Customers.DTO;
using ME.S04.Core.DomainModel.Invoices.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.AppService.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CustomerDTO Add(CustomerDTO customerInput)
        {
            return unitOfWork.CustomerRepo.Add(customerInput);

        }
    }
}
