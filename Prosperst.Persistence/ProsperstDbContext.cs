namespace Prosperst.Persistence
{
    public class ProsperstDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<Customer> Customers { get; set; }

        public ProsperstDbContext(DbContextOptions<ProsperstDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ProsperstDbContext(DbContextOptions<ProsperstDbContext> options, IMediator mediator) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProsperstDbContext).Assembly);
        }

        public async Task CommitAsync()
        {
            var result = await this.SaveChangesAsync() > 0;
            if (result)
                await _mediator.DispatchDomainEventasync(this);

            return;
        }
    }
}