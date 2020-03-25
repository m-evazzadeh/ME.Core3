using ME.S04.Core.DomainModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.DomainModel.products
{
    public class Product : IBaseEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
