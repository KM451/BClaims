using FluentValidation;

namespace BClaims.Shared.Reports.Commands.AddReport
{
    public class AddReportCommandValidator : AbstractValidator<AddReportCommand>
    {
        public AddReportCommandValidator()
        {
            RuleFor(r => r.ItemCode).NotEmpty().MaximumLength(40);
            RuleFor(r => r.ItemName).MaximumLength(100);
            RuleFor(r => r.Qty).NotNull();
            RuleFor(r => r.Description).NotEmpty().WithMessage("to chyba musisz podać");
            RuleFor(r => r.ZseNo).MaximumLength(40);
            RuleFor(r => r.SerialNumbers).ForEach(s => s.MaximumLength(200).NotEmpty());
            RuleFor(r => r.AttachmentUrls).ForEach(a => a.MaximumLength(200).NotEmpty());

        }
    }
}
