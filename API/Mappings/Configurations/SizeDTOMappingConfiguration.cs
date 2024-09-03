using API.DTOs.SizeDTOs;
using Domain.Entities.SizeEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public static class SizeDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Size, SizeGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Size, SizeCreateDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
