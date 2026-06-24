using System;
using System.Collections.Generic;
using MediatR;

namespace SIMS.Application.Customers.Queries
{
    public record GetListCustomersQuery : IRequest<Result<List<CustomerResponse>>>;

    public record CustomerResponse(
        Guid Id,
        string Name,
        AddressResponse? Address);

    public record AddressResponse(Guid Id, string Street, string City, string PostalCode, CountryResponse Country);
    public record CountryResponse(Guid Id, string Name);
}
