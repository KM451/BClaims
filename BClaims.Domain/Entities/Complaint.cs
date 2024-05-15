using BClaims.Domain.Common;

namespace BClaims.Domain.Entities
{
    public class Complaint : AuditableEntity
    {
        public string InternalComplaintNo { get; set; }
        public string? SupplierComplaintNo { get; set; }
        public string? InternalDocumentNo { get; set; }
        public string? PurchaseDocumentNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Description { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
