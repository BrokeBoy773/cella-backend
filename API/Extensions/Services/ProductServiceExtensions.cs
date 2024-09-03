using Application.Services;
using Domain.Entities.ProductEntity.Interfaces;
using Persistence.Repositories;

namespace API.Extensions.Services
{
    public static class ProductServiceExtensions
    {
        public static void AddProductService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
