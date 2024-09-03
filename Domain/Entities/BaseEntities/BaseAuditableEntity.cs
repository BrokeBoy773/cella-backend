namespace Domain.Entities.BaseEntities
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset UpdatedLast { get; set; }
    }
}
