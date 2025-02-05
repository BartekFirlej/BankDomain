using Bank.Domain.ValueObjects;

namespace Bank.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public ContactData ContactData { get; private set; }
        public PersonalData PersonalData { get; private set; }
        public AddressData AddressData { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public RegistrationStatus RegistrationStatus { get; private set; }

        public Customer(Guid id, ContactData contactData, PersonalData personalData, AddressData addressData, DateTime registrationDate)
        {
            Id = id;
            ContactData = contactData;
            PersonalData = personalData;
            AddressData = addressData;
            RegistrationDate = registrationDate;
            RegistrationStatus = RegistrationStatus.REQUEST_SENT;
        }

        public void MarkPersonalDataVerified()
        {
            if (RegistrationStatus != RegistrationStatus.REQUEST_SENT)
                throw new InvalidOperationException("Personal data can only be verified after the registration request is sent.");

            RegistrationStatus = RegistrationStatus.PERSONAL_DATA_VERIFIED;
        }

        public void MarkContactDataVerified()
        {
            if (RegistrationStatus != RegistrationStatus.PERSONAL_DATA_VERIFIED)
                throw new InvalidOperationException("Contact data can only be verified after personal data verification.");

            RegistrationStatus = RegistrationStatus.CONTACT_DATA_VERIFIED;
        }

        public void MarkAddressVerified()
        {
            if (RegistrationStatus != RegistrationStatus.CONTACT_DATA_VERIFIED)
                throw new InvalidOperationException("Address can only be verified after the registration request is sent.");

            RegistrationStatus = RegistrationStatus.ADDRESS_VERIFIED;
        }

        public void ActivateUser()
        {
            if (RegistrationStatus != RegistrationStatus.ADDRESS_VERIFIED)
                throw new InvalidOperationException("Address can only be verified after the registration request is sent.");

            RegistrationStatus = RegistrationStatus.ACTIVATED;
        }

        public void DeactivateUser()
        {
            if (RegistrationStatus != RegistrationStatus.ACTIVATED)
                throw new InvalidOperationException("Only active customer can be deactivated.");

            RegistrationStatus = RegistrationStatus.DEACTIVATED;
        }

        public void ReactivateUser()
        {
            if (RegistrationStatus != RegistrationStatus.DEACTIVATED)
                throw new InvalidOperationException("Only deactivated customer can be activated.");

            RegistrationStatus = RegistrationStatus.ACTIVATED;
        }
    }
}
