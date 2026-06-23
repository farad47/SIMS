using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace SIMS.Core
{
    public class Address : TechnicalField
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostCode { get; set; }
        public required Country Country { get; set; }

        public Address(string street, string city, string postCode, Country country)
        {
            Street = street;
            City = city;
            PostCode = postCode;
            Country = country;
        }
    }
}
