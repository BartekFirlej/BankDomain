using System;
using System.Collections.Generic;

namespace Bank.Infrastructure.Persistence.Entities;

public partial class AddressEntity
{
    public int ID { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Postal_Code { get; set; } = null!;

    public string? Street { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
}
