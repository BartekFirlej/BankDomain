using Bank.Domain.Entities;

namespace Bank.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> Save(Customer customer);
    }
}
