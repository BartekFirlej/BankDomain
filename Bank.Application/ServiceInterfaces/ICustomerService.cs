using Bank.Domain.Entities;
using Bank.Application.Requests;

namespace Bank.Application.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> RegisterCustomerAsync(CreateCustomerRequest request);
        Task ChangeCustomerAddressAsync(ChangeAddressRequest request);
    }
}