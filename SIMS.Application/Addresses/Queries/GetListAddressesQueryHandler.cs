using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SIMS.Application.Repositories;

namespace SIMS.Application.Addresses.Queries
{
    public class GetListAddressesQueryHandler : IRequestHandler<GetListAddressesQuery, Result<List<AddressResponse>>>
    {
        private readonly IAddresses _addresses;

        public GetListAddressesQueryHandler(IAddresses addresses) => _addresses = addresses;

        public async Task<Result<List<AddressResponse>>> Handle(GetListAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addresses.GetAllAsync(cancellationToken);

            var responses = addresses.Select(a => new AddressResponse(
                a.Id,
                a.Street,
                a.City,
                a.PostCode,
                new CountryResponse(a.Country.Id, a.Country.Name)
            )).ToList();

            return Result<List<AddressResponse>>.Success(responses);
        }
    }
}
