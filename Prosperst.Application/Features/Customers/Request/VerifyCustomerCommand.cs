namespace Prosperst.Application.Features.Customers.Request
{
    public class VerifyCustomerCommand : IRequest<BaseResponse>
    {
        public string IdentityNumber { get; set; }
    }
}
