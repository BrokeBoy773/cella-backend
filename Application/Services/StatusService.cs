using Domain.Entities.StatusEntity;
using Domain.Entities.StatusEntity.Interfaces;

namespace Application.Services
{
    public class StatusService(IStatusRepository repository) : IStatusService
    {
        private readonly IStatusRepository _repository = repository;

        public async Task<List<Status>> GetAllStatusesAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllStatusesAsync(cancellationToken);
        }

        public async Task<Status?> CreateStatusAsync(Status status, CancellationToken cancellationToken)
        {
            Status newStatus = new()
            {
                Id = Guid.NewGuid(),
                Name = status.Name,
            };

            return await _repository.CreateStatusAsync(newStatus, cancellationToken);
        }

        public async Task<Guid> UpdateStatusAsync(Guid id, Status status, CancellationToken cancellationToken)
        {
            Status newStatus = new()
            {
                Id = id,
                Name = status.Name,
            };

            return await _repository.UpdateStatusAsync(id, newStatus, cancellationToken);
        }

        public async Task<Guid> DeleteStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteStatusAsync(id, cancellationToken);
        }
    }
}
