using API.DTOs.StatusDTOs;
using Domain.Entities.StatusEntity;
using Mapster;

namespace API.Mappings.Configurations
{
    public static class StatusDTOMappingConfiguration
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Status, StatusGetDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Status, StatusCreateDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
