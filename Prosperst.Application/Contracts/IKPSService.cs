namespace Prosperst.Application.Contracts
{
    public interface IKPSService
    {
        Task<bool> Verify(Customer customer);
    }
}