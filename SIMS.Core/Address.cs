using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace SIMS.Core
{
    public class Address : BaseEntity
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostCode { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Address(string street, string city, string postCode, Guid countryId)
        {
            Street = street;
            City = city;
            PostCode = postCode;
            CountryId = countryId;
        }
    }
}
