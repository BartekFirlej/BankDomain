namespace Bank.Infrastructure.Persistence.Entities;

public partial class CustomerStatusEntity
{
    public int ID { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
}
