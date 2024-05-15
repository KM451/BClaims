using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BClaims.Persistance.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(t => t.Id);
            builder.Property(r => r.ReportNo).HasMaxLength(40).IsRequired();
            builder.Property(r => r.ItemCode).HasMaxLength(40).IsRequired();
            builder.Property(r => r.ItemName).HasMaxLength(100);
            builder.Property(r => r.Qty).HasPrecision(10, 2).IsRequired();
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.ZseNo).HasMaxLength(40);
        }
    }
}
