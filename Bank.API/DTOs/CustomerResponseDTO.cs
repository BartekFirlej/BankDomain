using Bank.Domain.Entities;

namespace Bank.API.DTOs
{
    public class CustomerResponseDto
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
    }
}
