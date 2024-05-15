using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.Common;
using BClaims.Shared.Reports.Commands.AddReport;
using MediatR;

namespace BClaims.Application.Reports.Commands
{
    public class AddReportCommandHandler(IBClaimsDbContext _context, IDateTime _dateTime) : IRequestHandler<AddReportCommand, string>
    {
        public async Task<string> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
  
            var newReportNo = (_context.Reports.Count(r => r.Created.Year == _dateTime.Now.Year) + 1).ToString() + "/" + _dateTime.Now.Year.ToString().Remove(0, 2);
        
            var report = new Report
            {
                ReportNo = newReportNo,
                ItemCode = request.ItemCode,
                ItemName = request.ItemName,
                Qty = request.Qty,
                Description = request.Description,
                ZseNo = request.ZseNo,
                ReportState = (int)ReportState.wprowadzone,
                SerialNumbers = SerialsList(request.SerialNumbers),
                AttachmentUrls = UrlsList(request.AttachmentUrls)
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync(cancellationToken);
            return report.ReportNo;
        }
        private List<SerialNumber> SerialsList(List<string> _serialNumbers)
        {
            var serialsList = new List<SerialNumber>();
            if (_serialNumbers != null)
            {
                foreach (var serialNumber in _serialNumbers)
                {
                    serialsList.Add(new SerialNumber { SerialNo = serialNumber });
                }
            }
            return serialsList;
        }

        private List<AttachmentUrl> UrlsList(List<string> _urls)
        {
            var urlsList = new List<AttachmentUrl>();
            if (_urls != null)
            {
                foreach (var url in _urls)
                {
                    urlsList.Add(new AttachmentUrl { Path = url });
                }
            }
            return urlsList;
        }
    }
}
