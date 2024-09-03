using Domain.Entities.SizeEntity;
using Domain.Entities.SizeEntity.Interfaces;

namespace Application.Services
{
    public class SizeService(ISizeRepository repository) : ISizeService
    {
        private readonly ISizeRepository _repository = repository;

        public async Task<List<Size>> GetAllSizesAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllSizesAsync(cancellationToken);
        }

        public async Task<Size?> CreateSizeAsync(Size size, CancellationToken cancellationToken)
        {
            Size newSize = new()
            {
                Id = Guid.NewGuid(),
                Name = size.Name,
            };
            
            return await _repository.CreateSizeAsync(newSize, cancellationToken);
        }

        public async Task<Guid> UpdateSizeAsync(Guid id, Size size, CancellationToken cancellationToken)
        {
            Size newSize = new()
            {
                Id = id,
                Name = size.Name,
            };

            return await _repository.UpdateSizeAsync(id, newSize, cancellationToken);
        }

        public async Task<Guid> DeleteSizeAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteSizeAsync(id, cancellationToken);
        }
    }
}
