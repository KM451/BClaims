using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BClaims.Application.Common.Interfaces
{
    public interface IBClaimsDbContext : IDisposable
    {
        DbSet<Report> Reports { get; set; }
        DbSet<AttachmentUrl> AttachmentUrls { get; set; }
        DbSet<Complaint> Complaints { get; set; }
        DbSet<SerialNumber> SerialNumbers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
