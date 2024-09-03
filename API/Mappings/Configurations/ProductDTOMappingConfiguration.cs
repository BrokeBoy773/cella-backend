using API.DTOs.ProductDTOs;
using Domain.Entities.ProductEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public static class ProductDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Product, ProductGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Created, src => src.Created)
                .Map(dest => dest.UpdatedLast, src => src.UpdatedLast)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Category, src => src.Category)
                .Map(dest => dest.Brand, src => src.Brand)
                .Map(dest => dest.Size, src => src.Size)
                .Map(dest => dest.Status, src => src.Status);

            TypeAdapterConfig<Product, ProductCreateDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.BrandId, src => src.BrandId)
                .Map(dest => dest.SizeId, src => src.SizeId)
                .Map(dest => dest.StatusId, src => src.StatusId);
        }
    }
}
