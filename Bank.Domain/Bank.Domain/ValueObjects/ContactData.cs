using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Bank.Domain.ValueObjects
{
    public sealed class ContactData
    {
        public string PhoneNumber { get; }
        public string EmailAddress { get; }

        public ContactData(string phoneNumber, string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("Email address cannot be empty.", nameof(emailAddress));
            var phoneRegex = new Regex(@"^\+?[0-9]{7,15}$");
            if (!phoneRegex.IsMatch(phoneNumber))
                throw new ArgumentException("Invalid phone number format.", nameof(phoneNumber));
            try
            {
                var mailAddress = new MailAddress(emailAddress);
                if (mailAddress.Address != emailAddress)
                    throw new ArgumentException("Invalid email address format.", nameof(emailAddress));
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid email address format.", nameof(emailAddress));
            }
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
