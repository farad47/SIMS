using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SIMS.Application.Repositories;

namespace SIMS.Application.Customers.Queries
{
    public class GetListCustomersQueryHandler : IRequestHandler<GetListCustomersQuery, Result<List<CustomerResponse>>>
    {
        private readonly ICustomers _customers;

        public GetListCustomersQueryHandler(ICustomers customers) => _customers = customers;

        public async Task<Result<List<CustomerResponse>>> Handle(GetListCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customers.GetAllAsync(cancellationToken);

            var responses = customers.Select(c => new CustomerResponse(
                c.Id,
                c.Name,
                c.Address is null ? null : new AddressResponse(
                    c.Address.Id,
                    c.Address.Street,
                    c.Address.City,
                    c.Address.PostCode,
                    new CountryResponse(c.Address.Country.Id, c.Address.Country.Name)
                )
            )).ToList();

            return Result<List<CustomerResponse>>.Success(responses);
        }
    }
}
