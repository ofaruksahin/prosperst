namespace Prosperst.Application.Contracts.BaseContracts
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        IUnitOfWork UnitOfWork { get; }
    }
}