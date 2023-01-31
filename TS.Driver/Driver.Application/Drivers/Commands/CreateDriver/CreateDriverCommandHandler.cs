using Driver.Domain.Models;
using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.CreateDriver;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Result<long>>
{
    protected IDriverRepository _driverRepository { get; }
    protected DriverFactory _driverFactory { get; }

    public CreateDriverCommandHandler(IDriverRepository driverRepository, DriverFactory driverFactory)
    {
        _driverRepository = driverRepository;
        _driverFactory = driverFactory;
    }

    public async Task<Result<long>> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = _driverFactory.Create(request.FirstName, request.LastName, request.NationalCode, request.PhoneNumber, request.CarBrand, request.CarModel, request.PlateNumber);

        await _driverRepository.AddAsync(driver, cancellationToken);
        await _driverRepository.SaveAsync(cancellationToken);

        return Result.Ok(driver.Id);
    }
}
