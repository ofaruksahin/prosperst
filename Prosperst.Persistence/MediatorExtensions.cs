namespace Prosperst.Persistence
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventasync(this IMediator mediator, DbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(f => f.Entity.DomainEvents != null && f.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(f => f.Entity.DomainEvents)
                .ToList();

            ctx.ChangeTracker.Clear();

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}