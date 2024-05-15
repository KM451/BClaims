using BClaims.Shared.Common;
using BClaims.Shared.Reports.Commands.AddReport;
using BClaims.Shared.Reports.Commands.UpdateReportState;
using BClaims.Shared.Reports.Commands.UpdateZseNo;
using BClaims.Shared.Reports.Dtos;
using BClaims.Shared.Reports.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BClaims.WebApi.Controllers
{
    [Route("api/v1/reports")]
    public class ReportsController : BaseController
    {
        /// <summary>
        /// Get te list of existing reports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<ReportsDto>>> GetReports()
        {
            return Ok(await Mediator.Send(new GetReportsQuery()));
        }

        /// <summary>
        /// Get details of report specified by id number
        /// </summary>
        /// <param name="id">id of required report</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetReport(int id)
        {
            return Ok(await Mediator.Send(new GetReportQuery() { ReportId = id}));
        }

        /// <summary>
        /// Add the new report
        /// </summary>
        /// <param name="command">The new report data</param>
        /// <returns>No of the new report</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddReportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update value of report state
        /// </summary>
        /// <param name="id">id of updated report</param>
        /// <param name="state">the new value of report state</param>
        /// <returns></returns>
        [HttpPatch("{id}/state")]
        public async Task<IActionResult> UpdateState(int id, ReportState state)
        {
            var command = new UpdateReportStateCommand { ReportId = id, NewState = state };
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Update value of ZSE number
        /// </summary>
        /// <param name="id">id of updated report</param>
        /// <param name="zse">the new value of ZseNo</param>
        /// <returns></returns>
        [HttpPatch("{id}/zse")]
        public async Task<IActionResult> UpdateZseNo(int id, string zse)
        {
            var command = new UpdateZseNoCommand { ReportId = id, ZseNo = zse };
            await Mediator.Send(command);
            return Ok();
        }

    }
}
