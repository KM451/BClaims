using BClaims.Shared.Common;
using MediatR;

namespace BClaims.Shared.Reports.Commands.UpdateReportState
{
    public class UpdateReportStateCommand : IRequest
    {
        public int ReportId { get; set; }
        public ReportState NewState { get; set; }
    }
}
