using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.AddDriverPoints;

public class AddDriverPointsCommandHandler : IRequestHandler<AddDriverPointsCommand, Result>
{
    protected IDriverRepository _driverRepository { get; }

    public AddDriverPointsCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result> Handle(AddDriverPointsCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = await _driverRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(driver, nameof(driver));

        driver.AddDriverPoints(request.Point);

        _driverRepository.Update(driver);
        await _driverRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
