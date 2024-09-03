using API.Mappings.Configurations;

namespace API.Mappings
{
    public static class DTOMappingConfiguration
    {
        public static void RegisterDtoMapping()
        {
            ProductDTOMappingConfiguration.RegisterMapping();

            CategoryDTOMappingConfiguration.RegisterMapping();
            BrandDTOMappingConfiguration.RegisterMapping();
            SizeDTOMappingConfiguration.RegisterMapping();
            StatusDTOMappingConfiguration.RegisterMapping();
        }
    }
}
