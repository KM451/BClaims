using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.Complaints.Dtos;
using BClaims.Shared.Complaints.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Complaints.Queries
{
    public class GetComplaintsQueryHandler(IBClaimsDbContext _context) : IRequestHandler<GetComplaintsQuery, ICollection<ComplaintDto>>
    {
        public async Task<ICollection<ComplaintDto>> Handle(GetComplaintsQuery request, CancellationToken cancellationToken)
        {
            var complaints = await _context.Complaints
                .Where(p => p.StatusId != 0 && p.ReportId == request.ReportId)
                .ToListAsync(cancellationToken);

            if (complaints == null)
            {
                throw new ArgumentNullException();
            }

            return complaints.Select(a => Map(a)).ToList();
        }

        private static ComplaintDto Map(Complaint complaint)
        {
            return new ComplaintDto
            {
                InternalComplaintNo = complaint.InternalComplaintNo,
                SupplierComplaintNo = complaint.SupplierComplaintNo,
                InternalDocumentNo = complaint.InternalDocumentNo,
                PurchaseDocumentNo = complaint.PurchaseDocumentNo,
                PurchaseDate = complaint.PurchaseDate,
                Description = complaint.Description
            };
        }
    }
}
