using BClaims.Application.Common.Interfaces;
using BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl;
using BClaims.Shared.AttachmentUrls.Commands.DeleteAttachmentUrl;
using BClaims.Shared.AttachmentUrls.Dtos;
using BClaims.Shared.AttachmentUrls.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BClaims.WebApi.Controllers
{
    [Route("api/v1/attachments")]
    public class AttachmentUrlsController(IFileStore fileStore) : BaseController
    {
        /// <summary>
        /// Get collection of attachment urls specified by report id number
        /// </summary>
        /// <param name="id">Report id number</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<AttachmentUrlDto>>> GetAttachmentUrls(int id)
        {
            return Ok(await Mediator.Send(new GetAttachmentUrlsQuery() { ReportId = id }));
        }

        /// <summary>
        /// Add the new attachment url
        /// </summary>
        /// <param name="command">The new attachment url data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddAttachmentUrlCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        
        /// <summary>
        /// Delete the attachment url specified by Id number
        /// </summary>
        /// <param name="id">Id number of attachment url</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachmentUrl(int id)
        {
            var command = new DeleteAttachmentUrlCommand { AttachmentUrlId = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
