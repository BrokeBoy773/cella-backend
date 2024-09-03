using Domain.Entities.BrandEntity;
using Domain.Entities.BrandEntity.Interfaces;

namespace Application.Services
{
    public class BrandService(IBrandRepository repository) : IBrandService
    {
        private readonly IBrandRepository _repository = repository;

        public async Task<List<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllBrandsAsync(cancellationToken);
        }

        public async Task<Brand?> CreateBrandAsync(Brand brand, CancellationToken cancellationToken)
        {
            Brand newBrand = new()
            {
                Id = Guid.NewGuid(),
                Name = brand.Name,
            };

            return await _repository.CreateBrandAsync(newBrand, cancellationToken);
        }

        public async Task<Guid> UpdateBrandAsync(Guid id, Brand brand, CancellationToken cancellationToken)
        {
            Brand newBrand = new()
            {
                Id = id,
                Name = brand.Name,
            };

            return await _repository.UpdateBrandAsync(id, newBrand, cancellationToken);
        }

        public async Task<Guid> DeleteBrandAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteBrandAsync(id, cancellationToken);
        }
    }
}
