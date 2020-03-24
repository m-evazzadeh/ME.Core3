using AutoMapper;
using ME.S04.Core.DomainModel.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.DomainModel
{
    public class ConfigurationMapper
    {
        public ConfigurationMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<CustomerMapper>()
            );
        }
    }
}
