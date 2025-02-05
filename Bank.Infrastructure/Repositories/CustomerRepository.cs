using Bank.Domain.Entities;
using Bank.Domain.RepositoryInterfaces;
using Bank.Infrastructure.Mappers;
using Bank.Infrastructure.Persistence;
using Bank.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext _dbContext)
        {
            _dbContext = _dbContext;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.Where(c => c.ID == id)
                .Include(c => c.Address)
                .Include(c => c.CustomerStatus)
                .FirstOrDefaultAsync();
            return CustomerEntityMapper.ToDomain(customer);
        }

        public Task<Customer> Save(Customer customer)
        {
            using(var transaction = _dbContext.Database.BeginTransactionAsync())
            {

            }
        }
    }
}
