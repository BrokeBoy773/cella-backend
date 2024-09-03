using Domain.Entities.BaseEntities;
using Domain.Entities.BrandEntity;
using Domain.Entities.CategoryEntity;
using Domain.Entities.SizeEntity;
using Domain.Entities.StatusEntity;

namespace Domain.Entities.ProductEntity
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public Guid SizeId { get; set; }
        public Size Size { get; set; } = null!;

        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
    }
}
