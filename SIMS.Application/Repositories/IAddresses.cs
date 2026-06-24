using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SIMS.Core;

namespace SIMS.Application.Repositories
{
    public interface IAddresses
    {
        Task<List<Address>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
