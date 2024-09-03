using Domain.Entities.ProductEntity;
using Domain.Entities.ProductEntity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Product>> GetAllProductsAsync(string? searchString, string? sortItem, string? sortOrder,
                                                             CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _context.Products
                .AsNoTracking()
                .Where(p => string.IsNullOrWhiteSpace(searchString) || p.Name.ToLower().Contains(searchString.ToLower()))
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Status);

            Expression<Func<Product, object>> selectorKey;

            switch (sortItem)
            {
                case "name":
                    selectorKey = product => product.Name;
                    break;

                case "created":
                    selectorKey = product => product.Created;
                    break;

                case "updated":
                    selectorKey = product => product.UpdatedLast;
                    break;

                default:
                    goto case "name";
            }

            switch (sortOrder)
            {
                case "desc":
                    query = query.OrderByDescending(selectorKey);
                    break;

                case "asc":
                    query = query.OrderBy(selectorKey);
                    break;

                default:
                    goto case "asc";
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return product;
        }

        public async Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        public async Task<Guid> UpdateProductAsync(Guid id, Product product, CancellationToken cancellationToken)
        {
            await _context.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(prop => prop.SetProperty(p => p.Name, p => product.Name)
                                                .SetProperty(p => p.CategoryId, p => product.CategoryId)
                                                .SetProperty(p => p.BrandId, p => product.BrandId)
                                                .SetProperty(p => p.SizeId, p => product.SizeId)
                                                .SetProperty(p => p.StatusId, p => product.StatusId)
                                                .SetProperty(p => p.UpdatedLast, p => product.UpdatedLast),
                                                cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
