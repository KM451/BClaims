using FluentValidation;

namespace BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl
{
    public class AddAttachmentUrlValidator : AbstractValidator<AddAttachmentUrlCommand>
    {
        public AddAttachmentUrlValidator()
        {
            RuleFor(s => s.FileName).NotEmpty();
        }
    }
}
