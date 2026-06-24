using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIMS.Application.Repositories;
using SIMS.Core;
using SIMS.Infrastructure.Database;

namespace SIMS.Infrastructure.Repositories
{
    public class Customers : ICustomers
    {
        private readonly AppDbContext _db;
        public Customers(AppDbContext db) => _db = db;

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Customers.AsNoTracking()
                .Include(c => c.Address)
                    .ThenInclude(a => a.Country)
                .ToListAsync(cancellationToken);
        }
    }
}
