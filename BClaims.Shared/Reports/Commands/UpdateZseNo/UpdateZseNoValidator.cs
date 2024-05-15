using FluentValidation;

namespace BClaims.Shared.Reports.Commands.UpdateZseNo
{
    public class UpdateZseNoValidator : AbstractValidator<UpdateZseNoCommand>
    {
        public UpdateZseNoValidator()
        {
            RuleFor(r => r.ZseNo).NotEmpty().MaximumLength(40);     
        }
    }
}
