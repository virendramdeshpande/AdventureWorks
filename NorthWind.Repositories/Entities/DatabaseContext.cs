
using Microsoft.EntityFrameworkCore;
using NorthWind.Repositories.Entities;

namespace NorthWind.Repositories.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {

        }

        public virtual DbSet<CoveragePlanEntity> CoveragePlan { get; set; }
      
        public virtual DbSet<ContractsEntity> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CoveragePlanEntity>(entity =>
            {
                entity.HasNoKey();
            });

         
        }
    }
}
