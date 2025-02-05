using Bank.Application.Exceptions;
using Bank.Application.Requests;
using Bank.Application.ServiceInterfaces;
using Bank.Domain.Entities;
using Bank.Domain.RepositoryInterfaces;

namespace Bank.Application.ServiceImplementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid customer ID.");
            var customer =  await _customerRepository.GetCustomerById(id);
            if (customer == null)
                throw new NotFoundCustomerException(id);
            return customer;
        }

        public async Task<Customer> RegisterCustomerAsync(CreateCustomerRequest request)
        {
            var customer = new Customer(request.ContactData, request.PersonalData, request.AddressId, DateTime.UtcNow);
            var addedCustomer = await _customerRepository.Save(customer);
            return addedCustomer;
        }

        public async Task ChangeCustomerAddressAsync(int customerId, int newAddressId)
        {
            if (customerId <= 0 || newAddressId <= 0)
                throw new ArgumentException("Customer ID and Address ID must be valid.");

            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
                throw new InvalidOperationException("Customer not found.");

            customer.ChangeAddress(newAddressId);
            await _customerRepository.Save(customer);
        }
    }
}
