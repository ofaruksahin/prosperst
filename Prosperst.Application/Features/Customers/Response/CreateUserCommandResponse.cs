namespace Prosperst.Application.Features.Customers.Response
{
    public class CreateUserCommandResponse
    {
        public int Id { get; private set; }

        public CreateUserCommandResponse(int id)
        {
            Id = id;
        }
    }
}