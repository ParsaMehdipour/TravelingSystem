using SH.Domain;
using SH.Domain.Interfaces;

namespace Traveler.Domain.Models;

public class Traveler : AuditableEntity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public string PhoneNumber { get; private set; }

    public Traveler()
    {

    }

    public Traveler(string firstName, string lastName, string nationalCode, string phoneNumber)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetNationalCode(nationalCode);
        SetPhoneNumber(phoneNumber);

        CreatedDate = DateTime.Now;
    }

    public void SetFirstName(string firstName)
    {
        if (FirstName == firstName)
            return;

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (LastName == lastName)
            return;

        LastName = lastName;
    }

    public void SetNationalCode(string nationalCode)
    {
        if (NationalCode == nationalCode)
            return;

        NationalCode = nationalCode;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (PhoneNumber == phoneNumber)
            return;

        PhoneNumber = phoneNumber;
    }
}
