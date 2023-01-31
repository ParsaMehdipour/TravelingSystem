using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.CreateDriver;

public record CreateDriverCommand(string FirstName, string LastName, string NationalCode, string PhoneNumber, string CarBrand, string CarModel, string PlateNumber) : IRequest<Result<long>>;

