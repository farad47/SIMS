using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SIMS.Core;

namespace SIMS.Application.Repositories
{
    public interface ICountries
    {
        Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
