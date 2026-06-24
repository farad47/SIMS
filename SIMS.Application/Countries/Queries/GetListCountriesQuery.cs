using System;
using System.Collections.Generic;
using MediatR;
using SIMS.Core.Enums;

namespace SIMS.Application.Countries.Queries
{
    public record GetListCountriesQuery : IRequest<Result<List<CountryResponse>>>;

    public record CountryResponse(Guid Id, string Name, ContinentType Continent);
}
