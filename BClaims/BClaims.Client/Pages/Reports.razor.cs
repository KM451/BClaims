using BClaims.Client.HttpRepository.Interfaces;
using BClaims.Shared.Reports.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BClaims.Client.Pages
{
    public partial class Reports
    {
        static IComponentRenderMode _renderMode = new InteractiveAutoRenderMode(prerender:false);

        private IEnumerable<ReportsDto> _reports;
        [Inject]
        public IReportsHttpRepository ReportsRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _reports = await ReportsRepo.GetReports();
        }
    }
}
