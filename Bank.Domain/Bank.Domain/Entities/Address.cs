namespace Bank.Domain.Entities
{
    public class Address
    {
        public int ID { get; private set; }
        public string? Street { get; private set; } 
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public string Number { get; private set; }

        public Address(int id, string? street, string city, string postalCode, string country, string number)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code cannot be empty.", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Number cannot be empty.", nameof(number));

            ID = id;
            Street = string.IsNullOrWhiteSpace(street) ? null : street; 
            City = city;
            PostalCode = postalCode;
            Country = country;
            Number = number;
        }

        public Address(string? street, string city, string postalCode, string country, string number)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("Postal code cannot be empty.", nameof(postalCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Number cannot be empty.", nameof(number));

            Street = string.IsNullOrWhiteSpace(street) ? null : street;
            City = city;
            PostalCode = postalCode;
            Country = country;
            Number = number;
        }
    }
}
