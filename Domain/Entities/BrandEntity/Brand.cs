using Domain.Entities.BaseEntities;
using Domain.Entities.ProductEntity;

namespace Domain.Entities.BrandEntity
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = [];
    }
}
