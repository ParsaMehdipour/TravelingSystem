using Driver.Domain.Repositories;
using FluentValidation;
using SH.InfrastructureEfCore.Consts;

namespace Driver.Application.Drivers.Commands.EditDriver;

public class EditDriverCommandValidator : AbstractValidator<EditDriverCommand>
{
    public EditDriverCommandValidator(IDriverRepository driverRepository)
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("شناسه");

        RuleFor(_ => _.FirstName).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("نام")
            .MaximumLength(50).WithName("نام").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.LastName).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("نام خانوادگی")
            .MaximumLength(50).WithName("نام خانوادگی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.NationalCode).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("کد ملی")
            .MaximumLength(50).WithName("کد ملی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (command, nationalCode, cancellationToken) => !await driverRepository.NationalCodeExists(command.Id, command.NationalCode, true, cancellationToken)).WithMessage(ValidationMessage.NotExists).WithName("کد ملی");

        RuleFor(_ => _.PhoneNumber).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("شماره تماس")
            .MaximumLength(50).WithName("شماره تماس").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (command, phoneNumber, cancellationToken) => !await driverRepository.PhoneNumberExists(command.Id, command.PhoneNumber, true, cancellationToken)).WithMessage(ValidationMessage.NotExists).WithName("شماره تماس");

        RuleFor(_ => _.CarBrand)
            .MaximumLength(50).WithName("سازنده ماشین").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.CarModel)
            .MaximumLength(50).WithName("مدل ماشین").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.PlateNumber)
            .MaximumLength(50).WithName("شماره پلاک").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (plateNumber, cancellationToken) => !await driverRepository.PhoneNumberExists(0, plateNumber, true, cancellationToken)).WithMessage(ValidationMessage.BeUnique);
    }
}
