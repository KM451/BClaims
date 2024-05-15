using BClaims.Shared.Complaints.Dtos;
using MediatR;

namespace BClaims.Shared.Complaints.Queries
{
    public class GetComplaintsQuery : IRequest<ICollection<ComplaintDto>>
    {
        public int ReportId { get; set; }
    }
}
