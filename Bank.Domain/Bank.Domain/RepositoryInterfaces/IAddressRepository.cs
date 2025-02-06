using Bank.Domain.Entities;

namespace Bank.Domain.RepositoryInterfaces
{
    public interface IAddressRepository
    {
        public Task<Address> GetAddressById(int id);
        public Task<Address> Save(Address address);
        public Task<Address> GetAddressByDetailsAsync(string? street, string number, string city, string postalCode, string country);

    }
}
