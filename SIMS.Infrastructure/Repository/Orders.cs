using Microsoft.EntityFrameworkCore;
using SIMS.Core;
using SIMS.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SIMS.Infrastructure.Repository
{
    public class Orders
    {
        private readonly AppDbContext _db;

        public Orders(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _db.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Address)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            await _db.Orders.AddAsync(order, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            _db.Orders.Update(order);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
            if (entity is null) return;

            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
