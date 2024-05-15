using BClaims.Domain.Common;

namespace BClaims.Domain.Entities
{
    public class Report : AuditableEntity
    {
        public string ReportNo { get; set; }
        public string ItemCode { get; set; }
        public string? ItemName { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public string? ZseNo { get; set; }
        public int ReportState { get; set; }
        public ICollection<AttachmentUrl> AttachmentUrls { get; set; }
        public ICollection<SerialNumber> SerialNumbers { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
    }
}
