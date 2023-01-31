using Driver.Domain.Repositories;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.Extensions;

namespace Driver.Application.Drivers.Queries.GetDrivers;
public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, Result<IEnumerable<GetDriversDto>>>
{
    protected IDriverRepository _driverRepository { get; }

    public GetDriversQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<Result<IEnumerable<GetDriversDto>>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
    {
        var travelers = _driverRepository.Get();

        var result = await travelers.Select(_ => new GetDriversDto(
            _.Id,
            _.FirstName,
            _.LastName,
            _.NationalCode,
            _.PhoneNumber,
            _.CarBrand,
            _.CarModel,
            _.PlateNumber,
            _.CreatedDate.ToPersian()
            )).ToListAsync(cancellationToken);

        return Result.Ok(result.AsEnumerable()); //AsReadOnly() doesn't work
    }
}
