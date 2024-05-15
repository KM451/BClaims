using BClaims.Domain.Common;

namespace BClaims.Domain.Entities
{
    public class AttachmentUrl : AuditableEntity
    {
        public string Path { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
