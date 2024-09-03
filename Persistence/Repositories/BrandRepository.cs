using Domain.Entities.BrandEntity;
using Domain.Entities.BrandEntity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BrandRepository(ApplicationDbContext context) : IBrandRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
        {
            List<Brand> brands = await _context.Brands
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return brands;
        }

        public async Task<Brand?> CreateBrandAsync(Brand brand, CancellationToken cancellationToken)
        {
            await _context.Brands.AddAsync(brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return brand;
        }

        public async Task<Guid> UpdateBrandAsync(Guid id, Brand brand, CancellationToken cancellationToken)
        {
            await _context.Brands
               .Where(b => b.Id == id)
               .ExecuteUpdateAsync(p => p.SetProperty(b => b.Name, b => brand.Name),
               cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteBrandAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Brands
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
