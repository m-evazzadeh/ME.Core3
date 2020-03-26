using ME.S04.Core.DomainModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.DomainModel.Addresses
{
    public class Address : IBaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Pelak { get; set; }
        public int Floor { get; set; }
    }
}
