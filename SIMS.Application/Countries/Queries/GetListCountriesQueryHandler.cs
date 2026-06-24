using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SIMS.Application.Repositories;

namespace SIMS.Application.Countries.Queries
{
    public class GetListCountriesQueryHandler : IRequestHandler<GetListCountriesQuery, Result<List<CountryResponse>>>
    {
        private readonly ICountries _countries;

        public GetListCountriesQueryHandler(ICountries countries) => _countries = countries;

        public async Task<Result<List<CountryResponse>>> Handle(GetListCountriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _countries.GetAllAsync(cancellationToken);

            var responses = entities.Select(c => new CountryResponse(c.Id, c.Name, c.Continent)).ToList();

            return Result<List<CountryResponse>>.Success(responses);
        }
    }
}
