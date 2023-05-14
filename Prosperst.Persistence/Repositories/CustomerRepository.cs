namespace Prosperst.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProsperstDbContext context) : base(context)
        {
        }

        public async Task<bool> HasExistsIdentityNumber(string identityNumber)
        {
            return await _context.Customers.AnyAsync(f => f.IdentityNo == identityNumber);
        }
    }
}