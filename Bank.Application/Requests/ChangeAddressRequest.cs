namespace Bank.Application.Requests
{
    public class ChangeAddressRequest
    {
        public int CustomerID { get; set; }
        public string? Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }

        public ChangeAddressRequest(int customerID, string? street, string city, string postalCode, string country, string number)
        {
            CustomerID = customerID;
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
            Number = number;
        }
    }
}
