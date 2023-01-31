using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Queries.GetDrivers;

public record GetDriversQuery : IRequest<Result<IEnumerable<GetDriversDto>>>;

public record GetDriversDto(long Id, string FirstName, string LastName, string NationalCode, string PhoneNumber, string CarBrand, string CarModel, string PlateNumber, string CreatedDate);
