using MediatR;

namespace BClaims.Shared.SerialNumbers.Commands.DeleteSerialNumber
{
    public class DeleteSerialNumberCommand : IRequest
    {
        public int SerialNumberId { get; set; }
    }
}
