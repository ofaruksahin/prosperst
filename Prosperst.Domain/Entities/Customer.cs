namespace Prosperst.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public CustomerStatus Status { get; set; }

        public Customer()
        {
            DomainEvents = new List<INotification>();
        }

        public static Customer Create(string name, string surname, DateTime birthDate, string identityNo)
        {
            var customer = new Customer
            {
                Name = name,
                Surname = surname,
                BirthDate = birthDate,
                IdentityNo = identityNo,
                IdentityNoVerified = false,
                Status = CustomerStatus.WAITING_IDENTITY_VERIFICATION
            };

            customer.DomainEvents.Add(new CustomerCreatedDomainEvent(customer));
            return customer;
        }

        public void ChangeStatus(CustomerStatus status)
        {
            Status = status;
        }
    }
}