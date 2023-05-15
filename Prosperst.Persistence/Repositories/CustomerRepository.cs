namespace Prosperst.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProsperstDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Customer> GetCustomerByIdentityNumber(string identityNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(f => f.IdentityNo == identityNumber);
        }

        public async Task<bool> HasExistsIdentityNumber(string identityNumber)
        {
            return await _context.Customers.AnyAsync(f => f.IdentityNo == identityNumber);
        }
    }
}