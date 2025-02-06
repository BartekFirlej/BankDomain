using Bank.Domain.Entities;
using Bank.Domain.RepositoryInterfaces;
using Bank.Infrastructure.Mappers;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> GetAddressByDetailsAsync(string? street, string number, string city, string postalCode, string country)
        {
            var addressEntity = await _dbContext.Addresses
            .FirstOrDefaultAsync(a =>
                a.Street == street &&
                a.Number == number &&
                a.City == city &&
                a.Postal_Code == postalCode &&
                a.Country == country);
            if (addressEntity == null)
                return null;
            return addressEntity.ToDomain();
        }

        public async Task<Address> GetAddressById(int id)
        {
            var addressEntity = await _dbContext.Addresses.FindAsync(id);
            if (addressEntity == null)
                return null;
            return addressEntity.ToDomain();
        }

        public async Task<Address> Save(Address address)
        {
            var addressEntity = address.ToInfrastructure();
            _dbContext.Addresses.AddAsync(addressEntity);
            await _dbContext.SaveChangesAsync();
            return addressEntity.ToDomain();
        }
    }
}
