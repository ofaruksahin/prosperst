namespace Prosperst.Domain.Events
{
    public class CustomerCreatedDomainEvent : INotification
    {
        public Customer Customer { get; private set; }

        public CustomerCreatedDomainEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}