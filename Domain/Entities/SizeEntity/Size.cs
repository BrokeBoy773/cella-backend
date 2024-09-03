using Domain.Entities.BaseEntities;
using Domain.Entities.ProductEntity;

namespace Domain.Entities.SizeEntity
{
    public class Size : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = [];
    }
}
