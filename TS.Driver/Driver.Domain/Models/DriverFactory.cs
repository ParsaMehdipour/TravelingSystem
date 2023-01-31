namespace Driver.Domain.Models;

public class DriverFactory
{
    public Driver Create(string firstName, string lastName, string nationalCode, string phoneNumber, string carBrand, string carModel, string plateNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(firstName, nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(lastName, nameof(lastName));

        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new ArgumentNullException(nationalCode, nameof(nationalCode));

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentNullException(phoneNumber, nameof(phoneNumber));

        if (string.IsNullOrWhiteSpace(carBrand))
            throw new ArgumentNullException(carBrand, nameof(carBrand));

        if (string.IsNullOrWhiteSpace(carModel))
            throw new ArgumentNullException(carModel, nameof(carModel));

        if (string.IsNullOrWhiteSpace(plateNumber))
            throw new ArgumentNullException(plateNumber, nameof(plateNumber));

        Driver driver = new(firstName, lastName, nationalCode, phoneNumber, carBrand, carModel, plateNumber);

        return driver;
    }
}
