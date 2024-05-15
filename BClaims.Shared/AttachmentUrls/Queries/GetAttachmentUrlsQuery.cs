using BClaims.Shared.AttachmentUrls.Dtos;
using MediatR;

namespace BClaims.Shared.AttachmentUrls.Queries
{
    public class GetAttachmentUrlsQuery : IRequest<ICollection<AttachmentUrlDto>>
    {
        public int ReportId { get; set; }
    }
}
