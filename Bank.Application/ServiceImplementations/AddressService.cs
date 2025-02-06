using Bank.Application.Exceptions;
using Bank.Application.Requests;
using Bank.Application.ServiceInterfaces;
using Bank.Domain.Entities;
using Bank.Domain.RepositoryInterfaces;

namespace Bank.Application.ServiceImplementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid address ID.");
            var address = await _addressRepository.GetAddressById(id);
            if (address == null)
                throw new NotFoundAddressException(id);
            return address;
        }

        public async Task<Address> CreateAddressAsync(CreateAddressRequest request)
        {
            var address = new Address(request.Street, request.City, request.PostalCode, request.Country, request.Number);
            var addedAddress = await _addressRepository.Save(address);
            return addedAddress;
        }

        public async Task<Address> GetAddressByDetailsAsync(string? street, string number, string city, string postalCode, string country)
        {
            var address = await _addressRepository.GetAddressByDetailsAsync(street, number, city, postalCode, country);
            if (address == null)
                throw new NotFoundAddressException();
            return address;
        }
    }
}
