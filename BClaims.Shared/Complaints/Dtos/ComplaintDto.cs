namespace BClaims.Shared.Complaints.Dtos
{
    public class ComplaintDto
    {
        public string InternalComplaintNo { get; set; }
        public string? SupplierComplaintNo { get; set; }
        public string? InternalDocumentNo { get; set; }
        public string? PurchaseDocumentNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Description { get; set; }
    }
}
