using MediatR;

namespace BClaims.Shared.SerialNumbers.Commands.AddSerialNumber
{
    public class AddSerialNumberCommand : IRequest
    {
        public string SerialNumber { get; set; }
        public int ReportId { get; set; }
    }
}
