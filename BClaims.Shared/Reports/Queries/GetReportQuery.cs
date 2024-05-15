using BClaims.Shared.Reports.Dtos;
using MediatR;

namespace BClaims.Shared.Reports.Queries
{
    public class GetReportQuery : IRequest<ReportDto>
    {
        public int ReportId { get; set; }
    }
}
