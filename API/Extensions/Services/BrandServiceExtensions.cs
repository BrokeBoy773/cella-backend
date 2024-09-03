using Application.Services;
using Domain.Entities.BrandEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class BrandServiceExtensions
    {
        public static void AddBrandService(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();
        }
    }
}
