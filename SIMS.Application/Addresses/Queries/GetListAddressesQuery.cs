using System;
using System.Collections.Generic;
using MediatR;

namespace SIMS.Application.Addresses.Queries
{
    public record GetListAddressesQuery : IRequest<Result<List<AddressResponse>>>;

    public record AddressResponse(
        Guid Id,
        string Street,
        string City,
        string PostalCode,
        CountryResponse Country);

    public record CountryResponse(Guid Id, string Name);
}
