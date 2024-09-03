namespace Domain.Entities.ProductEntity.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync(string? searchString, string? sortItem, string? sortOrder,
                                                             CancellationToken cancellationToken);

        public Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<Product?> CreateProductAsync(Product product, CancellationToken cancellationToken);

        public Task<Guid> UpdateProductAsync(Guid id, Product product, CancellationToken cancellationToken);

        public Task<Guid> DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}
