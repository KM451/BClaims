using BClaims.Shared.AttachmentUrls.Dtos;
using BClaims.Shared.Complaints.Dtos;
using BClaims.Shared.SerialNumbers.Dtos;

namespace BClaims.Shared.Reports.Dtos
{
    public class ReportDto
    {
        public string ReportNo { get; set; }
        public string ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public string? ZseNo { get; set; }
        public int ReportState { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        //public List<AttachmentUrlDto>? Attachments { get; set; }
        //public List<SerialNumberDto>? Serials { get; set; }
        //public List<ComplaintDto>? Complaints { get; set; }

    }
}
