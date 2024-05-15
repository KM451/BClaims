using BClaims.Application.Common.Interfaces;
using BClaims.Domain.Common;
using BClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BClaims.Persistance
{
    public class BClaimsDbContext : DbContext, IBClaimsDbContext
    {
        private readonly IDateTime _dateTime;
        public BClaimsDbContext(DbContextOptions options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Report> Reports { get ; set ; }
        public DbSet<AttachmentUrl> AttachmentUrls { get ; set ; }
        public DbSet<SerialNumber> SerialNumbers { get ; set ; }
        public DbSet<Complaint> Complaints { get ; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "user";
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = "user";
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = "user";
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.InactivatedBy = "user";
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
