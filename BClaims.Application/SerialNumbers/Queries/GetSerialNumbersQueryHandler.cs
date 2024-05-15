using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.SerialNumbers.Dtos;
using BClaims.Shared.SerialNumbers.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.SerialNumbers.Queries
{
    public class GetSerialNumbersQueryHandler(IBClaimsDbContext _context) : IRequestHandler<GetSerialNumbersQuery, ICollection<SerialNumberDto>>
    {
        public async Task<ICollection<SerialNumberDto>> Handle(GetSerialNumbersQuery request, CancellationToken cancellationToken)
        {
            var serialNumbers = await _context.SerialNumbers
                .Where(p => p.StatusId != 0 && p.ReportId == request.ReportId)
                .ToListAsync(cancellationToken);

            if (serialNumbers == null)
            {
                throw new ArgumentNullException();
            }

            return serialNumbers.Select(a => Map(a)).ToList();
        }

        private static SerialNumberDto Map(SerialNumber serialNumber)
        {
            return new SerialNumberDto
            {
                SerialNoId = serialNumber.Id,
                SerialNumber = serialNumber.SerialNo
            };
        }
    }
}
