using Bank.Domain.ValueObjects;

namespace Bank.Application.Requests
{
    public class CreateCustomerRequest
    {
        public ContactData ContactData { get; }
        public PersonalData PersonalData { get; }
        public int AddressId { get; }

        public CreateCustomerRequest(string email, string phoneNumber, string firstName,string? secondName, string lastName, DateOnly birthDate, int addressId)
        {
            ContactData = new ContactData(phoneNumber, email);
            if (secondName != null)
                PersonalData = new PersonalData(firstName, secondName, lastName, birthDate);
            PersonalData = new PersonalData(firstName, lastName, birthDate);
            AddressId = addressId;
        }
    }

}
