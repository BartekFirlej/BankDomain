using Bank.Domain.Entities;
using Bank.Infrastructure.Persistence.Entities;

namespace Bank.Infrastructure.Mappers
{
    public static class AddressEntityMapper
    {
        public static Address ToDomain(this AddressEntity entity)
        {
            return new Address(entity.ID, entity.Street, entity.City, entity.Postal_Code, entity.Country, entity.Number);
        }

        public static AddressEntity ToInfrastructure(this Address domain)
        {
            return new AddressEntity
            {
                ID = domain.ID,
                Street = domain.Street,
                City = domain.City,
                Postal_Code = domain.PostalCode,
                Country = domain.Country,
                Number = domain.Number
            };
        }
    }

}
