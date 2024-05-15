using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.Reports.Dtos;
using BClaims.Shared.Reports.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Reports.Queries
{
    public class GetReportQueryHandler(IBClaimsDbContext _context) : IRequestHandler<GetReportQuery, ReportDto>
    {
        public async Task<ReportDto> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports
                .Where(p => p.StatusId != 0 && p.Id == request.ReportId)
                .FirstOrDefaultAsync(cancellationToken);

            if (report == null)
            {
                throw new ArgumentNullException();
            }

            return Map(report);

        }

        private static ReportDto Map(Report report)
        {
            return new ReportDto
            {
                ReportNo = report.ReportNo,
                ItemCode = report.ItemCode,
                ItemName = report.ItemName,
                Qty = report.Qty,
                Description = report.Description,
                ZseNo = report.ZseNo,
                ReportState = report.ReportState,
                CreatedBy = report.CreatedBy,
                CreateDate = report.Created,
            };
        }
   
    }
}
