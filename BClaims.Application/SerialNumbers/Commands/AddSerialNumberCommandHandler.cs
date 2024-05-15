using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Entities;
using BClaims.Shared.SerialNumbers.Commands.AddSerialNumber;
using MediatR;

namespace BClaims.Application.SerialNumbers.Commands
{
    public class AddSerialNumberCommandHandler(IBClaimsDbContext _context) : IRequestHandler<AddSerialNumberCommand>
    {
        public async Task Handle(AddSerialNumberCommand request, CancellationToken cancellationToken)
        {
            var serialNumber = new SerialNumber
            {
                SerialNo = request.SerialNumber,
                ReportId = request.ReportId
            };

            _context.SerialNumbers.Add(serialNumber);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
