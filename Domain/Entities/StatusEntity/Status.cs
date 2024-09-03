using Domain.Entities.BaseEntities;
using Domain.Entities.ProductEntity;

namespace Domain.Entities.StatusEntity
{
    public class Status : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = [];
    }
}
