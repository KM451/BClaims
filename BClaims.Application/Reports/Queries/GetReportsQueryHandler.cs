using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.Reports.Dtos;
using BClaims.Shared.Reports.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Reports.Queries
{
    public class GetReportsQueryHandler(IBClaimsDbContext _context) : IRequestHandler<GetReportsQuery, ICollection<ReportsDto>>
    {
        public async Task<ICollection<ReportsDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _context.Reports
                .Where(p => p.StatusId != 0)
                .ToListAsync(cancellationToken);

            if (reports == null)
            {
                throw new ArgumentNullException();
            }

            return reports.Select(r=>Map(r)).ToList();

        }
        private ReportsDto Map(Report report)
        {
            return new ReportsDto
            {
                Id = report.Id,
                ReportNo = report.ReportNo,
                ItemCode = report.ItemCode,
                ReportDate = report.Created,
                ReportState = report.ReportState
            };
        }
    }
}
