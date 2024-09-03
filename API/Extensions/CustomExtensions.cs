using API.Extensions.Databases;
using API.Extensions.Mappings;
using API.Extensions.Services;

namespace API.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            MappingExtensions.AddMapping(services);

            DbContextExtensions.AddDbContext(services, configuration);

            ProductServiceExtensions.AddProductService(services);
            CategoryServiceExtensions.AddCategoryService(services);
            BrandServiceExtensions.AddBrandService(services);
            SizeServiceExtensions.AddSizeService(services);
            StatusServiceExtensions.AddStatusService(services);
        }
    }
}
