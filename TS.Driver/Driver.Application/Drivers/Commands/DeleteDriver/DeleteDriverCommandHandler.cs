using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.DeleteDriver;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Result>
{
    protected IDriverRepository _driverRepository { get; }

    public DeleteDriverCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = await _driverRepository.GetWithoutQueryFilterAsync(_ => _.Id == request.Id, cancellationToken);

        ArgumentNullException.ThrowIfNull(driver, nameof(driver));

        if (request.IsRestore)
            driver.RestoreItem();
        else
            driver.DeleteItem();

        _driverRepository.Update(driver);
        await _driverRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
