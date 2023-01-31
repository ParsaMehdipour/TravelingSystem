using Driver.Application.Drivers.Commands.EditDriver;
using Driver.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Queries.GetDriver;

public class GetDriverQueryHandler : IRequestHandler<GetDriverQuery, Result<EditDriverCommand>>
{
    protected IDriverRepository _driverRepository { get; }

    public GetDriverQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result<EditDriverCommand>> Handle(GetDriverQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Driver driver = await _driverRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(driver, nameof(driver));

        return Result.Ok(request.ToCommand(driver));
    }
}
