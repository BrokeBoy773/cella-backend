using API.DTOs.BrandDTOs;
using API.DTOs.CategoryDTOs;
using API.DTOs.SizeDTOs;
using API.DTOs.StatusDTOs;

namespace API.DTOs.ProductDTOs
{
    public record ProductGetDTO(Guid Id, DateTimeOffset Created, DateTimeOffset UpdatedLast,
                                string Name, CategoryGetDTO Category, BrandGetDTO Brand,
                                SizeGetDTO Size, StatusGetDTO Status);
}
