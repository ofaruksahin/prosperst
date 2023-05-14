namespace Prosperst.Application.Features.Customers.DomainEventHandlers
{
    public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
    {
        private readonly IKPSService _kpsService;

        public CustomerCreatedDomainEventHandler(IKPSService kpsService)
        {
            _kpsService = kpsService;
        }

        public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
             await _kpsService.Verify(notification.Customer);
        }
    }
}