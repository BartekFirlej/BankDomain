using Bank.Domain.Entities;
using Bank.Domain.Events;

namespace Bank.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> Save(Customer customer);
        public Task Apply(CustomerChangeAddressEvent customerChangeAddress);
    }
}
