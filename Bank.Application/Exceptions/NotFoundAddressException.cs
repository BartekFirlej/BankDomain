namespace Bank.Application.Exceptions
{
    public class NotFoundAddressException : Exception
    {
        public NotFoundAddressException(int addressId) : base(String.Format("Not found address with id {0}.", addressId))
        {
            this.HResult = 404;
        }
    }
}
