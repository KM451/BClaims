using BClaims.Application.Common.Interfaces;
using BClaims.Shared.AttachmentUrls.Commands.DeleteAttachmentUrl;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.AttachmentUrls.Commands
{
    public class DeleteAttachmentUrlCommandHandler(IBClaimsDbContext _context) : IRequestHandler<DeleteAttachmentUrlCommand>
    {
        public async Task Handle(DeleteAttachmentUrlCommand request, CancellationToken cancellationToken)
        {
            var attachmentUrl = await _context.AttachmentUrls.Where(s => s.Id == request.AttachmentUrlId).FirstOrDefaultAsync(cancellationToken);

            if (attachmentUrl == null)
            {
                throw new ArgumentNullException();
            }

            _context.AttachmentUrls.Remove(attachmentUrl);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
