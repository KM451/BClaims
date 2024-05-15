using BClaims.Application.Common.Interfaces;
using BClaims.Shared.Reports.Commands.UpdateReportState;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Reports.Commands
{
    public class UpdateReportStateCommandHandler(IBClaimsDbContext _context) : IRequestHandler<UpdateReportStateCommand>
    {
        public async Task Handle(UpdateReportStateCommand request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports
                .Where(r => r.StatusId != 0 && r.Id == request.ReportId)
                .FirstOrDefaultAsync(cancellationToken);

            if (report == null)
            {
                throw new ArgumentNullException();
            }

            report.ReportState = (int)request.NewState;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
