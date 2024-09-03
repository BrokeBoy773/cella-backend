using Application.Services;
using Domain.Entities.SizeEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class SizeServiceExtensions
    {
        public static void AddSizeService(this IServiceCollection services)
        {
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();
        }
    }
}
