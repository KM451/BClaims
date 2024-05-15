using FluentValidation;

namespace BClaims.Shared.Reports.Commands.UpdateReportState
{
    public class UpdateReportStateValidator : AbstractValidator<UpdateReportStateCommand>
    {
        public UpdateReportStateValidator()
        {
            RuleFor(r => r.NewState).NotNull().IsInEnum();
        }
    }
}
