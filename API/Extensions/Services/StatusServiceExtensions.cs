using Application.Services;
using Domain.Entities.StatusEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class StatusServiceExtensions
    {
        public static void AddStatusService(this IServiceCollection services)
        {
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
        }
    }
}
