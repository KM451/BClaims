using BClaims.Client.HttpRepository.Interfaces;
using BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl;
using System.Net.Http.Json;

namespace BClaims.Client.HttpRepository
{
    public class AttachmentRepository(HttpClient _client) : IAttachmentRepository
    {

        public async Task Upload(AddAttachmentUrlCommand command)
        {
            await _client.PostAsJsonAsync("attachments", command);
            //result.EnsureSuccessStatusCode();
        }

    }
}
