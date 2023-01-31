using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.ChangeDriverStatus;

public class ChangeDriverStatusCommandHandler : IRequestHandler<ChangeDriverStatusCommand, Result>
{
    protected IDriverRepository _driverRepository { get; }

    public ChangeDriverStatusCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result> Handle(ChangeDriverStatusCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = await _driverRepository.GetWithoutQueryFilterAsync(_ => _.Id == request.Id, cancellationToken);

        ArgumentNullException.ThrowIfNull(driver, nameof(driver));

        driver.SetStatus(request.Status);

        _driverRepository.Update(driver);
        await _driverRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
