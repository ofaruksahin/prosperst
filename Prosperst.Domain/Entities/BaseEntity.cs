namespace Prosperst.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public List<INotification> DomainEvents { get; set; }
    }
}