using Driver.Application.Drivers.Commands.EditDriver;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Queries.GetDriver;

public record GetDriverQuery(long Id) : IRequest<Result<EditDriverCommand>>
{
    internal EditDriverCommand ToCommand(Domain.Models.Driver driver) =>
        new(driver.Id,
            driver.FirstName,
            driver.LastName,
            driver.NationalCode,
            driver.PhoneNumber,
            driver.CarBrand,
            driver.CarModel,
            driver.PlateNumber);
}
