using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class Customer : TechnicalField
    {
        public required string Name { get; init; }
        public Address Address { get; private set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
