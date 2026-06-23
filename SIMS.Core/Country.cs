using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class Country : TechnicalField
    {
        public string Name { get; init; }
        public ContinentType Continent { get; init; }
        public string CountryCode { get; private set; }

        public Country(string name, ContinentType continent, string countryCode)
        {
            Name = name;
            Continent = continent;
            CountryCode = countryCode;
        }
    }
}
