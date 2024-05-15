using MediatR;

namespace BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl
{
    public class AddAttachmentUrlCommand : IRequest
    {
        public int ReportId { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}
