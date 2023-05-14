namespace Prosperst.Persistence.Configurations
{
    public class CustomerEntityTypeConfiguration : BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.BirthDate)
                .IsRequired();

            builder.Property(f => f.IdentityNo)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(f => f.IdentityNoVerified)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired();

            builder.ToTable("customers");
        }
    }
}