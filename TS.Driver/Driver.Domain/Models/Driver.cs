using SH.Domain;
using SH.Domain.Interfaces;

namespace Driver.Domain.Models;

public class Driver : AuditableEntity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string CarBrand { get; private set; }
    public string CarModel { get; private set; }
    public string PlateNumber { get; private set; }
    public int DriverPoints { get; private set; }
    public bool Status { get; set; }

    public Driver()
    {

    }

    public Driver(string firstName, string lastName, string nationalCode, string phoneNumber, string carBrand, string carModel, string plateNumber)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetNationalCode(nationalCode);
        SetPhoneNumber(phoneNumber);
        SetCarBrand(carBrand);
        SetCarModel(carModel);
        SetPlateNumber(plateNumber);
        SetStatus(false);

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

    public void SetCarBrand(string carBrand)
    {
        if (CarBrand == carBrand)
            return;

        CarBrand = carBrand;
    }

    public void SetCarModel(string carModel)
    {
        if (CarModel == carModel)
            return;

        CarModel = carModel;
    }

    public void SetPlateNumber(string plateNumber)
    {
        if (PlateNumber == plateNumber)
            return;

        PlateNumber = plateNumber;
    }

    public void AddDriverPoints(int driverPoints)
    {
        DriverPoints += driverPoints;
    }

    public void SetStatus(bool status)
    {
        if (Status == status)
            return;

        Status = status;
    }
}
