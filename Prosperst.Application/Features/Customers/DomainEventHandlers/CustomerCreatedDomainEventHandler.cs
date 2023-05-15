namespace Prosperst.Application.Features.Customers.DomainEventHandlers
{
    public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
    {
        private readonly IKPSService _kpsService;
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreatedDomainEventHandler(
            IKPSService kpsService,
            ICustomerRepository customerRepository)
        {
            _kpsService = kpsService;
            _customerRepository = customerRepository;
        }

        public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(notification.Customer.Id);
            if (customer is null) return;

            var response = await _kpsService.Verify(notification.Customer);

            if (response)
                customer.ChangeStatus(CustomerStatus.IDENTITY_VERIFICATED);
            else
                customer.ChangeStatus(CustomerStatus.IDENTITY_NOT_VERIFICATED);

            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.UnitOfWork.CommitAsync();
        }
    }
}