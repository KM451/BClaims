using BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl;

namespace BClaims.Client.HttpRepository.Interfaces
{
    public interface IAttachmentRepository
    {
        Task Upload(AddAttachmentUrlCommand command);
    }
}
