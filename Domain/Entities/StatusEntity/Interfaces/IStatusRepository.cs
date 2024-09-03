namespace Domain.Entities.StatusEntity.Interfaces
{
    public interface IStatusRepository
    {
        public Task<List<Status>> GetAllStatusesAsync(CancellationToken cancellationToken);

        public Task<Status?> CreateStatusAsync(Status status, CancellationToken cancellationToken);

        public Task<Guid> UpdateStatusAsync(Guid id, Status status, CancellationToken cancellationToken);

        public Task<Guid> DeleteStatusAsync(Guid id, CancellationToken cancellationToken);
    }
}
