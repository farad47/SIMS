using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class Customer : BaseEntity
    {
        public required string Name { get; init; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Customer(string name, Guid addressId)
        {
            Name = name;
            AddressId = addressId;
        }
    }
}
