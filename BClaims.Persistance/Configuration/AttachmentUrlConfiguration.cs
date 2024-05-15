using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BClaims.Persistance.Configuration
{
    public class AttachmentUrlConfiguration : IEntityTypeConfiguration<AttachmentUrl>
    {
        public void Configure(EntityTypeBuilder<AttachmentUrl> builder)
        {
            builder.ToTable("AttachmentUrls");
            builder.HasKey(t => t.Id);
            builder.Property(a => a.Path).HasMaxLength(200).IsRequired();
        }
    }
}
