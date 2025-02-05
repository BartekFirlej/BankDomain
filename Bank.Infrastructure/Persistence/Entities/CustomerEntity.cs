namespace Bank.Infrastructure.Persistence.Entities;
public partial class CustomerEntity
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int AddressID { get; set; }

    public int CustomerStatusID { get; set; }

    public DateTime RegistrationDateTime { get; set; }

    public DateOnly BirthDate { get; set; }

    public virtual AddressEntity Address { get; set; } = null!;

    public virtual CustomerStatusEntity CustomerStatus { get; set; } = null!;
}
