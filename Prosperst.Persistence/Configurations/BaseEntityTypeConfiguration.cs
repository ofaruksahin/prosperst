namespace Prosperst.Persistence.Configurations
{
    public abstract class BaseEntityTypeConfiguration<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.Ignore(f => f.DomainEvents);
        }
    }
}