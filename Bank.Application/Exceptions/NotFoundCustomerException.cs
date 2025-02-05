namespace Bank.Application.Exceptions
{
    public class NotFoundCustomerException : Exception
    {
        public NotFoundCustomerException(int customerId) : base(String.Format("Not found customer with id {0}.", customerId)) { 
            this.HResult = 404;
        }
    }
}
