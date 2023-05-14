namespace Prosperst.Application.Features.Customers.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse>
    {
        private ICustomerRepository _customerRepository;

        public CreateUserCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hasExistsIdentityNumber = await _customerRepository.HasExistsIdentityNumber(request.IdentityNo);
            if (hasExistsIdentityNumber)
                return BaseResponse.Fail(new NoContent(), "Bu kimlik numarası daha önce kullanılmış");

            var customer = Customer.Create(request.Name, request.Surname, request.BirthDate, request.IdentityNo);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.UnitOfWork.CommitAsync();

            var commandResponse = new CreateUserCommandResponse(customer.Id);
            return BaseResponse.Success(commandResponse);
        }
    }
}