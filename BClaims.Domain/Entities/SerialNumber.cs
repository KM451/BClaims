using BClaims.Domain.Common;

namespace BClaims.Domain.Entities
{
    public class SerialNumber : AuditableEntity
    {
        public string SerialNo { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
