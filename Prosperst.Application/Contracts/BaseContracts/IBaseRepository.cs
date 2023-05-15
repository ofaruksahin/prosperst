namespace Prosperst.Application.Contracts.BaseContracts
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        IUnitOfWork UnitOfWork { get; }
    }
}