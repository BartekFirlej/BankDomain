namespace Bank.API.DTOs
{
    public class AddressResponseDTO
    {
        public int ID { get; set; }
        public string? Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
    }
}
