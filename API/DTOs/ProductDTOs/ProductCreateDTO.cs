namespace API.DTOs.ProductDTOs
{
    public record ProductCreateDTO(string Name, Guid CategoryId, Guid BrandId, Guid SizeId, Guid StatusId);
}
