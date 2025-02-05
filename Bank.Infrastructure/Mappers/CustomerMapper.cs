using Bank.Domain.Entities;
using Bank.Domain.ValueObjects;
using Bank.Infrastructure.Persistence.Entities;

namespace Bank.Infrastructure.Mappers
{
    public static class CustomerEntityMapper
    {
        public static Customer ToDomain(CustomerEntity entity)
        {
            PersonalData personalData = entity.SecondName == null
                ? new PersonalData(entity.FirstName, entity.LastName, entity.BirthDate)
                : new PersonalData(entity.FirstName, entity.SecondName, entity.LastName, entity.BirthDate);

            ContactData contactData = new ContactData(entity.PhoneNumber, entity.EmailAddress);

            RegistrationStatus registrationStatus = (RegistrationStatus)entity.CustomerStatusID;

            return new Customer(
                entity.ID,
                contactData,
                personalData,
                entity.AddressID,
                entity.RegistrationDateTime,
                registrationStatus
            );
        }

        public static CustomerEntity ToInfrastructure(Customer customer)
        {
            return new CustomerEntity
            {
                ID = customer.ID,
                FirstName = customer.PersonalData.FirstName,
                SecondName = customer.PersonalData.SecondName,
                LastName = customer.PersonalData.LastName,  
                PhoneNumber = customer.ContactData.PhoneNumber,
                EmailAddress = customer.ContactData.EmailAddress,
                AddressID = customer.AddressId,
                CustomerStatusID = (int)customer.RegistrationStatus,
                RegistrationDateTime = customer.RegistrationDateTime,
                BirthDate = customer.PersonalData.BirthDate
            };
        }
    }
}
