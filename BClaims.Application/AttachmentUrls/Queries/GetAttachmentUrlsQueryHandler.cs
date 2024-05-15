using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.AttachmentUrls.Dtos;
using BClaims.Shared.AttachmentUrls.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.AttachmentUrls.Queries
{
    public class GetAttachmentUrlsQueryHandler(IBClaimsDbContext _context) : IRequestHandler<GetAttachmentUrlsQuery, ICollection<AttachmentUrlDto>>
    {
        public async Task<ICollection<AttachmentUrlDto>> Handle(GetAttachmentUrlsQuery request, CancellationToken cancellationToken)
        {
            var attachmentUrls = await _context.AttachmentUrls
                .Where(p => p.StatusId != 0 && p.ReportId == request.ReportId)
                .ToListAsync(cancellationToken);

            if (attachmentUrls == null)
            {
                throw new ArgumentNullException();
            }

            return attachmentUrls.Select(a=>Map(a)).ToList();
            
        }

        private static AttachmentUrlDto Map(AttachmentUrl attachmentUrl)
        {
            return new AttachmentUrlDto
            {
                AttachmentUrlId = attachmentUrl.Id,
                Path = attachmentUrl.Path
            };
        }
    }
}
