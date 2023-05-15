namespace Prosperst.Application.Features.Customers.Response
{
    public class CreateCustomerCommandResponse
    {
        public int Id { get; private set; }

        public CreateCustomerCommandResponse(int id)
        {
            Id = id;
        }
    }
}