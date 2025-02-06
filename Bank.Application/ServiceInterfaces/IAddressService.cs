using Bank.Application.Requests;
using Bank.Domain.Entities;

namespace Bank.Application.ServiceInterfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> CreateAddressAsync(CreateAddressRequest request);
        public Task<Address> GetAddressByDetailsAsync(string? street, string number, string city, string postalCode, string country);

    }
}
