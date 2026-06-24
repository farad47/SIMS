using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIMS.Application.Repositories;
using SIMS.Core;
using SIMS.Infrastructure.Database;

namespace SIMS.Infrastructure.Repositories
{
    public class Countries : ICountries
    {
        private readonly AppDbContext _db;
        public Countries(AppDbContext db) => _db = db;

        public async Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Countries.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
