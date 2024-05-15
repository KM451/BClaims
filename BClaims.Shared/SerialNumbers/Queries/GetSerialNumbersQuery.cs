using BClaims.Shared.SerialNumbers.Dtos;
using MediatR;

namespace BClaims.Shared.SerialNumbers.Queries
{
    public class GetSerialNumbersQuery : IRequest<ICollection<SerialNumberDto>>
    {
        public int ReportId { get; set; }
    }
}
