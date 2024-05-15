using FluentValidation;

namespace BClaims.Shared.Complaints.Commands.AddComplaint
{
    public class AddComplaintValidator : AbstractValidator<AddComplaintCommand>
    {
        public AddComplaintValidator()
        {
            RuleFor(c => c.InternalDocumentNo).MaximumLength(50);
            RuleFor(c => c.PurchaseDocumentNo).MaximumLength(50);
            RuleFor(c => c.PurchaseDate).LessThan(DateTime.Now);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ReportId).NotEmpty();
            RuleFor(c => c.ComplaintSerie).IsInEnum();
        }
    }
}
