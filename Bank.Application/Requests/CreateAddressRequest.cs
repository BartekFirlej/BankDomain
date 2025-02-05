namespace Bank.Application.Requests
{
    public class CreateAddressRequest
    {
        public string? Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }

        public CreateAddressRequest(string? street, string city, string postalCode, string country, string number)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
            Number = number;
        }
    }
}
