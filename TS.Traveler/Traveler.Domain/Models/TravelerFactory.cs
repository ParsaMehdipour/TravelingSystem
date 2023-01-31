namespace Traveler.Domain.Models;

public class TravelerFactory
{
    public Traveler Create(string firstName, string lastName, string nationalCode, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(firstName, nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(lastName, nameof(lastName));

        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new ArgumentNullException(nationalCode, nameof(nationalCode));

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentNullException(phoneNumber, nameof(phoneNumber));

        Traveler traveler = new(firstName, lastName, nationalCode, phoneNumber);

        return traveler;
    }
}
