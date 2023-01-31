using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.EditDriver;

public record EditDriverCommand(long Id, string FirstName, string LastName, string NationalCode, string PhoneNumber, string CarBrand, string CarModel, string PlateNumber) : IRequest<Result>;

