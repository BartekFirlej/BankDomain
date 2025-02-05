namespace Bank.Domain.Events
{
    public class CustomerChangeAddressEvent
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }

        public CustomerChangeAddressEvent(int customerId, int addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }
}
