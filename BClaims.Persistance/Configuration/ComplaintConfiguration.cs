using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BClaims.Persistance.Configuration
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.ToTable("Complaints");
            builder.HasKey(t => t.Id);
            builder.Property(c => c.InternalComplaintNo).HasMaxLength(50).IsRequired();
            builder.Property(c => c.SupplierComplaintNo).HasMaxLength(50);
            builder.Property(c => c.InternalDocumentNo).HasMaxLength(50);
            builder.Property(c => c.PurchaseDocumentNo).HasMaxLength(50);
        }
    }
}
