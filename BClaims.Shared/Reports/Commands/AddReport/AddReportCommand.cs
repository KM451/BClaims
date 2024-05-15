using MediatR;

namespace BClaims.Shared.Reports.Commands.AddReport
{
    public class AddReportCommand : IRequest<string>
    {
        public string ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public string? ZseNo { get; set; }
        public List<string>? SerialNumbers { get; set; }
        public List<string>? AttachmentUrls { get; set; }
    }
}
