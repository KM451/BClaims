using BClaims.Client.HttpRepository.Interfaces;
using BClaims.Shared.Reports.Commands.AddReport;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BClaims.Client.Pages
{
    public partial class AddReport
    {
        [Inject]
        public IReportsHttpRepository ReportsRepo { get; set; }

        private AddReportCommand _newReport = new();

        private bool _inProgress = false;

        Variant variant = Variant.Outlined;


        private void OnChangeSerialsList(List<string> newList)
        {
            _newReport.SerialNumbers = newList;
        }

        private async Task Save()
        {
            try
            {
                _inProgress = true;
                _newReport.AttachmentUrls = new List<string>();
                await ReportsRepo.AddReport(_newReport);
            }
            finally
            {
                _inProgress = false;
            }
        }



    }
}
