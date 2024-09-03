using Domain.Entities.StatusEntity;
using Domain.Entities.StatusEntity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class StatusRepository(ApplicationDbContext context) : IStatusRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Status>> GetAllStatusesAsync(CancellationToken cancellationToken)
        {
            List<Status> statuses = await _context.Statuses
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return statuses;
        }

        public async Task<Status?> CreateStatusAsync(Status status, CancellationToken cancellationToken)
        {
            await _context.Statuses.AddAsync(status, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return status;
        }

        public async Task<Guid> UpdateStatusAsync(Guid id, Status status, CancellationToken cancellationToken)
        {
            await _context.Statuses
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(s => s.Name, s => status.Name),
                cancellationToken);

            return id;
        }

        public async Task<Guid> DeleteStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            await _context.Statuses
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return id;
        }
    }
}
