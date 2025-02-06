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
        private readonly IAddressService _addressService;

        public CustomerService(ICustomerRepository customerRepository, IAddressService addressService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
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

        public async Task ChangeCustomerAddressAsync(ChangeAddressRequest request)
        {
            if (request.CustomerID <= 0)
                throw new ArgumentException("Customer ID must be valid.");
            var customer = await GetCustomerByIdAsync(request.CustomerID);
            Address address;
            try
            {
                address = await _addressService.GetAddressByDetailsAsync(request.Street, request.Number, request.City, request.PostalCode, request.Country);
            }
            catch(NotFoundAddressException) 
            {
                var addressRequest = new CreateAddressRequest(request.Street, request.City, request.PostalCode, request.Country, request.Number);
                address = await _addressService.CreateAddressAsync(addressRequest);
            }
            var changeAddressEvent = customer.ChangeAddress(address.ID);
            await _customerRepository.Apply(changeAddressEvent);
        }
    }
}
