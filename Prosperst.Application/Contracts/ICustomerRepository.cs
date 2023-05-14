using Prosperst.Application.Contracts.BaseContracts;

namespace Prosperst.Application.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> HasExistsIdentityNumber(string identityNumber);
    }
}