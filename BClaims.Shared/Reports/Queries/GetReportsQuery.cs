using BClaims.Shared.Reports.Dtos;
using MediatR;

namespace BClaims.Shared.Reports.Queries
{
    public class GetReportsQuery : IRequest<ICollection<ReportsDto>>
    {
    }
}
