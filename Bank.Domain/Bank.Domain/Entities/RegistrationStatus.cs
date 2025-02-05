namespace Bank.Domain.Entities
{
    public enum RegistrationStatus
    {
        REQUEST_SENT,
        PERSONAL_DATA_VERIFIED,
        CONTACT_DATA_VERIFIED,
        ADDRESS_VERIFIED,
        ACTIVATED,
        DEACTIVATED
    }
}