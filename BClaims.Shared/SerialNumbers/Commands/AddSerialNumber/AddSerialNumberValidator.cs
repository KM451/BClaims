using FluentValidation;

namespace BClaims.Shared.SerialNumbers.Commands.AddSerialNumber
{
    public class AddSerialNumberValidator : AbstractValidator<AddSerialNumberCommand>
    {
        public AddSerialNumberValidator()
        {
            RuleFor(s=>s.SerialNumber).MaximumLength(200).NotEmpty();
        }
    }
}
