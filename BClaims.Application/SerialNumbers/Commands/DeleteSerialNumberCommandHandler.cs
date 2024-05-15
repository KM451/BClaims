using BClaims.Application.Common.Interfaces;
using BClaims.Shared.SerialNumbers.Commands.DeleteSerialNumber;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.SerialNumbers.Commands
{
    public class DeleteSerialNumberCommandHandler(IBClaimsDbContext _context) : IRequestHandler<DeleteSerialNumberCommand>
    {
        public async Task Handle(DeleteSerialNumberCommand request, CancellationToken cancellationToken)
        {
            var serialNumber = await _context.SerialNumbers.Where(s => s.Id == request.SerialNumberId).FirstOrDefaultAsync(cancellationToken);

            if (serialNumber == null)
            {
                throw new ArgumentNullException();
            }

            _context.SerialNumbers.Remove(serialNumber);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
