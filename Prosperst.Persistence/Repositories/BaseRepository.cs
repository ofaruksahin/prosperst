using Prosperst.Application.Contracts.BaseContracts;

namespace Prosperst.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        protected ProsperstDbContext _context;

        public BaseRepository(ProsperstDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }
    }
}