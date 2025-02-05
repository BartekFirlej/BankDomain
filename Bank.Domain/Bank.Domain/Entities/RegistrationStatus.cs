namespace Bank.Domain.Entities
{
    public enum RegistrationStatus
    {
        REQUEST_SENT = 1,
        PERSONAL_DATA_VERIFIED = 2,
        CONTACT_DATA_VERIFIED = 3,
        ADDRESS_VERIFIED = 4,
        ACTIVATED = 5,
        DEACTIVATED = 6
    }
}
