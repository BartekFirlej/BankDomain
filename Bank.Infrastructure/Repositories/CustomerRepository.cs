using Bank.Domain.Entities;
using Bank.Domain.Events;
using Bank.Domain.RepositoryInterfaces;
using Bank.Infrastructure.Mappers;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Apply(CustomerChangeAddressEvent customerChangeAddress)
        {
            var customer = await _dbContext.Customers.Where(c => c.ID == customerChangeAddress.CustomerId)
                .FirstOrDefaultAsync();
            customer.AddressID = customerChangeAddress.CustomerId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.Where(c => c.ID == id)
                .Include(c => c.Address)
                .Include(c => c.CustomerStatus)
                .FirstOrDefaultAsync();
            if (customer == null)
                return null;
            return CustomerEntityMapper.ToDomain(customer);
        }

        public async Task<Customer> Save(Customer customer)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var customerEntity = CustomerEntityMapper.ToInfrastructure(customer);
                    _dbContext.Customers.AddAsync(customerEntity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return customer;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
