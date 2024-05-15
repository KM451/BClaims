using BClaims.Shared.Reports.Commands.AddReport;
using BClaims.Shared.Reports.Dtos;

namespace BClaims.Client.HttpRepository.Interfaces
{
    public interface IReportsHttpRepository
    {
        Task<ICollection<ReportsDto>> GetReports();

        Task AddReport(AddReportCommand command);
    }
}
