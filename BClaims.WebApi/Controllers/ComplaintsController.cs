using BClaims.Shared.Complaints.Commands.AddComplaint;
using BClaims.Shared.Complaints.Dtos;
using BClaims.Shared.Complaints.Queries;
using BClaims.Shared.SerialNumbers.Dtos;
using BClaims.Shared.SerialNumbers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BClaims.WebApi.Controllers
{
    [Route("api/v1/complaints")]
    public class ComplaintsController : BaseController
    {
        /// <summary>
        /// Get collection of complaints elements specified by report id number
        /// </summary>
        /// <param name="id">Report id number</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<ComplaintDto>>> GetComplaints(int id)
        {
            return Ok(await Mediator.Send(new GetComplaintsQuery { ReportId = id }));
        }

        /// <summary>
        /// Add the new complaint
        /// </summary>
        /// <param name="command">The new complaint data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddComplaintCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
