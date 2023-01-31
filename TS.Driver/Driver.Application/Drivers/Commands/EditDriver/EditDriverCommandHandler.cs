using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.EditDriver;

public class EditDriverCommandHandler : IRequestHandler<EditDriverCommand, Result>
{
    protected IDriverRepository _driverRepository { get; }

    public EditDriverCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result> Handle(EditDriverCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = await _driverRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(driver, nameof(driver));

        driver.SetFirstName(request.FirstName);
        driver.SetLastName(request.LastName);
        driver.SetNationalCode(request.NationalCode);
        driver.SetPhoneNumber(request.PhoneNumber);
        driver.SetCarBrand(request.CarBrand);
        driver.SetCarModel(request.CarModel);
        driver.SetPlateNumber(request.PlateNumber);

        _driverRepository.Update(driver);
        await _driverRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
