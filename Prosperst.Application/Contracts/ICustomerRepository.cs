using Prosperst.Application.Contracts.BaseContracts;

namespace Prosperst.Application.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByIdentityNumber(string identityNumber);
        Task<bool> HasExistsIdentityNumber(string identityNumber);
    }
}