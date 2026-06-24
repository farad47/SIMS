using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SIMS.Core;

namespace SIMS.Application.Repositories
{
    public interface ICustomers
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
