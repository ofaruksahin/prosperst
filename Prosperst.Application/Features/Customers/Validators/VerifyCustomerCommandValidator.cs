namespace Prosperst.Application.Features.Customers.Validators
{
    public class VerifyCustomerCommandValidator : AbstractValidator<VerifyCustomerCommand>
    {
        public VerifyCustomerCommandValidator()
        {
            RuleFor(f => f.IdentityNumber).NotEmpty().MaximumLength(11);
        }
    }
}
