namespace Bank.Domain.ValueObjects
{
    public sealed class PersonalData
    {
        public string FirstName { get; }
        public string? SecondName { get; }
        public string LastName { get; }
        public DateOnly BirthDate { get; }

        public PersonalData(string firstName, string secondName, string lastName, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty", nameof(firstName));
            if (string.IsNullOrWhiteSpace(secondName))
                throw new ArgumentException("Second name cannot be empty", nameof(secondName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty", nameof(lastName));
            if (birthDate.Year >= DateTime.Now.Year - 10)
                throw new ArgumentException("Too low age");
            if (birthDate.Year <= DateTime.Now.Year -100)
                throw new ArgumentException("Too high age.");

            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public PersonalData(string firstName, string lastName, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty", nameof(lastName));
            if (birthDate.Year >= DateTime.Now.Year - 10)
                throw new ArgumentException("Too low age");
            if (birthDate.Year <= DateTime.Now.Year - 100)
                throw new ArgumentException("Too high age");

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
