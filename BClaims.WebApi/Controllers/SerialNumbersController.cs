using BClaims.Shared.SerialNumbers.Commands.AddSerialNumber;
using BClaims.Shared.SerialNumbers.Commands.DeleteSerialNumber;
using BClaims.Shared.SerialNumbers.Dtos;
using BClaims.Shared.SerialNumbers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BClaims.WebApi.Controllers
{
    [Route("api/v1/serials")]
    public class SerialNumbersController : BaseController
    {
        /// <summary>
        /// Get collection of serial numbers specified by report id number
        /// </summary>
        /// <param name="id">Report id number</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<SerialNumberDto>>> GetSerialNumbers(int id)
        {
            return Ok(await Mediator.Send(new GetSerialNumbersQuery() { ReportId = id }));
        }

        /// <summary>
        /// Add the new serial number
        /// </summary>
        /// <param name="command">The new serial number data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddSerialNumberCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete the serial number specified by Id number
        /// </summary>
        /// <param name="id">Id number of serial number</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerialNumber(int id)
        {
            var command = new DeleteSerialNumberCommand { SerialNumberId = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
