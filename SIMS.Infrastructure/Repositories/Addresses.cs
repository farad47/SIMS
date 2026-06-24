using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIMS.Application.Repositories;
using SIMS.Core;
using SIMS.Infrastructure.Database;

namespace SIMS.Infrastructure.Repositories
{
    public class Addresses : IAddresses
    {
        private readonly AppDbContext _db;
        public Addresses(AppDbContext db) => _db = db;

        public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Addresses.AsNoTracking()
                .Include(a => a.Country)
                .ToListAsync(cancellationToken);
        }
    }
}
