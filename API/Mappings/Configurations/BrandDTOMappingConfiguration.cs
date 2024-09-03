using API.DTOs.BrandDTOs;
using Domain.Entities.BrandEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public class BrandDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Brand, BrandGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Brand, BrandCreateDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
