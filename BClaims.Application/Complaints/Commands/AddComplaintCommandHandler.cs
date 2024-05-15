using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.Complaints.Commands.AddComplaint;
using MediatR;

namespace BClaims.Application.Complaints.Commands
{
    public class AddComplaintCommandHandler(IBClaimsDbContext _context, IDateTime _dateTime) : IRequestHandler<AddComplaintCommand, string>
    {    
        public async Task<string> Handle(AddComplaintCommand request, CancellationToken cancellationToken)
        {
            var newComplaintNo = request.ComplaintSerie.ToString() + (_context.Complaints.Count(c => c.Created.Year == _dateTime.Now.Year) + 1).ToString() + "/" + _dateTime.Now.Year.ToString().Remove(0, 2);

            var complaint = new Complaint
            {
                InternalComplaintNo = newComplaintNo,
                InternalDocumentNo = request.InternalDocumentNo,
                PurchaseDocumentNo = request.PurchaseDocumentNo,
                PurchaseDate = request.PurchaseDate,
                Description = request.Description,
                ReportId = request.ReportId,
            };

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync(cancellationToken);
            return complaint.InternalComplaintNo;
        }
    }
}
