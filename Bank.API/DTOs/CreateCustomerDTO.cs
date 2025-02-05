namespace Bank.API.DTOs
{
    public class CreateCustomerDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
