using BClaims.Shared.Common;
using MediatR;

namespace BClaims.Shared.Complaints.Commands.AddComplaint
{
    public class AddComplaintCommand : IRequest<string>
    {
        public string? InternalDocumentNo { get; set; }
        public string? PurchaseDocumentNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Description { get; set; }
        public int ReportId { get; set; }
        public ComplaintSeries ComplaintSerie { get; set; }
    }
}
