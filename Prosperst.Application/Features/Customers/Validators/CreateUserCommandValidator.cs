namespace Prosperst.Application.Features.Customers.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MaximumLength(50);
            RuleFor(f => f.Surname).NotEmpty().MaximumLength(50);
            RuleFor(f => f.BirthDate).NotEmpty();
            RuleFor(f => f.IdentityNo).NotEmpty().MaximumLength(11);
        }
    }
}