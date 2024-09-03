namespace Domain.Entities.SizeEntity.Interfaces
{
    public interface ISizeService
    {
        public Task<List<Size>> GetAllSizesAsync(CancellationToken cancellationToken);

        public Task<Size?> CreateSizeAsync(Size size, CancellationToken cancellationToken);

        public Task<Guid> UpdateSizeAsync(Guid id, Size size, CancellationToken cancellationToken);

        public Task<Guid> DeleteSizeAsync(Guid id, CancellationToken cancellationToken);
    }
}
