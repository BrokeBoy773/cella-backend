namespace Domain.Entities.BrandEntity.Interfaces
{
    public interface IBrandService
    {
        public Task<List<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken);

        public Task<Brand?> CreateBrandAsync(Brand brand, CancellationToken cancellationToken);

        public Task<Guid> UpdateBrandAsync(Guid id, Brand brand, CancellationToken cancellationToken);

        public Task<Guid> DeleteBrandAsync(Guid id, CancellationToken cancellationToken);
    }
}
