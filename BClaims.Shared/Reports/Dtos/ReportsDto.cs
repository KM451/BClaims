namespace BClaims.Shared.Reports.Dtos
{
    public class ReportsDto
    {
        public int Id { get; set; }
        public string ReportNo { get; set; }
        public string ItemCode { get; set; }
        public DateTime ReportDate { get; set; }
        public int ReportState { get; set; }
    }
}
