using Bank.Domain.ValueObjects;
using System.Net;

namespace Bank.Domain.Entities
{
    public class Customer
    {
        public int ID { get; private set; }
        public ContactData ContactData { get; private set; }
        public PersonalData PersonalData { get; private set; }
        public int AddressId { get; private set; }
        public DateTime RegistrationDateTime { get; private set; }
        public RegistrationStatus RegistrationStatus { get; private set; }

        public Customer(int id, ContactData contactData, PersonalData personalData, int addressId, DateTime registrationDate)
        {
            if (contactData == null) throw new ArgumentException("Contact data is required.");
            if (personalData == null) throw new ArgumentException("Personal data is required.");
            if (addressId <= 0) throw new ArgumentException("AddressId must be a valid reference.");
            if (registrationDate > DateTime.UtcNow) throw new ArgumentException("Registration date cannot be in the future.");

            ID = id;
            ContactData = contactData;
            PersonalData = personalData;
            AddressId = addressId;
            RegistrationDateTime = registrationDate;
            RegistrationStatus = RegistrationStatus.REQUEST_SENT;
        }

        public Customer(int id, ContactData contactData, PersonalData personalData, int addressId, DateTime registrationDate, RegistrationStatus registrationStatus)
        {
            if (contactData == null) throw new ArgumentException("Contact data is required.");
            if (personalData == null) throw new ArgumentException("Personal data is required.");
            if (addressId <= 0) throw new ArgumentException("AddressId must be a valid reference.");
            if (registrationDate > DateTime.UtcNow) throw new ArgumentException("Registration date cannot be in the future.");

            ID = id;
            ContactData = contactData;
            PersonalData = personalData;
            AddressId = addressId;
            RegistrationDateTime = registrationDate;
            RegistrationStatus = registrationStatus;
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
