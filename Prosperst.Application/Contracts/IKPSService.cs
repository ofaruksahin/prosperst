namespace Prosperst.Application.Contracts
{
    public interface IKPSService
    {
        Task Verify(Customer customer);
    }
}