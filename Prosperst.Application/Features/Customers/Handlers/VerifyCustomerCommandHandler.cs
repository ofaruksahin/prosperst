namespace Prosperst.Application.Features.Customers.Handlers
{
    public class VerifyCustomerCommandHandler : IRequestHandler<VerifyCustomerCommand, BaseResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public VerifyCustomerCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;

        }

        public async Task<BaseResponse> Handle(VerifyCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdentityNumber(request.IdentityNumber);
            if (customer is null)
                return BaseResponse.Fail(new NoContent(), "Müşteri bulunamadı");
            var domainEvent = new CustomerCreatedDomainEvent(customer);
            await _mediator.Publish(domainEvent);

            return BaseResponse.Success(new NoContent());
        }
    }
}
