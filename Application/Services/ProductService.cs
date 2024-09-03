using Domain.Entities.ProductEntity;
using Domain.Entities.ProductEntity.Interfaces;

namespace Application.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<List<Product>> GetAllProductsAsync(string? searchString, string? sortItem, string? sortOrder,
                                                             CancellationToken cancellationToken)
        {
            return await _repository.GetAllProductsAsync(searchString, sortItem, sortOrder, cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetProductByIdAsync(id, cancellationToken);
        }

        public async Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            Product newProduct = new()
            {
                Id = Guid.NewGuid(),
                Name = product.Name,

                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                SizeId = product.SizeId,
                StatusId = product.StatusId,

                Created = DateTimeOffset.UtcNow,
                UpdatedLast = DateTimeOffset.UtcNow,
            };

            return await _repository.CreateProductAsync(newProduct, cancellationToken);
        }

        public async Task<Guid> UpdateProductAsync(Guid id, Product product, CancellationToken cancellationToken)
        {
            Product newProduct = new()
            {
                Id = id,
                Name = product.Name,

                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                SizeId = product.SizeId,
                StatusId = product.StatusId,

                UpdatedLast = DateTimeOffset.UtcNow,
            };

            return await _repository.UpdateProductAsync(id, newProduct, cancellationToken);
        }

        public async Task<Guid> DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteProductAsync(id, cancellationToken);
        }
    }
}
