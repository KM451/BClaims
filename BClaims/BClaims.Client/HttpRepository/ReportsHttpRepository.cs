using BClaims.Client.HttpRepository.Interfaces;
using BClaims.Shared.Reports.Commands.AddReport;
using BClaims.Shared.Reports.Dtos;
using System.Net.Http.Json;

namespace BClaims.Client.HttpRepository
{
    public class ReportsHttpRepository(HttpClient _client) : IReportsHttpRepository
    {
        public async Task AddReport(AddReportCommand command)
            => await _client.PostAsJsonAsync("reports", command);

        public async Task<ICollection<ReportsDto>> GetReports() =>
            await _client.GetFromJsonAsync<ICollection<ReportsDto>>("reports");
        
    }
}
