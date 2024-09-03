using Domain.Entities.SizeEntity;
using Domain.Entities.SizeEntity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class SizeRepository(ApplicationDbContext context) : ISizeRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Size>> GetAllSizesAsync(CancellationToken cancellationToken)
        {
            List<Size> sizes = await _context.Sizes
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return sizes;
        }

        public async Task<Size?> CreateSizeAsync(Size size, CancellationToken cancellationToken)
        {
            await _context.Sizes.AddAsync(size, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return size;
        }

        public async Task<Guid> UpdateSizeAsync(Guid id, Size size, CancellationToken cancellationToken)
        {
            await _context.Sizes
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(s => s.Name, s => size.Name),
                cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteSizeAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Sizes
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
