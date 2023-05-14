namespace Prosperst.Application.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}