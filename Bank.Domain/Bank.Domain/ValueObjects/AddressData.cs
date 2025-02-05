namespace Bank.Domain.ValueObjects
{
    public sealed class AddressData
    {
        public string? Street { get; }
        public string City { get; }
        public string Number { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public AddressData(string street, string city, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code cannot be empty.", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));

            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public AddressData(string city, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code cannot be empty.", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));

            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
