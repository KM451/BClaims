using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl;
using MediatR;

namespace BClaims.Application.AttachmentUrls.Commands
{
    public class AddAttachmentUrlCommandHandler(IBClaimsDbContext _context, IFileStore _fileStore) : IRequestHandler<AddAttachmentUrlCommand>
    {
        public async Task Handle(AddAttachmentUrlCommand request, CancellationToken cancellationToken)
        {
            var attachmentUrl = new AttachmentUrl
            {
                Path = $"wwwroot/files/{request.ReportId}/{request.FileName}",
                ReportId = request.ReportId
            };

            _fileStore.SafeWriteFile(request.Content, request.FileName, $"wwwroot/files/{request.ReportId}");

            _context.AttachmentUrls.Add(attachmentUrl);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
