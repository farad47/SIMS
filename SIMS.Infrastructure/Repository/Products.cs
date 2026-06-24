using Microsoft.EntityFrameworkCore;
using SIMS.Infrastructure.Database;
using SIMS.Core;

namespace SIMS.Infrastructure.Repository
{
    public class Products
    {
        private readonly AppDbContext _db;

        public Products(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            await _db.Products.AddAsync(product, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            _db.Products.Update(product);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _db.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (entity is null) return;

            _db.Products.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
