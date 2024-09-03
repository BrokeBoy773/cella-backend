using API.DTOs.CategoryDTOs;
using Domain.Entities.CategoryEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public class CategoryDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Category, CategoryGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Category, CategoryCreateDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
