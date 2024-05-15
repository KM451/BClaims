using Radzen.Blazor;
using Radzen;
using BClaims.Shared.Reports.Dtos;
using Microsoft.AspNetCore.Components;
using BClaims.Shared.Common;

namespace BClaims.Client.Components
{
    public partial class BClaimTemplate
    {
        RadzenDataGrid<ReportsDto> reportsGrid;

        private IList<ReportsDto> _reports;

        [Parameter]
        public IEnumerable<ReportsDto> Reports { get; set; }

        [Parameter]
        public ReportState DisplayedReportState { get; set; }

        async Task OpenReport(int reportId)
        {
          //  await DialogService.OpenAsync<ReportPage>($"Report {reportId}",
           //       new Dictionary<string, object>() { { "ReportID", reportId } });
                  //new DialogOptions() { Width = "700px", Height = "520px" }); ;
        }

        protected override async Task OnInitializedAsync()
        {
            _reports = Reports.Where(r => r.ReportState == ((int)DisplayedReportState)).ToList();
        }

        
    }
}
