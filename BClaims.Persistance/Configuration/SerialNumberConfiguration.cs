using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BClaims.Persistance.Configuration
{
    public class SerialNumberConfiguration : IEntityTypeConfiguration<SerialNumber>
    {
        public void Configure(EntityTypeBuilder<SerialNumber> builder)
        {
            builder.ToTable("SerialNumbers");
            builder.HasKey(t => t.Id);
            builder.Property(s => s.SerialNo).HasMaxLength(200).IsRequired();
        }
    }
}
