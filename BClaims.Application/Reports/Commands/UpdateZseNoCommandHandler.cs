using BClaims.Application.Common.Interfaces;
using BClaims.Shared.Reports.Commands.UpdateZseNo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Reports.Commands
{
    public class UpdateZseNoCommandHandler(IBClaimsDbContext _context) : IRequestHandler<UpdateZseNoCommand>
    {
        public async Task Handle(UpdateZseNoCommand request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports
                .Where(r => r.StatusId != 0 && r.Id == request.ReportId)
                .FirstOrDefaultAsync();

            if (report == null)
            {
                throw new ArgumentNullException();
            }

            report.ZseNo = request.ZseNo;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
