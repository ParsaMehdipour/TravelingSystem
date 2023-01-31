using Driver.Domain.Repositories;
using FluentValidation;
using SH.InfrastructureEfCore.Consts;

namespace Driver.Application.Drivers.Commands.CreateDriver;

public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator(IDriverRepository driverRepository)
    {
        RuleFor(_ => _.FirstName)
            .MaximumLength(50).WithName("نام").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.LastName)
            .MaximumLength(50).WithName("نام خانوادگی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.NationalCode)
            .MaximumLength(50).WithName("کد ملی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (nationalCode, cancellationToken) => !await driverRepository.NationalCodeExists(0, nationalCode, false, cancellationToken)).WithMessage(ValidationMessage.BeUnique);

        RuleFor(_ => _.PhoneNumber)
            .MaximumLength(50).WithName("شماره تماس").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (phoneNumber, cancellationToken) => !await driverRepository.PhoneNumberExists(0, phoneNumber, false, cancellationToken)).WithMessage(ValidationMessage.BeUnique);

        RuleFor(_ => _.CarBrand)
            .MaximumLength(50).WithName("سازنده ماشین").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.CarModel)
            .MaximumLength(50).WithName("مدل ماشین").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.PlateNumber)
            .MaximumLength(50).WithName("شماره پلاک").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (plateNumber, cancellationToken) => !await driverRepository.PhoneNumberExists(0, plateNumber, false, cancellationToken)).WithMessage(ValidationMessage.BeUnique);
    }
}
