using MediatR;

namespace BClaims.Shared.Reports.Commands.UpdateZseNo
{
    public class UpdateZseNoCommand : IRequest
    {
        public int ReportId { get; set; }
        public string ZseNo { get; set; }
    }
}
